using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureToASCII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };
        private string _html = "";

        private void btnConvertToAscii_Click(object sender, EventArgs e)
        {
            btnConvertToAscii.Enabled = false;
            // завантаження зображення

            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("Файл для конвертування відсутній!");
            }
            else
            {
                try
                {
                    Bitmap image = new Bitmap(txtPath.Text, true);
                    // зміна розміру зображення, пропорціонально ширині, узгоджуючи з якістю конвертування
                    image = GetReSizedImage(image, slider.Value);
                    // конвертування зображення в ASCII
                    _html = ConvertToAscii(image);
                }
                catch
                {
                    MessageBox.Show("Некоректний формат файлу зображення!");
                }
            }
            int fontSize = Math.Max((slider.Maximum - slider.Value) / 32, 4);
            // Заключим наше текстовое представление в тег <pre>, чтобы сохранить форматирование
            _html = "<pre style=\"font-size: " + fontSize + "px\">" + _html + "</pre>";

            ResultWindow.DocumentText = _html;
            btnConvertToAscii.Enabled = true;
        }

        private string ConvertToAscii(Bitmap image)
        {
            Boolean toggle = false;
            StringBuilder sb = new StringBuilder();

            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    // середнє значення з RGB для знаходження сірого кольору
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(gray, gray, gray);
                    // Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_AsciiChars[index]);
                    }
                }
                if (!toggle)
                {
                    sb.Append("<br>");
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }
            }
            return sb.ToString();
        }

        private Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth)
        {
            // обчислення нової висоти, пропорціонально до зміненої ширини
            int asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);

            // створення нового Bitmap зображення
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult diag = openFileDialog1.ShowDialog();
            if (diag == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_html.Length == 0)
            {
                MessageBox.Show("Файл для конвертування відсутній!");
            }
            else
            {
                saveFileDialog1.Filter = "HTML files (*.html)|*.html";
                DialogResult diag = saveFileDialog1.ShowDialog();
                if (diag == DialogResult.OK)
                {
                    //заміна всіх HTML пробілів стандартними
                    _html = _html.Replace("&nbsp;", " ").Replace("<br>", "\r\n");
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(_html);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}