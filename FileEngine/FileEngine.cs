using FileEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace FileEngine
{
    public enum FileEventType
    {
        Rename,
        Undo
    }

    public class RenameResult
    {
        public string OriginalName { get; set; } = "";
        public string NewName { get; set; } = "";
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

    }

    public class RenameHistory
    {
        private static RenameHistory? _instance;
        public static RenameHistory Instance => _instance ??= new RenameHistory();

        public List<RenameResult> History { get; } = new List<RenameResult>();

        public void Add(RenameResult result)
        {
            History.Add(result);
        }

        public void Clear()
        {
            History.Clear();
        }

        public RenameResult? GetLast()
        {

            if (History.Count == 0)
                return null;
            var last = History[^1];
            History.RemoveAt(History.Count - 1);
            return last;
        }
        public RenameResult? PeekLast()
        {
            return History.Count > 0 ? History[^1] : null;
        }

    }

    public class FileHandler
    {
        public static bool IsValidSuffix(string suffix) =>
            suffix.StartsWith("_") || suffix.EndsWith("_");

        public static string FormatNewName(string name, string suffix, int number, FileEventType event_t, string ext) =>
            $"{name}_{suffix}_{number.ToString("D4")}_{event_t.ToString()}{ext}";

        public static bool IsValidPath(string path) =>
            Directory.Exists(path);

        private static readonly Dictionary<FileEventType, IFileEventHandler> handlers = new()
        {
            { FileEventType.Rename, new RenameHandler() },
            { FileEventType.Undo, new UndoHandler() },


        };

        public static List<RenameResult> FileEvent(string path, string suffix, string extension, FileEventType eventType)
        {
            if (!IsValidPath(path))
            {
                return new List<RenameResult> {
            new RenameResult { Success = false, ErrorMessage = $"❌ Invalid Path: {path}" }
        };
            }

            var files = Directory.GetFiles(path);

            if (!handlers.TryGetValue(eventType, out var handler))
            {
                return new List<RenameResult> {
            new RenameResult { Success = false, ErrorMessage = $"❌ No handler for event: {eventType}" }
        };
            }

            return handler.Execute(files, suffix, extension);
        }


    }
}