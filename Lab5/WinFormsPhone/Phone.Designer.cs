namespace WinFormsPhone {
    partial class Phone {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Option1 = new System.Windows.Forms.RadioButton();
            this.Option2 = new System.Windows.Forms.RadioButton();
            this.Option3 = new System.Windows.Forms.RadioButton();
            this.Option4 = new System.Windows.Forms.RadioButton();
            this.TopLabel = new System.Windows.Forms.Label();
            this.OutText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(191, 154);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Option1
            // 
            this.Option1.AutoSize = true;
            this.Option1.Checked = true;
            this.Option1.Location = new System.Drawing.Point(46, 53);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(98, 19);
            this.Option1.TabIndex = 1;
            this.Option1.TabStop = true;
            this.Option1.Text = "radioButton1";
            this.Option1.UseVisualStyleBackColor = true;
            // 
            // Option2
            // 
            this.Option2.AutoSize = true;
            this.Option2.Location = new System.Drawing.Point(46, 78);
            this.Option2.Name = "Option2";
            this.Option2.Size = new System.Drawing.Size(98, 19);
            this.Option2.TabIndex = 2;
            this.Option2.Text = "radioButton2";
            this.Option2.UseVisualStyleBackColor = true;
            // 
            // Option3
            // 
            this.Option3.AutoSize = true;
            this.Option3.Location = new System.Drawing.Point(46, 103);
            this.Option3.Name = "Option3";
            this.Option3.Size = new System.Drawing.Size(98, 19);
            this.Option3.TabIndex = 3;
            this.Option3.Text = "radioButton3";
            this.Option3.UseVisualStyleBackColor = true;
            // 
            // Option4
            // 
            this.Option4.AutoSize = true;
            this.Option4.Location = new System.Drawing.Point(46, 128);
            this.Option4.Name = "Option4";
            this.Option4.Size = new System.Drawing.Size(98, 19);
            this.Option4.TabIndex = 4;
            this.Option4.Text = "radioButton4";
            this.Option4.UseVisualStyleBackColor = true;
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Location = new System.Drawing.Point(43, 21);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(41, 15);
            this.TopLabel.TabIndex = 5;
            this.TopLabel.Text = "label1";
            // 
            // OutText
            // 
            this.OutText.Location = new System.Drawing.Point(46, 183);
            this.OutText.Multiline = true;
            this.OutText.Name = "OutText";
            this.OutText.ReadOnly = true;
            this.OutText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutText.Size = new System.Drawing.Size(220, 151);
            this.OutText.TabIndex = 6;
            // 
            // Phone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 363);
            this.Controls.Add(this.OutText);
            this.Controls.Add(this.TopLabel);
            this.Controls.Add(this.Option4);
            this.Controls.Add(this.Option3);
            this.Controls.Add(this.Option2);
            this.Controls.Add(this.Option1);
            this.Controls.Add(this.ApplyButton);
            this.MaximizeBox = false;
            this.Name = "Phone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.RadioButton Option1;
        private System.Windows.Forms.RadioButton Option2;
        private System.Windows.Forms.RadioButton Option3;
        private System.Windows.Forms.RadioButton Option4;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.TextBox OutText;
    }
}

