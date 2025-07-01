
using FileEngine;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        int log_count = 0;
        public Form1()
        {
            InitializeComponent();
        }



        private void UndoButton_Click(object sender, EventArgs e)
        {
            string folderPath = TargetDirectoryTextBox.Text;
            string suffix = SuffixTextBox.Text;
            string extention = ExtentionTextBox.Text;

            var status = FileEngine.FileHandler.FileEvent(folderPath, suffix, extention, FileEngine.FileEventType.Undo);

            foreach (var s in status)
            {
                log_count++;
                string logText = s.Success
                          ? $"[{log_count}] File renamed: {s.OriginalName} => {s.NewName}"
                          : $"[{log_count}] File not renamed: {s.ErrorMessage}";

                LogTextBox.AppendText(logText + "\r\n");
            }

        }
        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SuffixTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            LogTextBox.Clear();
            log_count = 0;

        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            string folderPath = TargetDirectoryTextBox.Text;
            string suffix = SuffixTextBox.Text;
            string extention = ExtentionTextBox.Text;

            var status =  FileEngine.FileHandler.FileEvent(folderPath, suffix, extention, FileEngine.FileEventType.Rename);

            foreach (var s in status)
            {
                log_count++;
                string logText = s.Success
                          ? $"[{log_count}] File renamed: {s.OriginalName} => {s.NewName}"
                          : $"[{log_count}] File not renamed: {s.ErrorMessage}";

                LogTextBox.AppendText(logText + "\r\n");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
