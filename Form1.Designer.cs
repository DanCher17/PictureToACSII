namespace PictureToASCII {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConvertToAscii = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ResultWindow = new System.Windows.Forms.WebBrowser();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.slider = new System.Windows.Forms.TrackBar();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.saveAsHTML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvertToAscii
            // 
            this.btnConvertToAscii.Location = new System.Drawing.Point(12, 92);
            this.btnConvertToAscii.Name = "btnConvertToAscii";
            this.btnConvertToAscii.Size = new System.Drawing.Size(96, 23);
            this.btnConvertToAscii.TabIndex = 3;
            this.btnConvertToAscii.Text = "Конвертація";
            this.btnConvertToAscii.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(310, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(96, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Відкрити файл";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(292, 22);
            this.txtPath.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ResultWindow
            // 
            this.ResultWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultWindow.Location = new System.Drawing.Point(12, 140);
            this.ResultWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.ResultWindow.Name = "ResultWindow";
            this.ResultWindow.Size = new System.Drawing.Size(392, 392);
            this.ResultWindow.TabIndex = 7;
            // 
            // slider
            // 
            this.slider.LargeChange = 100;
            this.slider.Location = new System.Drawing.Point(137, 41);
            this.slider.Maximum = 700;
            this.slider.Minimum = 100;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(269, 45);
            this.slider.SmallChange = 100;
            this.slider.TabIndex = 9;
            this.slider.TickFrequency = 100;
            this.slider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.slider.Value = 100;
            // 
            // QualityLabel
            // 
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.Location = new System.Drawing.Point(9, 55);
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size(123, 13);
            this.QualityLabel.TabIndex = 10;
            this.QualityLabel.Text = "Якість конвертування";
            // 
            // saveAsHTML
            // 
            this.saveAsHTML.Location = new System.Drawing.Point(266, 92);
            this.saveAsHTML.Name = "saveAsHTML";
            this.saveAsHTML.Size = new System.Drawing.Size(140, 23);
            this.saveAsHTML.TabIndex = 11;
            this.saveAsHTML.Text = "Експортувати в HTML";
            this.saveAsHTML.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(418, 544);
            this.Controls.Add(this.saveAsHTML);
            this.Controls.Add(this.QualityLabel);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.ResultWindow);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnConvertToAscii);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PictureToASCII";
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnConvertToAscii;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.WebBrowser ResultWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label QualityLabel;
        private System.Windows.Forms.Button saveAsHTML;
    }
}

