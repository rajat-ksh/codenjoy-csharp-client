﻿using NUnit.Framework;
using System;

namespace Dojo.Games.Clifford.Tests
{
    [TestFixture]
    [Category("clifford")]
    public class BoardTests
    {
        [Test]
        public void Test_IsGameOver()
        {
            var board = new CliffordBoard("#####►###");
            Assert.False(board.IsGameOver);

            board = new CliffordBoard("###Ѡ#####");
            Assert.True(board.IsGameOver);

            board = new CliffordBoard("###x#####");
            Assert.True(board.IsGameOver);
        }

        [Test]
        public void Test_FindHero()
        {
            var board = new CliffordBoard("Ѡ########");
            Assert.AreEqual(new Point(0, 2), board.GetHero());

            board = new CliffordBoard("###Y#####");
            Assert.AreEqual(new Point(0, 1), board.GetHero());

            board = new CliffordBoard("####◄####");
            Assert.AreEqual(new Point(1, 1), board.GetHero());

            board = new CliffordBoard("#####►###");
            Assert.AreEqual(new Point(2, 1), board.GetHero());

            board = new CliffordBoard("######]##");
            Assert.AreEqual(new Point(0, 0), board.GetHero());

            board = new CliffordBoard("########{");
            Assert.AreEqual(new Point(2, 0), board.GetHero());

            board = new CliffordBoard("########⍃");
            Assert.AreEqual(new Point(2, 0), board.GetHero());

            board = new CliffordBoard("⍃Ѡ Y◄►]{ ");
            Assert.AreEqual(new Point(0, 0), board.GetHero());
        }

        [Test]
        public void Test_FindMaskHero()
        {
            var board = new CliffordBoard("x########");
            Assert.AreEqual(new Point(0, 2), board.GetHero());

            board = new CliffordBoard("###⍬#####");
            Assert.AreEqual(new Point(0, 1), board.GetHero());

            board = new CliffordBoard("####⊲####");
            Assert.AreEqual(new Point(1, 1), board.GetHero());

            board = new CliffordBoard("#####⊳###");
            Assert.AreEqual(new Point(2, 1), board.GetHero());

            board = new CliffordBoard("######⊅##");
            Assert.AreEqual(new Point(0, 0), board.GetHero());

            board = new CliffordBoard("########⋜");
            Assert.AreEqual(new Point(2, 0), board.GetHero());

            board = new CliffordBoard("########ᐊ");
            Assert.AreEqual(new Point(2, 0), board.GetHero());

            board = new CliffordBoard("⍃Ѡ Y◄►]{ ");
            Assert.AreEqual(new Point(0, 0), board.GetHero());
        }

        [Test]
        public void Test_FindHero_NoResult()
        {
            var board = new CliffordBoard("#########");

            var ex = Assert.Throws<NullReferenceException>(() => board.GetHero());
            Assert.That(ex.Message, Is.EqualTo("Hero element has not been found."));
        }

        [Test]
        public void Test_GetOtherHeroes()
        {
            var board = new CliffordBoard("Z( U) ᗉЭ⊐");
            CollectionAssert.AreEquivalent(new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2),
                new Point(2, 0)},
                board.GetOtherHeroes());

            board = new CliffordBoard("⋈⋣ ⋊⋉ ⊣ᗏ⋕");
            CollectionAssert.AreEquivalent(new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2),
                new Point(2, 0)},
                board.GetOtherHeroes());
        }

        [Test]
        public void Test_GetEnemyHeroes()
        {
            var board = new CliffordBoard("Ž❪ Ǔ❫ ⋥Ǯ⇇");
            CollectionAssert.AreEquivalent(new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2),
                new Point(2, 0)},
                board.GetEnemyHeroes());

            board = new CliffordBoard("⧓⬱ ≠⧒ ⌫❵⧑");
            CollectionAssert.AreEquivalent(new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2),
                new Point(2, 0)},
                board.GetEnemyHeroes());
        }

        [Test]
        public void Test_GetRobbers()
        {
            var board = new CliffordBoard("Q« ‹< »⍇ ");
            CollectionAssert.AreEquivalent(new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2)},
                board.GetRobbers());
        }

        [Test]
        public void Test_GetBarriers()
        {
            var board = new CliffordBoard("  #  ☼   ");
            CollectionAssert.AreEquivalent(
                new[] { new Point(2, 1), new Point(2, 2) },
                board.GetBarriers());
        }

        [Test]
        public void Test_GetPits()
        {
            var board = new CliffordBoard("1234**###");
            CollectionAssert.AreEquivalent(
                new[] { new Point(0, 1), new Point(0, 2), new Point(1, 1),
                new Point(1, 2), new Point(2, 1), new Point(2, 2) },
                board.GetPits());
        }

        [Test]
        public void Test_GetClues()
        {
            var board = new CliffordBoard("##$##&##@");
            CollectionAssert.AreEquivalent(
                new[] { new Point(2, 0), new Point(2, 1), new Point(2, 2) },
                board.GetClues());
        }

        [Test]
        public void Test_GetBackways()
        {
            var board = new CliffordBoard("##⊛######");
            CollectionAssert.AreEquivalent(
                new[] { new Point(2, 2) },
                board.GetBackways());
        }

        [Test]
        public void Test_GetPotions()
        {
            var board = new CliffordBoard("##S######");
            CollectionAssert.AreEquivalent(
                new[] { new Point(2, 2) },
                board.GetPotions());
        }

        [Test]
        public void Test_GetDoors()
        {
            var board = new CliffordBoard("⍙⍚⍜⍍⌺⌼###");
            CollectionAssert.AreEquivalent(
                new[] { new Point(0, 1), new Point(0, 2), new Point(1, 1),
                new Point(1, 2), new Point(2, 1), new Point(2, 2) },
                board.GetDoors());
        }

        [Test]
        public void Test_GetOpenDoors()
        {
            var board = new CliffordBoard("⍙⍚⍜######");
            CollectionAssert.AreEquivalent(
                new[] { new Point(0, 2), new Point(1, 2), new Point(2, 2) },
                board.GetOpenDoors());
        }

        [Test]
        public void Test_GetCloseDoors()
        {
            var board = new CliffordBoard("⍍⌺⌼######");
            CollectionAssert.AreEquivalent(
                new[] { new Point(0, 2), new Point(1, 2), new Point(2, 2) },
                board.GetCloseDoors());
        }

        [Test]
        public void Test_GetKeys()
        {
            var board = new CliffordBoard("✦✼⍟######");
            CollectionAssert.AreEquivalent(
                new[] { new Point(0, 2), new Point(1, 2), new Point(2, 2) },
                board.GetKeys());
        }

        [Test]
        public void Test_Report()
        {
            var board = new CliffordBoard("board=" +
                      "☼☼☼☼☼☼☼☼☼" +
                      "☼ ►*## $☼" +
                      "☼ H ⧒⧒ ✼☼" +
                      "☼ H  1 ⍍☼" +
                      "☼S   &  ☼" +
                      "☼ ✦ ~~~ ☼" +
                      "☼Z3 ⌺   ☼" +
                      "☼ @@  Q ☼" +
                      "☼☼☼☼☼☼☼☼☼");
            Assert.AreEqual("☼☼☼☼☼☼☼☼☼\n" +
                         "☼ ►*## $☼\n" +
                         "☼ H ⧒⧒ ✼☼\n" +
                         "☼ H  1 ⍍☼\n" +
                         "☼S   &  ☼\n" +
                         "☼ ✦ ~~~ ☼\n" +
                         "☼Z3 ⌺   ☼\n" +
                         "☼ @@  Q ☼\n" +
                         "☼☼☼☼☼☼☼☼☼\n" +
            "\n" +
            "Hero at: [2,7]\n"+
            "Other heroes at: [1,2]\n"+
            "Enemy heroes at: [4,6],[5,6]\n"+
            "Robbers at: [6,1]\n"+
            "Mask potions at: [1,4]\n"+
            "Keys at: [2,3],[7,6]", board.ToString());
        }
    }
}
