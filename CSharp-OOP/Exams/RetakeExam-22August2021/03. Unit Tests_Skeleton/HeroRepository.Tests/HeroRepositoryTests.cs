using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private const string name = "name";
    private const int level = 1;
    private HeroRepository repository;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero(name, level);
        repository = new HeroRepository();
    }

    [Test]
    public void ConstructorWorks()
    {
        Assert.True(hero.Name == name && hero.Level == level);
    }

    [Test]
    public void CreateThrowsForNullHero()
    {
        Assert.Throws<ArgumentNullException>(()=> repository.Create(null));
    }

    [Test]
    public void CreateThrowsForExistingName()
    {
        repository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => repository.Create(new Hero(name, 1)));
    }

    [Test]
    public void CreateCreatesAHeroAndAddsIt()
    {
        repository.Create(hero);
        Assert.AreEqual(repository.Heroes.Count,1);
        Assert.AreSame(repository.Heroes.First(), hero);
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void RemoveThrowsWhenNullOrWhiteSpace(string name1)
    {
        Assert.Throws<ArgumentNullException>(() => repository.Remove(name1));
    }

    [Test]
    public void RemoveRemovesFromTheCollection()
    {
        repository.Create(hero);
        bool removed = repository.Remove(hero.Name);
        Assert.AreEqual(repository.Heroes.Count, 0);
        Assert.IsTrue(removed);
    }

    [Test]
    public void GetHeroWithHighestLevelReturnsCorrectHero()
    {
        Hero hero1 = new Hero("name1", 5);
        Hero hero2 = new Hero("name2", 2);
        repository.Create(hero);
        repository.Create(hero1);
        repository.Create(hero2);
        var exp = new List<Hero>() { hero, hero1, hero2 }.OrderByDescending(x => x.Level).FirstOrDefault();
        Assert.AreEqual(exp, repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroGetsCorrectHero()
    {
        repository.Create(hero);
        Hero heroFound = repository.GetHero(hero.Name);
        Assert.AreSame(hero, heroFound);
    }
}