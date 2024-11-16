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
        public void IntegrationTest(int numOfPrisoners)
        {
            Tunde t = new Tunde(numOfPrisoners);
            t.RunSimulation();
            int expected = 0;
            for (int i = 0; i < t.isTurn.Length; i++)
            {
                if (t.isTurn[i]) { expected++; }
            }

            Assert.That(expected, Is.EqualTo(numOfPrisoners));
        }
    }
}