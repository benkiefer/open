using open;
using open.Util;
using Moq;
using NUnit.Framework;
using System.IO;

namespace open.Test.openers
{
    [TestFixture]
    public class ExplorerTest
    {
        private const string Target = "blah";
        private Explorer _explorer;
        private Mock<IProcessRunner> _mockProcessRunner;

        [SetUp]
        public void SetUp() {
            _mockProcessRunner = new Mock<IProcessRunner>();
            _explorer = new Explorer(_mockProcessRunner.Object);
        }
        
        [Test]
        public void CanProcess() {
            Assert.IsTrue(_explorer.CanProcess(null));
        }

        [Test]
        public void CanProcess_InvalidCommand()
        {
            Assert.IsFalse(_explorer.CanProcess("blah"));
        }

        [Test]
        public void Process()
        {
            _explorer.Open(Target);

            var path = new FileInfo(Path.Combine(".", Target));

            _mockProcessRunner.Verify(x => x.Run("explorer", path.FullName));
        }
    }
}
