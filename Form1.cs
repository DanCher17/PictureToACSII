using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureToASCII {
    public partial class Form1 : Form {
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
            // завантаження зображення
            Bitmap image = new Bitmap(txtPath.Text, true);
            // зміна розміру зображення, пропорціонально ширині, узгоджуючи з якістю конвертування
        }
        }
    }