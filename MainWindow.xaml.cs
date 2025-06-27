using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int log_count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = FolderPathTextBox.Text;
            string suffix = SuffixTextBox.Text;

            var status = FileRenamer.FileRenamer.RenameFiles(folderPath, suffix);
            StringBuilder sb = new StringBuilder();

            foreach (var s in status)
            {
                log_count++;

                string logText = s.Success
                    ? $"[{log_count}] File renamed: {s.OriginalName} => {s.NewName}"
                    : $"[{log_count}] File not renamed: {s.ErrorMessage}";

                LogBox.Document.Blocks.Add(new Paragraph(new Run(logText)));
                LogBox.ScrollToEnd();


            }
        }
        private void ClearLogButton_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Document.Blocks.Clear();
            log_count = 0; 
        }

    }
}