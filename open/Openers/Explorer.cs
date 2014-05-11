using open.Util;

namespace open.Openers
{
    public class Explorer : Opener
    {

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
}
