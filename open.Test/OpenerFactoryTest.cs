using Moq;
using open.Util;
using NUnit.Framework;
using open.Openers;
using System;

namespace open.Test
{
    [TestFixture]
    public class OpenerFactoryTest
    {
        private OpenerFactory factory;
        private Mock<IProcessRunner> mockProcessRunner;

        [SetUp]
        public void SetUp() {
            mockProcessRunner = new Mock<IProcessRunner>();
            factory = new OpenerFactory(mockProcessRunner.Object);
        }

        [Test]
        public void GetOpeners() {
            Assert.IsAssignableFrom<Explorer>(factory.GetOpeners()[0]);
            Assert.IsAssignableFrom<Editor>(factory.GetOpeners()[1]);
        }

    }
}
