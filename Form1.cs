using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureToASCII {
    public partial class Form1 : Form {
        private string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };
        private string _html;
        public Form1() {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e) {
            DialogResult diag = openFileDialog1.ShowDialog();
            if (diag == DialogResult.OK) {
                txtPath.Text = openFileDialog1.FileName;
            }
        }
        private void btnConvertToAscii_Click(object sender, EventArgs e) {
            btnConvertToAscii.Enabled = false;
            // завантаження зображення
            Bitmap image = new Bitmap(txtPath.Text, true);
            // зміна розміру зображення, пропорціонально ширині, узгоджуючи з якістю конвертування
            image = GetReSizedImage(image, slider.Value);

            _html = ConvertToAscii(image);

            int fontSize = Math.Max((slider.Maximum - slider.Value) / 32, 4);
            // розміщення текстового вигляду зображення в тег <pre> для збереження форматування
            _html = "<pre style=\"font-size: " + fontSize + "px\">" + _html + "</pre>";

            ResultWindow.DocumentText = _html;
            btnConvertToAscii.Enabled = true;
        }
        private string ConvertToAscii(Bitmap image) {
            Boolean toggle = false;
            StringBuilder sb = new StringBuilder();

            for (int h = 0; h < image.Height; h++) {
                for (int w = 0; w < image.Width; w++) {
                    Color pixelColor = image.GetPixel(w, h);
                    // середнє значення RGB для знаходження сірого кольору
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(gray, gray, gray);
                    // додавання тегу <br> якщо новий рядок пікселів 
                    // в іншому випадку конвертування пікселю в сірий колір і в символ ASCII
                    if (!toggle) {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_AsciiChars[index]);
                    }
                }
                if (!toggle) {
                    sb.Append("<br>");
                    toggle = true;
                } else {
                    toggle = false;
                }
            }
            return sb.ToString();
        }

        private Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth) {
            // обчислення нової висоти пропроціонально до зміненої ширини
            int asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);

            // створення нового Bitmap зображення
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }

        private void saveAsHTML_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "HTML files (*.html)|*.html";
            DialogResult diag = saveFileDialog1.ShowDialog();
            if (diag == DialogResult.OK) {
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