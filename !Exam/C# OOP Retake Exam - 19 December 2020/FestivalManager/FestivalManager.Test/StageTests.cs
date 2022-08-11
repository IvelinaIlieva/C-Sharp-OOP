// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    //using Entities;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Performer performer1;
        private Performer performer2;
        private Song song1;
        private Song song2;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();

            this.performer1 = new Performer("Magi", "Simon", 20);
            this.performer2 = new Performer("Peter", "Andrews", 60);

            this.song1 = new Song("La-La-La", TimeSpan.MaxValue);
            this.song2 = new Song("Hello", TimeSpan.FromDays(20));
        }

        [Test]
        public void ConstructorShouldCreateAStageCorrectly()
        {
            //Act
            Stage stageTest = new Stage();

            //Assert
            Assert.IsNotNull(stageTest);
        }

        [Test]
        public void AddPerformerShouldAddAPerformerWhoIsOver18YearsOld()
        {
            //Act
            this.stage.AddPerformer(this.performer1);

            List<Performer> expectedList = new List<Performer> { this.performer1 };

            //Assert
            Assert.AreEqual(1, this.stage.Performers.Count);
            CollectionAssert.AreEqual(expectedList, this.stage.Performers);
        }

        [Test]
        public void AddPerformerShouldThrowAnExceptionWhenPerformerIsUnder18YearsOld()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Performer performer = new Performer("Lily", "Collins", 15);
                this.stage.AddPerformer(performer);
            }, "You can only add performers that are at least 18.");
        }

        [Test]

        public void AddPerformerShouldThrowAnExceptionWhenPerformerIsNull()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Performer performer = null;
                this.stage.AddPerformer(performer);
            }, "Can not be null!");
        }

        [Test]
        public void AddSongShouldThrowAnExceptionWhenSongIsUnder1Minute()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Song song = new Song("Lily", TimeSpan.MinValue);
                this.stage.AddSong(song);
            }, "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void AddSongShouldThrowAnExceptionWhenSongIsNull()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Song song = null;
                this.stage.AddSong(song);
            }, "Can not be null!");
        }

        [Test]
        public void AddSongToPerformerShouldAddASongToPerformerCorrectly()
        {
            //Arrange
            this.stage.AddPerformer(this.performer1);
            this.stage.AddSong(this.song1);
            
            //Act
            string expectedResult = $"{this.song1} will be performed by {this.performer1}";
            string actualResult = this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddSongToPerformerShouldThrowAnExceptionWhenPerformerOrSongDoesNotExist()
        {
            //Arrange
            this.stage.AddPerformer(this.performer1);
            this.stage.AddSong(this.song1);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer(this.song1.Name, this.performer2.FullName);
            }, "There is no performer with this name.");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer(this.song2.Name, this.performer1.FullName);
            }, "There is no song with this name.");
        }

        [Test]
        public void PlayShouldReturnStatsCorrectly()
        {
            //Arrange
            this.stage.AddPerformer(this.performer1);
            this.stage.AddPerformer(this.performer2);
            this.stage.AddSong(this.song1);
            this.stage.AddSong(this.song2);

            this.stage.AddSongToPerformer(this.song1.Name, this.performer1.FullName);
            this.stage.AddSongToPerformer(this.song2.Name, this.performer1.FullName);

            //Act
            string expectedResult = "2 performers played 2 songs";
            string actualResult = this.stage.Play();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}