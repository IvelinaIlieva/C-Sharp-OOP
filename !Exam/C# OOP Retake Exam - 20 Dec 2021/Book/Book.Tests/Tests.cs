namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book1;

        [SetUp]
        public void SetUp()
        {
            this.book1 = new Book("Pod igoto", "Ivan Vazov");

        }

        [TestCase("Pod igoto", "Ivan Vazov")]
        [TestCase("Graf Monte Kristo", "Alexander Diuma")]
        [TestCase("  ", "  ")]
        public void ConstructorShouldCreateBookProperlyWithCorrectNamesOfBookAndAuthor(string name, string author)
        {
            //Assert
            Book book = new Book(name, author);

            //Act
            string expectedName = name;
            string actualName = book.BookName;

            string expectedAuthor = author;
            string actualAuthor = book.Author;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [TestCase(null, "Ivan Vazov")]
        [TestCase("", "Alexander Diuma")]
        public void BookSetterShouldShouldThrowAnExceptionWithBlankOrNullNameOfBook(string name, string author)
        {
            //Act and Assert 
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, author);
            }, $"Invalid {name}!");
        }

        [TestCase("Pod igoto", null)]
        [TestCase("Graf Monte Kristo", "")]
        public void BookSetterShouldShouldThrowAnExceptionWithBlankOrNullNameOfAuthor(string name, string author)
        {
            //Act and Assert 
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, author);
            }, $"Invalid {author}!");
        }

        [Test]
        public void AddFootnoteMethodShouldAddFootnoteOnExistingPageWhenNoteDoesNotExist()
        {
            //Act
            this.book1.AddFootnote(5, "Boycho Ognyanov");
            this.book1.AddFootnote(2, "Rada Gospozhina");

            int expectedCount = 2;
            int actualCount = this.book1.FootnoteCount;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddFootnoteMethodShouldThrowAnExceptionWhenAddFootnoteOnExistingPageWhenNoteAlreadyExist()
        {
            //Act
            this.book1.AddFootnote(5, "Boycho Ognyanov");
            this.book1.AddFootnote(2, "Rada Gospozhina");

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.book1.AddFootnote(5, "Rada Gospozhina");
            }, "Footnote already exists!");
        }

        [Test]
        public void FindFootnoteMethodShouldReturnFootnoteTextWhenNoteExist()
        {
            //Arrange
            this.book1.AddFootnote(5, "Boycho Ognyanov");
            
            //Act
            string expectedText = $"Footnote #5: Boycho Ognyanov";
            string actualText = this.book1.FindFootnote(5);

            //Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void FindFootnoteMethodShouldThrowAnExceptionWhenFootnoteDoesNotExist()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.book1.FindFootnote(5);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void AlterFootnoteMethodShouldChangeFootnoteTextWhenNoteExist()
        {
            //Arrange
            this.book1.AddFootnote(5, "Boycho Ognyanov");

            //Act
            this.book1.AlterFootnote(5, "Rada Gospozhina");

            string expectedText = $"Footnote #5: Rada Gospozhina";
            string actualText = this.book1.FindFootnote(5);

            //Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void AlterFootnoteMethodShouldThrowAnExceptionWhenFootnoteDoesNotExist()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.book1.AlterFootnote(5, "Rada Gospozhina");
            }, "Footnote doesn't exists!");
        }
    }
}