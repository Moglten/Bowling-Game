using System;
using System.Net.NetworkInformation;
using BowlingGame;
using NUnit.Framework;
using FluentAssertions;

namespace UnitTests_BowlingGame
{

    [TestFixture]
    public class BowlingGameTest
    {

        private BowlingGameYard game;

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGameYard();
        }

        //Helper Function
        private void RollMany(int n,int pins)
        {
            for (var i = 0; i < n; i++)
            {
                game.roll(pins);
            }
        }

        private void RollSpare()
        {
            game.roll(5);
            game.roll(5);
        }


        private void RollStrike()
        {
            game.roll(10);
        }

        //========================================
        //Tests
        //To write initial code
        [Test]
        public void CanRoll()
        {
            game.roll(0);
        }

        [Test]
        public void GutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(game.score() , 0);   
        }

        [Test]
        public void AllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(game.score(), 20);
        }

        [Test]
        public void OneSpare()
        {
            RollSpare();
            game.roll(3);
            RollMany(17, 0);
           
            Assert.AreEqual(game.score() ,16);
        }

        [Test]
        public void MultipleSpare()
        {
            RollSpare();
            RollSpare();
            game.roll(1);
            RollMany(15, 0);

            Assert.AreEqual(game.score(), 27);
        }

         
        [Test]
        public void OneStrike()
        {
            RollStrike();
            game.roll(3);
            game.roll(4);
            RollMany(16, 0);

            Assert.AreEqual(game.score() , 24);
        }

        [Test]
        public void perfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(game.score(), 300);
        }

    }
}
