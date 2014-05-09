using System.Diagnostics;
using System.IO;

namespace open.openers
{
    public abstract class Opener {
        abstract public bool CanProcess(string option);
        abstract protected string GetCommand();

        public void Open(string target) {
            var info = new FileInfo(target);

            if (!info.Exists) {
                info = new FileInfo(Path.Combine(".", target));
            }
            
            Process.Start(GetCommand(), info.FullName);
        }
    }

    public class Explorer : Opener {
        public override bool CanProcess(string option)
        {
            return option == null;
        }

        protected override string GetCommand()
        {
            return "explorer";    
        }
    }

    public class Editor : Opener
    {
        public override bool CanProcess(string option)
        {
            return !string.IsNullOrEmpty(option) && option.Equals("-e", System.StringComparison.CurrentCultureIgnoreCase);
        }

        protected override string GetCommand()
        {
            var editor = System.Environment.GetEnvironmentVariable("EDITOR");
            if (string.IsNullOrEmpty(editor)) {
                return "notepad.exe";
            }
            return editor;
        }
    }

}
