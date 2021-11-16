﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Games.Mollymage.Tests
{
    [TestFixture]
    [Category("mollymage")]
    public class BoardTests
    {
        [Test]
        public void Test_GetAt_InvalidPoint()
        {
            var board = new MollymageBoard("#########");
            Assert.AreEqual(Element.WALL, board.GetAt(new Point(-1, -1)));
        }

        [Test]
        public void Test_FindHero()
        {
            var board = new MollymageBoard("#☺#######");
            Assert.AreEqual(new Point(1, 2), board.GetHero());

            board = new MollymageBoard("####☻####");
            Assert.AreEqual(new Point(1, 1), board.GetHero());

            board = new MollymageBoard("#######Ѡ#");
            Assert.AreEqual(new Point(1, 0), board.GetHero());

            board = new MollymageBoard("Ѡ☺☻######");
            Assert.AreEqual(new Point(0, 2), board.GetHero());
        }

        [Test]
        public void Test_FindHero_NoResult()
        {
            var board = new MollymageBoard("#########");

            var ex = Assert.Throws<NullReferenceException>(() => board.GetHero());
            Assert.That(ex.Message, Is.EqualTo("Hero element has not been found."));
        }

        [Test]
        public void Test_IsGameOver()
        {
            var board = new MollymageBoard("#####☺###");
            Assert.False(board.IsGameOver);

            board = new MollymageBoard("###Ѡ#####");
            Assert.True(board.IsGameOver);
        }

        [Test]
        public void Test_GetOtherHeroes()
        {
            var board = new MollymageBoard("#♥##♠##♣#");
            CollectionAssert.AreEqual(new[] { new Point(1, 0), new Point(1, 1), new Point(1, 2) }, board.GetOtherHeroes());
        }

        [Test]
        public void Test_GetEnemyHeroes()
        {
            var board = new MollymageBoard("#ö#" + "#Ö#" + "#ø#");
            CollectionAssert.AreEqual(new[] { new Point(1, 0), new Point(1, 1), new Point(1, 2) },
                board.GetEnemyHeroes());
        }


        [Test]
        public void Test_GetBarriers()
        {
            var board = new MollymageBoard("☼&#123♥♠♣");
            CollectionAssert.AreEqual(
                new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                    new Point(1, 0), new Point(1, 1), new Point(1, 2),
                    new Point(2, 0), new Point(2, 1), new Point(2, 2) },
                board.GetBarrier());
        }

        [Test]
        public void Test_GetWalls()
        {
            var board = new MollymageBoard("###☼##☼##");
            CollectionAssert.AreEqual(
                new[] { new Point(0, 0), new Point(0, 1) },
                board.GetWalls());
        }

        [Test]
        public void Test_GetGhosts()
        {
            var board = new MollymageBoard("##&##&###");

            CollectionAssert.AreEqual(
                new[] { new Point(2, 1), new Point(2, 2) },
                board.GetGhosts());
        }

        [Test]
        public void Test_GetTreasureBoxes()
        {
            var board = new MollymageBoard("҉#҉" + "҉҉҉" + "҉#҉");
            CollectionAssert.AreEqual(
                new[] { new Point(1, 0), new Point(1, 2) },
            board.GetTreasureBoxes());
        }

        [Test]
        public void Test_GetPotions()
        {
            var board = new MollymageBoard("12345#☻♠#");
            CollectionAssert.AreEqual(
                new[] { new Point(0, 0), new Point(0, 1), new Point(0, 2),
                new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 2) },
                board.GetPotions());
        }

        [Test]
        public void Test_GetBlasts()
        {
            var board = new MollymageBoard("########҉");
            CollectionAssert.AreEqual(
                    new[] { new Point(2, 0) }, 
                    board.GetBlasts());
        }

        [Test]
        public void Test_GetPerks()
        {
            var board = new MollymageBoard("#cr" + "#i+" + "#TA");
            CollectionAssert.AreEqual(
                new[] { new Point(1, 0), new Point(1, 1), new Point(1, 2),
                    new Point(2, 0), new Point(2, 1), new Point(2, 2) },
                board.GetPerks());
        }

        [Test]
        public void Test_Report()
        {
            var board = new MollymageBoard("board=" +
            "☼☼☼☼☼☼☼☼☼" +
            "☼1 ♣   ♠☼" +
            "☼#2  &  ☼" +
            "☼# 3 ♣ ♠☼" +
            "☼☺  4   ☼" +
            "☼   ö H☻☼" +
            "☼x H ҉҉҉☼" +
            "☼& &    ☼" +
            "☼☼☼☼☼☼☼☼☼");
        Assert.AreEqual("" +
            /*8*/ "☼☼☼☼☼☼☼☼☼\n" +
            /*7*/ "☼1 ♣   ♠☼\n" +
            /*6*/ "☼#2  &  ☼\n" +
            /*5*/ "☼# 3 ♣ ♠☼\n" +
            /*4*/ "☼☺  4   ☼\n" +
            /*3*/ "☼   ö H☻☼\n" +
            /*2*/ "☼x H ҉҉҉☼\n" +
            /*1*/ "☼& &    ☼\n" +
            /*0*/ "☼☼☼☼☼☼☼☼☼\n" +
            /*012345678*/
            "\n" +
            "Hero at: [1,4]\n" +
            "Other heroes at: [3,7],[5,5],[7,5],[7,7]\n" +
            "Enemy heroes at: [4,3]\n" +
            "Ghosts at: [1,1],[3,1],[5,6]\n" +
            "Treasure Boxes at: [1,5],[1,6]\n" +
            "Potions at: [1,7],[2,6],[3,5],[4,4],[7,3],[7,5],[7,7]\n" +
            "Blasts at: [5,2],[6,2],[7,2]\n" +
            "Expected blasts at: [2,7]", board.ToString());
        }
    }
}