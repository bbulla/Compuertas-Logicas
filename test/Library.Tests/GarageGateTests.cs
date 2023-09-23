
namespace Library.Tests
{
    /// <summary>
    /// Prueba que la puerta de garage esté abierta o cerrada en los casos correctos.
    /// </summary>
    public class GarageGateTests
    {
        [SetUp]
        public void SetUp()
        {
            // Ordena las compuertas y variables simples que conoce para formar el circuito de la foto.
            GarageGate.SetGarageGate();
        }

        /// <summary>
        /// Prueba que la puerta esté abierta en los casos esperados.
        /// </summary>
        [Test]
        public void TestWhenGarageGateIsOpen()
        {
            // ***ARRANGE
            bool expectedResult = true;

            // ***ACT_1 (CBA = 100)
            GarageGate.ChangeCValue(true);
            GarageGate.ChangeBValue(false);
            GarageGate.ChangeAValue(false);

            bool actualResult = GarageGate.ItIsOpen();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult, actualResult);


            // ***ACT_2 (CBA = 111)
            GarageGate.ChangeCValue(true);
            GarageGate.ChangeBValue(true);
            GarageGate.ChangeAValue(true);

            actualResult = GarageGate.ItIsOpen();

            // ***ASSERT_2
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Prueba que la puerta esté cerrada en los casos esperados.
        /// </summary>
        [Test]
        public void TestWhenGarageGateIsClose()
        {
            // ***ARRANGE
            bool expectedResult = false;

            // Una matriz booleana para sintetizar mejor el código.
            bool[,] falseCases = new bool[6, 3]
            {
                //CBA
                {false, false, false},  //000 
                {false, false, true},   //001
                {false, true, false},   //010
                {false, true, true},    //011
                {true, false, true},    //101
                {true, true, false},    //110
            };
            bool actualResult;

            for (int row = 0; row < 6; row++)
            {
                // ***ACT
                GarageGate.ChangeCValue(falseCases[row, 0]);
                GarageGate.ChangeBValue(falseCases[row, 1]);
                GarageGate.ChangeAValue(falseCases[row, 2]);
                actualResult = GarageGate.ItIsOpen();

                // ***ASSERT
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
