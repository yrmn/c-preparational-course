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
            this.FormatSelect = new System.Windows.Forms.ComboBox();
            this.TimerAlex = new System.Windows.Forms.Timer(this.components);
            this.TimerBill = new System.Windows.Forms.Timer(this.components);
            this.TimerCynthia = new System.Windows.Forms.Timer(this.components);
            this.MessageListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.checkBoxFilter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            // TimerAlex
            // 
            this.TimerAlex.Interval = 2000;
            this.TimerAlex.Tick += new System.EventHandler(this.TimerAlex_Tick);
            // 
            // TimerBill
            // 
            this.TimerBill.Interval = 3000;
            this.TimerBill.Tick += new System.EventHandler(this.TimerBill_Tick);
            // 
            // TimerCynthia
            // 
            this.TimerCynthia.Interval = 4000;
            this.TimerCynthia.Tick += new System.EventHandler(this.TimerCynthia_Tick);
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnText});
            this.MessageListView.Location = new System.Drawing.Point(12, 39);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(342, 351);
            this.MessageListView.TabIndex = 2;
            this.MessageListView.TileSize = new System.Drawing.Size(300, 32);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 50;
            // 
            // columnText
            // 
            this.columnText.Text = "Text";
            this.columnText.Width = 300;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(360, 39);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUser.Sorted = true;
            this.comboBoxUser.TabIndex = 3;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(360, 66);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(121, 20);
            this.textBoxFilter.TabIndex = 4;
            this.textBoxFilter.Text = "(Enter text here)";
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeFrom.Location = new System.Drawing.Point(360, 92);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(121, 20);
            this.dateTimeFrom.TabIndex = 5;
            this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTimeFrom_ValueChanged);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeTo.Location = new System.Drawing.Point(360, 118);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(121, 20);
            this.dateTimeTo.TabIndex = 6;
            this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTimeTo_ValueChanged);
            // 
            // checkBoxFilter
            // 
            this.checkBoxFilter.AutoSize = true;
            this.checkBoxFilter.Location = new System.Drawing.Point(360, 144);
            this.checkBoxFilter.Name = "checkBoxFilter";
            this.checkBoxFilter.Size = new System.Drawing.Size(101, 19);
            this.checkBoxFilter.TabIndex = 7;
            this.checkBoxFilter.Text = "Use OR logic";
            this.checkBoxFilter.UseVisualStyleBackColor = true;
            this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.checkBoxFilter_CheckedChanged);
            // 
            // SMSScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 406);
            this.Controls.Add(this.checkBoxFilter);
            this.Controls.Add(this.dateTimeTo);
            this.Controls.Add(this.dateTimeFrom);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.MessageListView);
            this.Controls.Add(this.FormatSelect);
            this.MaximizeBox = false;
            this.Name = "SMSScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Filtering";
            this.Load += new System.EventHandler(this.SMSScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox FormatSelect;
        private System.Windows.Forms.Timer TimerAlex;
        private System.Windows.Forms.Timer TimerBill;
        private System.Windows.Forms.Timer TimerCynthia;
        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnText;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.CheckBox checkBoxFilter;
    }
}