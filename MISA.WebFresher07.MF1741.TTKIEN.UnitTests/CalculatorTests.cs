using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher07.MF1741.TTKIEN.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        #region Add TestCase
        /// <summary>
        /// Hàm unit test cộng hai số
        /// </summary>
        [TestCase(1, 2, 3)]
        [TestCase(1, -2, -1)]
        [TestCase(1, int.MaxValue, (long)1 + int.MaxValue)]
        public void Add_ValidInput_Sum2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Add(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm unit test hàm test khi truyền vào chuỗi đúng định dạng
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="expectedResult"></param>
        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3", 6)]
        [TestCase("2", 2)]
        [TestCase("15", 15)]
        [TestCase("", 0)]
        public void Add_String_SumNumberInString(string inputString, int expectedResult)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var actualResult = calculator.Add(inputString);

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm unit test hàm add khi truyền vào chuỗi có toán hạng âm
        /// </summary>
        [Test]
        public void Add_NegativeOperand_ThrowException()
        {
            //Arrange
            var inputString = "1,-2,-3";
            var expectedMessage = "Không chấp nhận toán hạng âm: -2, -3";

            var calculator = new Calculator();

            //Act & Assert
            try
            {
                var actualResult = calculator.Add(inputString);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        [TestCase("[1]", "Đầu vào không đúng định dạng.")]
        [TestCase("1, a", "Đầu vào không đúng định dạng.")]
        public void Add_WrongFormatInput_ThrowException(string inputString, string expectedMessage)
        {
            //Arrange
            var calculator = new Calculator();

            //Act & Assert
            try
            {
                var actualResult = calculator.Add(inputString);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }
        #endregion

        /// <summary>
        /// Hàm unit test trừ hai số
        /// </summary>
        [TestCase(1, 2, -1)]
        [TestCase(1, -2, 3)]
        [TestCase(1, int.MaxValue, (long)1 - int.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue, (long)2 * int.MaxValue + 1)]
        public void Sub_ValidInput_Sub2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Sub(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm unit test nhân hai số
        /// </summary>
        [TestCase(1, 2, 2)]
        [TestCase(5, -2, -10)]
        [TestCase(int.MinValue, int.MaxValue, (long)int.MinValue * int.MaxValue)]
        public void Mul_ValidInput_Mul2Digit(int x, int y, long expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Mul(x, y);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Hàm unit test chia một số cho 0
        /// </summary>
        [Test]
        public void Div_DivideByZero_ThrowException()
        {
            // Arrange
            var x = 1;
            var y = 0;
            var expectedMessage = "Không chia được cho 0";

            var calculator = new Calculator();

            // Act && Assert
            try
            {
                var actualResult = calculator.Div(x, y);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }
        }

        /// <summary>
        /// Hàm unit test chia hai số
        /// </summary>
        [TestCase(1, 2, 0.5)]
        [TestCase(2, 3, 2 / (double)3)]
        [TestCase(2, 3, 0.66666667)]
        public void Div_ValidInput_Div2Digit(int x, int y, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.Div(x, y);

            // Assert
            Assert.That(Math.Abs(actualResult - expectedResult), Is.LessThan(10e-6));
        }


    }
}
