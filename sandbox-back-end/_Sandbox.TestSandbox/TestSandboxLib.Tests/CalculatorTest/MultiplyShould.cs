using AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace TestSandboxLib.Tests.CalculatorTest
{
    public class MultiplyShould
    {
        [Theory, AutoData]
        public void SumTwoValues(int a, int b, Calculator sut)
        {
            sut.Multiply(a, b).ShouldBe(a * b);
        }
    }


}
