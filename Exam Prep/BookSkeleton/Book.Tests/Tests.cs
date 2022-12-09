namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        private string bookName = "Pod igoto";
        private string author = "Ivan Vazov";

        [SetUp]
        public void SetUp()
        {
            book = new Book(bookName, author);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(book.FootnoteCount, 0);
        }

        [Test]
        public void Test_BookName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(null, author);
            });
        }

        [Test]
        public void Test_Author()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(bookName, null);
            });
        }

        [Test]
        public void Test_AddFootNote()
        {
            book.AddFootnote(1, "Hi");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void Test_AddSameFootNote()
        {
            book.AddFootnote(1, "Hi");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Bye");
            });
        }

        [Test]
        public void Test_FindFootNote()
        {
            book.AddFootnote(1, "Hi");
            book.FindFootnote(1);

            string expectedResult = $"Footnote #{1}: {"Hi"}";
            string actualResult = this.book.FindFootnote(1);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_FindFootNoteDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(1);
            });
        }

        [Test]
        public void FindFootNoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.book.FindFootnote(1);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void Test_AlterFootNote()
        {
            int footKey = 1;
            string footText = "Text";
            this.book.AddFootnote(footKey, footText);

            string expectedText = "New text";
            this.book.AlterFootnote(footKey, expectedText);

            Type bookType = this.book.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> fieldValue = (Dictionary<int, string>)
                dictFieldInfo.GetValue(this.book);

            string actualText = fieldValue[footKey];
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void Test_AlterFootNoteThatExists()
        {
            book.AddFootnote(1, "Hi");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2);
            });
        }

        [Test]
        public void Test_TestCount()
        {
            Assert.AreEqual(0, book.FootnoteCount);
        }
    }
}