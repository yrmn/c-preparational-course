namespace WinFormsPhone {
    partial class Calls {
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
            this.CallsListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssociatedListView = new System.Windows.Forms.ListView();
            this.associatedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.associatedText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCalls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CallsListView
            // 
            this.CallsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnText});
            this.CallsListView.Location = new System.Drawing.Point(16, 32);
            this.CallsListView.Name = "CallsListView";
            this.CallsListView.Size = new System.Drawing.Size(246, 280);
            this.CallsListView.TabIndex = 0;
            this.CallsListView.UseCompatibleStateImageBehavior = false;
            this.CallsListView.View = System.Windows.Forms.View.Tile;
            this.CallsListView.SelectedIndexChanged += new System.EventHandler(this.CallsListView_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            // 
            // columnText
            // 
            this.columnText.Text = "Time";
            // 
            // AssociatedListView
            // 
            this.AssociatedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.associatedName,
            this.associatedText});
            this.AssociatedListView.Location = new System.Drawing.Point(282, 32);
            this.AssociatedListView.Name = "AssociatedListView";
            this.AssociatedListView.Size = new System.Drawing.Size(239, 280);
            this.AssociatedListView.TabIndex = 1;
            this.AssociatedListView.UseCompatibleStateImageBehavior = false;
            this.AssociatedListView.View = System.Windows.Forms.View.Tile;
            // 
            // associatedName
            // 
            this.associatedName.Text = "Name";
            // 
            // associatedText
            // 
            this.associatedText.Text = "Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Call list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Associated calls ";
            // 
            // buttonCalls
            // 
            this.buttonCalls.Location = new System.Drawing.Point(236, 318);
            this.buttonCalls.Name = "buttonCalls";
            this.buttonCalls.Size = new System.Drawing.Size(75, 23);
            this.buttonCalls.TabIndex = 4;
            this.buttonCalls.Text = "Start calls";
            this.buttonCalls.UseVisualStyleBackColor = true;
            this.buttonCalls.Click += new System.EventHandler(this.buttonCalls_Click);
            // 
            // Calls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 348);
            this.Controls.Add(this.buttonCalls);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AssociatedListView);
            this.Controls.Add(this.CallsListView);
            this.Name = "Calls";
            this.Text = "Calls";
            this.Load += new System.EventHandler(this.Calls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView CallsListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnText;
        private System.Windows.Forms.ListView AssociatedListView;
        private System.Windows.Forms.ColumnHeader associatedName;
        private System.Windows.Forms.ColumnHeader associatedText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCalls;
    }
}