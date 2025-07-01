using FileEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEngine
{
    internal class UndoHandler : IFileEventHandler
    {
        public List<RenameResult> Execute(string[] files, string suffix, string extension)
        {
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
                        var lastChanges = RenameHistory.Instance.GetLast();
                        if (lastChanges != null)
                        {

                            string newPath = Path.Combine(dir!, lastChanges.OriginalName);
                            File.Move(filePath, newPath);
                            result.Success = true;
                            string newFileName = Path.GetFileName(newPath);
                            result.NewName = newFileName;
                            result.OriginalName = name + ext;
                        }
                        else
                        {
                            result.Success = false;
                            result.ErrorMessage = "There is no change";
                        }

                    }
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.ErrorMessage = $"{Path.GetFileName(filePath)} =>  Error: {ex.Message}";
                }

                results.Add(result);

            }

            return results;
        }
    }
}
