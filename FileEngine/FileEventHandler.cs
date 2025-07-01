using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileEngine.FileHandler;

namespace FileEngine
{
    public interface IFileEventHandler
    {
        List<RenameResult> Execute(string[] files, string suffix, string extension);
    }
}
