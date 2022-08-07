using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository repo;
    private Hero hero;
    private Hero badHero;

    [SetUp]
    public void SetUp()
    {
        this.repo = new HeroRepository();

        this.hero = new Hero("Hero", 10);
        this.badHero = new Hero("BadHero", 20);
    }

    [TestCase("Hero", 5)]
    [TestCase("", 0)]
    [TestCase(null, -5)]
    public void ConstructorOfHeroShouldCreateAHeroCorrectly(string name, int level)
    {
        //Act
        Hero hero = new Hero(name, level);

        string expectedName = name;
        string actualName = hero.Name;

        int expectedLevel = level;
        int actualLevel = hero.Level;

        //Assert
        Assert.AreEqual(expectedName, actualName);
        Assert.AreEqual(expectedLevel, actualLevel);
    }

    [Test]
    public void ConstructorOfHeroRepositoryShouldCreateARepoCorrectly()
    {
        //Act
        HeroRepository heroRepository = new HeroRepository();

        //Assert
        Assert.IsNotNull(heroRepository);
    }

    [Test]
    public void CreateMethodShouldReturnCorrectStringWithValidHeroAdded()
    {
        //Act
        string expectedText = $"Successfully added hero {this.hero.Name} with level {this.hero.Level}";
        string actualText = this.repo.Create(this.hero);

        int expectedCount = 1;
        int actualCount = this.repo.Heroes.Count;

        //Assert
        Assert.AreEqual(expectedText, actualText);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void CreateMethodShouldThrowAnExceptionWhenAddANullHero()
    {
        //Act and Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            string result = this.repo.Create(null);
        }, "Hero is null");
    }

    [Test]
    public void CreateMethodShouldThrowAnExceptionWhenThisHeroAlreadyExist()
    {
        //Act
        string result = this.repo.Create(this.hero);

        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            string actualText = this.repo.Create(this.hero);
        }, $"Hero with name {this.hero.Name} already exists");
    }

    [Test]
    public void RemoveMethodShouldRemoveCorrectlyWithExistingHero()
    {
        //Arrange
        this.repo.Create(this.hero);

        //Assert
        Assert.IsTrue(this.repo.Remove(this.hero.Name));
        Assert.AreEqual(this.repo.Heroes.Count, 0);
    }

    [Test]
    public void RemoveMethodShouldThrowAnExceptionWithHeroWithNullOrWhitespaceName()
    {
        //Arrange
        this.repo.Create(this.hero);

        //Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repo.Remove(null);
        }, "Name cannot be null");

        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repo.Remove("");
        }, "Name cannot be null");

        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repo.Remove(" ");
        }, "Name cannot be null");
    }

    [Test]
    public void GetHeroWithHighestLevelMethodShouldReturnCorrectHero()
    {
        //Arrange
        this.repo.Create(this.hero);
        this.repo.Create(this.badHero);

        //Act
        string expectedHeroName = this.badHero.Name;
        string actualHeroName = this.repo.GetHeroWithHighestLevel().Name;

        int expectedHeroLevel = this.badHero.Level;
        int actualLevel = this.repo.GetHeroWithHighestLevel().Level;

        //Assert
        Assert.AreEqual(expectedHeroName, actualHeroName);
        Assert.AreEqual(expectedHeroLevel, actualLevel);
    }

    [Test]
    public void GetHeroMethodShouldReturnCorrectHero()
    {
        //Arrange
        this.repo.Create(this.badHero);

        //Act
        string expectedHeroName = this.badHero.Name;
        string actualHeroName = this.repo.GetHero(this.badHero.Name).Name;

        int expectedHeroLevel = this.badHero.Level;
        int actualLevel = this.repo.GetHero(this.badHero.Name).Level;

        //Assert
        Assert.AreEqual(expectedHeroName, actualHeroName);
        Assert.AreEqual(expectedHeroLevel, actualLevel);
    }
}