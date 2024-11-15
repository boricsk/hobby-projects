using EledilsLight;

namespace ElendilsLightTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        //[TestCase(int.MaxValue)]
        public void CreateInstanceTest(int NumOfPirsoners)
        {
            Tunde t = new Tunde(NumOfPirsoners);
            //Assert.AreEqual(NumOfPirsoners, t.NumberOfPrisoners);
            Assert.That(NumOfPirsoners, Is.EqualTo(t.NumberOfPrisoners));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        //[TestCase(int.MaxValue)]
        public void ArrayLenTest(int NumOfPirsoners)
        {
            Tunde t = new Tunde(NumOfPirsoners);
            //Assert.AreEqual(NumOfPirsoners, t.NumberOfPrisoners);
            Assert.That(NumOfPirsoners, Is.EqualTo(t.isTurn.Length));
            Assert.That(NumOfPirsoners, Is.EqualTo(t.NumberOfWalks.Length));
            Assert.That(t.isTurn.Length, Is.EqualTo(t.NumberOfWalks.Length));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void CounterIncrementTest(int iteration)
        {
            Tunde t = new Tunde(10);
            
            for (int i = 0; i < iteration; i++)
            {
                if (i % 2 == 0) { t.stateOfLamp = true; } else { t.stateOfLamp = false; }
            }

            Assert.That(iteration, Is.EqualTo(t.Count));
        }
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void CounterNoIncrementTest(int iteration)
        {
            Tunde t = new Tunde(10);
            int expected = 0;
            for (int i = 0; i < iteration; i++)
            {
                t.stateOfLamp = false;
            }

            Assert.That(expected, Is.EqualTo(t.Count));
        }
    }
}