using System;
using System.Diagnostics;
using System.IO;

public class RenameResult
{
    public string OriginalName { get; set; } = "";
    public string NewName { get; set; } = "";
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
public class FileRenamer
{
    public static List<RenameResult> RenameFiles(string path, string suffix)
    {
        var results = new List<RenameResult>();

        if (!Directory.Exists(path))
        {
            results.Add(new RenameResult
            {
                Success = false,
                ErrorMessage = $"❌ Invalid Path: {path}"
            });
            return results;
        }

        var files = Directory.GetFiles(path);
        foreach (var filePath in files)
        {
            var result = new RenameResult();
            try
            {
                string? dir = Path.GetDirectoryName(filePath);
                string? name = Path.GetFileNameWithoutExtension(filePath);
                string? ext = Path.GetExtension(filePath);


                string newName = suffix?.StartsWith("_") == true
                    ? newName = $"{name}{suffix}{ext}"
                    : newName = $"{suffix}{name}{ext}";


                string newPath = Path.Combine(dir!, newName);

                File.Move(filePath, newPath);

                result.OriginalName = name + ext;
                result.NewName = newName;
                result.Success = true;
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