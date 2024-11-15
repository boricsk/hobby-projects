using EledilsLight;

namespace ExceptionTest
{
    [TestClass]
    public class ExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void ExceptionTest_CreateInstance()
        {
            Tunde t = new Tunde(-1);
        }
    }
}