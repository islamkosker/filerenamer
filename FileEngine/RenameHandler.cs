using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEngine
{
    public class RenameHandler : IFileEventHandler

    {
        public List<RenameResult> Execute(string[] files, string suffix, string extension)
        {
            int fileNumber = 0;
            var results = new List<RenameResult>();

            foreach (var filePath in files)
            {
                var result = new RenameResult();
                try
                {
                    string? dir = Path.GetDirectoryName(filePath);
                    string? name = Path.GetFileNameWithoutExtension(filePath);
                    string? ext = Path.GetExtension(filePath);



                    if (ext != $".{extension}")
                    {
                        result.Success = false;
                        result.ErrorMessage = "❌ File extension does not match target file extension. No changes made";
                    }
                    else
                    {
                        fileNumber++;
                        string formattedNumber = fileNumber.ToString("D4");

                        string newName = FileHandler.FormatNewName(name, suffix, fileNumber, FileEventType.Rename, ext);

                        string newPath = Path.Combine(dir!, newName);
                        File.Move(filePath, newPath);

                        result.OriginalName = name + ext;
                        result.NewName = newName;
                        result.Success = true;
                    }
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = $"{Path.GetFileName(filePath)} =>  Error: {ex.Message}";
                }

                results.Add(result);
                RenameHistory.Instance.Add(result);
            }
           

            return results;
        }
    }
}
