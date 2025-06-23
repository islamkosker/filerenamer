// MainPage.xaml.cs
using System.Diagnostics;

namespace MauiApp1
{



    public partial class MainPage : ContentPage
    {
        private Entry entryDir;
        private Entry entrySuffix;

        private Editor logEditor;

        private void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                string newValue = entry.Text;
            }
        }

        private void OnEntryCompleted(object? sender, EventArgs e)
        {
            if (sender is Entry entry)
            {
                string? value = entry.Text;
                string sourceId = entry.AutomationId ?? "(unknown)";
            }
        }

        public MainPage()
        {
            InitializeComponent();
            Button button = new Button()
            {
                Text = "Rename files"
            };

            button.Clicked += OnButtonClick;

            entryDir = new Entry()
            {
                Placeholder = "Enter target directory",
            };
            entryDir.TextChanged += OnEntryTextChanged;
            entryDir.Completed += OnEntryCompleted;
            entryDir.AutomationId = "TargetPathEntry";

            entrySuffix = new Entry()
            {
                Placeholder = "Enter file suffix",
            };
            entrySuffix.TextChanged += OnEntryTextChanged;
            entrySuffix.Completed += OnEntryCompleted;
            entrySuffix.AutomationId = "SuffixEntry";


            logEditor = new Editor
            {
                Placeholder = "Log output...",
                IsReadOnly = true,
                AutoSize = EditorAutoSizeOption.TextChanges,
                HeightRequest = 200
            };



            Content = new VerticalStackLayout { Padding = 20, Children = { entryDir, entrySuffix, button, logEditor } };


        }


        private void OnButtonClick(object? sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");
            string? targetDir = entryDir.Text ?? "";
            string? suffix = entrySuffix.Text ?? "";
            Debug.WriteLine($"Target Directory: {targetDir}");
            Debug.WriteLine($"File Suffix: {suffix}");
            try
            {
                var results = FileRenamer.RenameFiles(targetDir, suffix);

                foreach (var result in results)
                {
                    if (result.Success)
                        logEditor.Text += $"[{DateTime.Now:HH:mm:ss}] Success: {result.OriginalName} → {result.NewName}\n";
                    else
                        logEditor.Text += $"[{DateTime.Now:HH:mm:ss}] Error: {result.ErrorMessage}\n";
                }


            }
            catch (System.Exception)
            {

                throw;
            }


        }
    }



}
