using open.Util;
using NUnit.Framework;
using Moq;
using System.IO;

namespace open.Test.Opener
{
    [TestFixture]
    public class EditorTest
    {
        private const string Target = "blah";
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

        [Test]
        public void Process()
        {
            _editor.Open(Target);

            var path = new FileInfo(Path.Combine(".", Target));

            _mockProcessRunner.Verify(x => x.Run(Editor(), path.FullName));
        }

        private string Editor()
        {
            var editor = System.Environment.GetEnvironmentVariable("EDITOR");
            if (string.IsNullOrEmpty(editor))
            {
                editor = "notepad.exe";
            }
            return editor;
        }
    }
}

