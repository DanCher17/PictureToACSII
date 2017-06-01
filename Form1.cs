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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult diag = openFileDialog1.ShowDialog();
            if (diag == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }
        private void btnConvertToAscii_Click(object sender, EventArgs e)
        {
            btnConvertToAscii.Enabled = false;
            // Р·Р°РІР°РЅС‚Р°Р¶РµРЅРЅСЏ Р·РѕР±СЂР°Р¶РµРЅРЅСЏ
            Bitmap image = new Bitmap(txtPath.Text, true);
            // Р·РјС–РЅР° СЂРѕР·РјС–СЂСѓ Р·РѕР±СЂР°Р¶РµРЅРЅСЏ, РїСЂРѕРїРѕСЂС†С–РѕРЅР°Р»СЊРЅРѕ С€РёСЂРёРЅС–, СѓР·РіРѕРґР¶СѓСЋС‡Рё Р· СЏРєС–СЃС‚СЋ РєРѕРЅРІРµСЂС‚СѓРІР°РЅРЅСЏ
            image = GetReSizedImage(image, slider.Value);

            _html = ConvertToAscii(image);
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

    }
    }