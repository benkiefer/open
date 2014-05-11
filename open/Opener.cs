using System.Diagnostics;
using System.IO;
using open.Util;

namespace open
{
    public abstract class Opener {
        private IProcessRunner _processRunner;

        public Opener(IProcessRunner processRunner)
        {
            _processRunner = processRunner;
        }

        abstract public bool CanProcess(string option);
        abstract protected string GetCommand();

        public void Open(string target) {
            var info = new FileInfo(target);

            if (!info.Exists) {
                info = new FileInfo(Path.Combine(".", target));
            }

            _processRunner.Run(GetCommand(), info.FullName);
        }
    }

    public class Explorer : Opener {

        public Explorer(IProcessRunner processRunner)
            : base(processRunner)
        { }

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
        public Editor(IProcessRunner processRunner)
            : base(processRunner)
        { }

        public override bool CanProcess(string option)
        {
            return !string.IsNullOrEmpty(option) && option.Equals("-e");
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
