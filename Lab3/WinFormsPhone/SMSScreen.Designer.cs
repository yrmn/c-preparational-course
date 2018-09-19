namespace WinFormsPhone {
    partial class SMSScreen {
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
            this.components = new System.ComponentModel.Container();
            this.MessageScreen = new System.Windows.Forms.RichTextBox();
            this.FormatSelect = new System.Windows.Forms.ComboBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MessageScreen
            // 
            this.MessageScreen.Location = new System.Drawing.Point(12, 39);
            this.MessageScreen.Name = "MessageScreen";
            this.MessageScreen.Size = new System.Drawing.Size(441, 351);
            this.MessageScreen.TabIndex = 0;
            this.MessageScreen.Text = "";
            // 
            // FormatSelect
            // 
            this.FormatSelect.FormattingEnabled = true;
            this.FormatSelect.Items.AddRange(new object[] {
            "None",
            "Start with DateTime",
            "End with DateTime",
            "Custom",
            "Lowercase",
            "Uppercase"});
            this.FormatSelect.Location = new System.Drawing.Point(12, 12);
            this.FormatSelect.Name = "FormatSelect";
            this.FormatSelect.Size = new System.Drawing.Size(192, 21);
            this.FormatSelect.TabIndex = 1;
            this.FormatSelect.Text = "Select Formatting";
            this.FormatSelect.SelectedIndexChanged += new System.EventHandler(this.FormatSelect_SelectedIndexChanged);
            // 
            // Timer
            // 
            this.Timer.Interval = 2000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // SMSScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 402);
            this.Controls.Add(this.FormatSelect);
            this.Controls.Add(this.MessageScreen);
            this.MaximizeBox = false;
            this.Name = "SMSScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Formatting";
            this.Load += new System.EventHandler(this.SMSScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox MessageScreen;
        private System.Windows.Forms.ComboBox FormatSelect;
        private System.Windows.Forms.Timer Timer;
    }
}