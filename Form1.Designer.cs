namespace FileRenamer
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
            UndoButton = new Button();
            ClearLog = new Button();
            LogTextBox = new TextBox();
            TargetDirectoryTextBox = new TextBox();
            SuffixTextBox = new TextBox();
            RenameButton = new Button();
            ExtentionTextBox = new TextBox();
            SuspendLayout();
            // 
            // UndoButton
            // 
            UndoButton.BackColor = SystemColors.Menu;
            UndoButton.Font = new Font("Segoe UI", 10F);
            UndoButton.Location = new Point(564, 116);
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(82, 32);
            UndoButton.TabIndex = 1;
            UndoButton.Text = "Undo";
            UndoButton.UseVisualStyleBackColor = false;
            UndoButton.Click += UndoButton_Click;
            // 
            // ClearLog
            // 
            ClearLog.BackColor = SystemColors.Menu;
            ClearLog.Font = new Font("Segoe UI", 10F);
            ClearLog.Location = new Point(476, 116);
            ClearLog.Name = "ClearLog";
            ClearLog.Size = new Size(82, 32);
            ClearLog.TabIndex = 2;
            ClearLog.Text = "Clear Log";
            ClearLog.UseVisualStyleBackColor = false;
            ClearLog.Click += ClearLog_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.BackColor = Color.FromArgb(255, 255, 255);
            LogTextBox.Enabled = false;
            LogTextBox.Location = new Point(100, 164);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.PlaceholderText = "Logs...";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(647, 264);
            LogTextBox.TabIndex = 3;
            LogTextBox.TabStop = false;
            LogTextBox.TextChanged += LogTextBox_TextChanged;
            // 
            // TargetDirectoryTextBox
            // 
            TargetDirectoryTextBox.Location = new Point(111, 86);
            TargetDirectoryTextBox.Name = "TargetDirectoryTextBox";
            TargetDirectoryTextBox.PlaceholderText = "Enter Target Directory";
            TargetDirectoryTextBox.Size = new Size(195, 23);
            TargetDirectoryTextBox.TabIndex = 4;
            // 
            // SuffixTextBox
            // 
            SuffixTextBox.Location = new Point(111, 125);
            SuffixTextBox.Name = "SuffixTextBox";
            SuffixTextBox.PlaceholderText = "Enter Suffix";
            SuffixTextBox.Size = new Size(195, 23);
            SuffixTextBox.TabIndex = 5;
            SuffixTextBox.TextChanged += SuffixTextBox_TextChanged;
            // 
            // RenameButton
            // 
            RenameButton.BackColor = SystemColors.Menu;
            RenameButton.Font = new Font("Segoe UI", 10F);
            RenameButton.Location = new Point(652, 116);
            RenameButton.Name = "RenameButton";
            RenameButton.Size = new Size(82, 32);
            RenameButton.TabIndex = 6;
            RenameButton.Text = "Rename";
            RenameButton.UseVisualStyleBackColor = false;
            RenameButton.Click += RenameButton_Click;
            // 
            // ExtentionTextBox
            // 
            ExtentionTextBox.Location = new Point(312, 86);
            ExtentionTextBox.Name = "ExtentionTextBox";
            ExtentionTextBox.PlaceholderText = "Extention";
            ExtentionTextBox.Size = new Size(82, 23);
            ExtentionTextBox.TabIndex = 7;
            ExtentionTextBox.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 578);
            Controls.Add(ExtentionTextBox);
            Controls.Add(RenameButton);
            Controls.Add(SuffixTextBox);
            Controls.Add(TargetDirectoryTextBox);
            Controls.Add(LogTextBox);
            Controls.Add(ClearLog);
            Controls.Add(UndoButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button UndoButton;
        private Button ClearLog;
        private TextBox LogTextBox;
        private TextBox TargetDirectoryTextBox;
        private TextBox SuffixTextBox;
        private Button RenameButton;
        private TextBox ExtentionTextBox;
    }
}
