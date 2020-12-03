using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YoutubeDownloader.Core.Utils;

namespace YoutubeDownloader.Core.Tests.Utils
{
    [TestClass]
    public class FilenameFixerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataTestMethod]
        [DataRow(null, null)]
        [DataRow("", null)]
        [DataRow(null, "")]
        [DataRow("", "")]
        [DataRow("filename.flv", "")]
        [DataRow("filename.flv", null)]
        public void FilenameFixer_ThrowsExceptionWhenPassingNullOrEmptyArguments(string filename, string path)
        {
            // Arrange
            // Act
            var fixer = new FilenameFixer(filename, path);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void GetFilename_ShouldMatch()
        {
            // Arrange
            var expected = @"C:\temp\This is my filename.mp4";
            var fixer = new FilenameFixer("This is my filename.mp4", "C:\\temp");

            // Act
            var actual = fixer.GetFilename();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFilename_ShouldMatchWhenPassedInvalidChars()
        {
            // Arrange
            var expected = @"C:\temp\This is my filename.mp4";
            var fixer = new FilenameFixer("This is my >>filename<<.mp4", "C:\\temp\"");

            // Act
            var actual = fixer.GetFilename();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}