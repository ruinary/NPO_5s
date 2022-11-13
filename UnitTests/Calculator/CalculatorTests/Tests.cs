using SimpleCalculator;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest
    {
        [Fact]
        public void Add_WithArguments1And2_Returns3()
        {
            var calculator = new Calculator();
            var result = calculator.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Subtract_WithArguments1And2_ReturnsMinus1()
        {
            var calculator = new Calculator();
            var result = calculator.Subtract(1, 2);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Multiply_WithArguments1And2_Returns2()
        {
            var calculator = new Calculator();
            var result = calculator.Multiply(1, 2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Divide_WithArguments1And0_ThrowsDivideByZeroException()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(1, 0));
        }

        [Fact]
        public void Modulus_WithArguments1And2_Returns1()
        {
            var calculator = new Calculator();
            var result = calculator.Modulus(1, 2);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Power_WithArguments10And2_Returns100()
        {
            var calculator = new Calculator();
            var result = calculator.Power(10, 2);
            Assert.Equal(100, result);
        }

        [Fact]
        public void Factorial_WithArgument5_Returns120()
        {
            var calculator = new Calculator();
            var result = calculator.Factorial(5);
            Assert.Equal(120, result);
        }

        [Fact]
        public void Factorial_WithArgumentMinus5_ThrowsArgumentOutOfRangeException()
        {
            var calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Factorial(-5));
        }

        [Fact]
        public void Factorial_WithArgument0_Returns1()
        {
            var calculator = new Calculator();
            var result = calculator.Factorial(0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Factorial_WithArgument1_Returns1()
        {
            var calculator = new Calculator();
            var result = calculator.Factorial(1);
            Assert.Equal(1, result);
        }

    }
}