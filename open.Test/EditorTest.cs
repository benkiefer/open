using open.Util;
using NUnit.Framework;
using Moq;

namespace open.Test.Opener
{
    [TestFixture]
    public class EditorTest
    {
        private Editor _editor;
        private Mock<IProcessRunner> _mockProcessRunner;

        [SetUp]
        public void SetUp()
        {
            _mockProcessRunner = new Mock<IProcessRunner>();
            _editor = new Editor(_mockProcessRunner.Object);
        }

        [Test]
        public void CanProcess()
        {
            Assert.IsTrue(_editor.CanProcess("-e"));
        }

        [Test]
        public void CanProcess_IncorrectCommand()
        {
            Assert.IsFalse(_editor.CanProcess("-b"));
        }

        [Test]
        public void CanProcess_HandleNull()
        {
            Assert.IsFalse(_editor.CanProcess(null));
        }

    }
}

