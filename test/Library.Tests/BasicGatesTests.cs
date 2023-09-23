using Library.BasicGates;

namespace Library.Tests
{
    /// <summary>
    /// Prueba el correcto funcionamiento de las compuertas lógicas básicas.
    /// </summary>
    public class BasicGatesTests
    {
        /// <summary>
        /// Prueba compuerta AND usando otra compuerta AND y dos variables simples.
        /// </summary>
        [Test]
        public void TestAndGate()
        {
            // ***ARRANGE_1
            // Variables simples.
            SimpleVariable a = new SimpleVariable("A", true);
            SimpleVariable b = new SimpleVariable("B", true);

            // Compuertas lógicas AND.
            AndGate auxiliarAndGate = new AndGate("Compuerta AND auxiliar");
            AndGate andGateToTest = new AndGate("Compuerta AND");

            bool expectedResult1 = true;

            // ***ACT_1
            auxiliarAndGate.AddInput(a);
            auxiliarAndGate.AddInput(b);
            andGateToTest.AddInput(a);
            andGateToTest.AddInput(auxiliarAndGate);

            bool actualResult1 = andGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult1, actualResult1);

            // ***ARRANGE_2
            a.Value = false;

            bool expectedResult2 = false;

            // ***ACT_2
            bool actualResult2 = andGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult2, actualResult2);
        }

        /// <summary>
        /// Prueba compuerta OR usando otra compuerta OR y dos variables simples.
        /// </summary>
        [Test]
        public void TestOrGate()
        {
            // ***ARRANGE_1
            // Variables simples.
            SimpleVariable a = new SimpleVariable("A", false);
            SimpleVariable b = new SimpleVariable("B", true);

            // Compuertas lógicas OR.
            OrGate auxiliarOrGate = new OrGate("Compuerta OR auxiliar");
            OrGate orGateToTest = new OrGate("Compuerta OR");

            bool expectedResult1 = true;

            // ***ACT_1
            auxiliarOrGate.AddInput(a);
            auxiliarOrGate.AddInput(b);
            orGateToTest.AddInput(a);
            orGateToTest.AddInput(auxiliarOrGate);

            bool actualResult1 = orGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult1, actualResult1);

            // ***ARRANGE_2
            a.Value = false;
            b.Value = false;

            bool expectedResult2 = false;

            // ***ACT_2
            bool actualResult2 = orGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult2, actualResult2);
        }

        /// <summary>
        /// Prueba compuerta OR usando otra compuerta NOT y una variable simple.
        /// </summary>
        [Test]
        public void TestNotGate()
        {
            // ***ARRANGE_1
            SimpleVariable a = new SimpleVariable("A", true);

            NotGate notGateToTest = new NotGate("Compuerta NOT");

            bool expectedResult1 = false;

            // ***ACT_1
            notGateToTest.AddInput(a);

            bool actualResult1 = notGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult1, actualResult1);

            // ***ARRANGE_2
            a.Value = false;

            NotGate auxiliarNotGate = new NotGate("Compuerta auxiliar");

            bool expectedResult2 = false;

            // ***ACT_2
            notGateToTest.RemoveInput(a);
            notGateToTest.AddInput(auxiliarNotGate);

            auxiliarNotGate.AddInput(a);

            bool actualResult2 = notGateToTest.CalculateInput();

            // ***ASSERT_1
            Assert.AreEqual(expectedResult2, actualResult2);
        }
    }
}

