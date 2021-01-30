using AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace TestSandboxLib.Tests.CalculatorTest
{
    public class SumShould
    {


        [Theory, AutoData]
        public void SumTwoValues(int a, int b, Calculator sut)
        {
            sut.Sum(a, b).ShouldBe(a+b);
        }
    }
}
