using System.Diagnostics;
using System.IO;
using open.Util;

namespace open.Openers
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
}
