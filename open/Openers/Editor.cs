using open.Util;

namespace open.Openers
{
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
            if (string.IsNullOrEmpty(editor))
            {
                return "notepad.exe";
            }
            return editor;
        }
    }
}
