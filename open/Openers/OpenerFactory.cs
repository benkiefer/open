using System;
using System.Collections.Generic;
using open.Util;

namespace open.Openers
{
    public class OpenerFactory
    {
        private List<Opener> openers;

        public OpenerFactory():
            this(new ProcessRunner())
        {
        }

        public OpenerFactory(IProcessRunner processRunner)
        {
            openers = new List<Opener> {
                new Explorer(processRunner),
                new Editor(processRunner)
            };

        }

        public List<Opener> GetOpeners() { 
            return openers;
        }
    }
}
