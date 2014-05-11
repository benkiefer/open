using System.Diagnostics;

namespace open.Util
{
    public interface IProcessRunner
    {
        void Run(string process, string cmd);
    }

    public class ProcessRunner : IProcessRunner {
        
        public void Run(string process, string cmd) {
            Process.Start(process, cmd);        
        }

    }

}
