namespace Homework_1_C_sharp_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.btnGetItem = new System.Windows.Forms.Button();
            this.listBoxItem = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxIndex = new System.Windows.Forms.ListBox();
            this.btnGetIndex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Java ",
            "C ",
            "C++ ",
            "C#",
            "Objective-C",
            "PHP",
            "Python",
            "Ruby",
            "Javascript",
            "SQL"});
            this.checkedListBox.Location = new System.Drawing.Point(12, 36);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(266, 202);
            this.checkedListBox.TabIndex = 0;
            // 
            // btnGetItem
            // 
            this.btnGetItem.Location = new System.Drawing.Point(12, 254);
            this.btnGetItem.Name = "btnGetItem";
            this.btnGetItem.Size = new System.Drawing.Size(77, 27);
            this.btnGetItem.TabIndex = 1;
            this.btnGetItem.Text = "Get item";
            this.btnGetItem.UseVisualStyleBackColor = true;
            this.btnGetItem.Click += new System.EventHandler(this.btnGetItem_Click);
            // 
            // listBoxItem
            // 
            this.listBoxItem.FormattingEnabled = true;
            this.listBoxItem.ItemHeight = 15;
            this.listBoxItem.Location = new System.Drawing.Point(12, 287);
            this.listBoxItem.Name = "listBoxItem";
            this.listBoxItem.Size = new System.Drawing.Size(146, 124);
            this.listBoxItem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Programming Languages";
            // 
            // listBoxIndex
            // 
            this.listBoxIndex.FormattingEnabled = true;
            this.listBoxIndex.ItemHeight = 15;
            this.listBoxIndex.Location = new System.Drawing.Point(203, 287);
            this.listBoxIndex.Name = "listBoxIndex";
            this.listBoxIndex.Size = new System.Drawing.Size(146, 124);
            this.listBoxIndex.TabIndex = 5;
            // 
            // btnGetIndex
            // 
            this.btnGetIndex.Location = new System.Drawing.Point(203, 254);
            this.btnGetIndex.Name = "btnGetIndex";
            this.btnGetIndex.Size = new System.Drawing.Size(77, 27);
            this.btnGetIndex.TabIndex = 4;
            this.btnGetIndex.Text = "Get index";
            this.btnGetIndex.UseVisualStyleBackColor = true;
            this.btnGetIndex.Click += new System.EventHandler(this.btnGetIndex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxIndex);
            this.Controls.Add(this.btnGetIndex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxItem);
            this.Controls.Add(this.btnGetItem);
            this.Controls.Add(this.checkedListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox checkedListBox;
        private Button btnGetItem;
        private ListBox listBoxItem;
        private Label label1;
        private ListBox listBoxIndex;
        private Button btnGetIndex;
    }
}