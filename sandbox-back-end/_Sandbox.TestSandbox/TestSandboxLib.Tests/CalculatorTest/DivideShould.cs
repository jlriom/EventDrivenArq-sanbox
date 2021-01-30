using System;
using AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace TestSandboxLib.Tests.CalculatorTest
{
    public class DivideShould
    {
        [Theory, AutoData]
        public void DivideTwoValues(int a, int b, Calculator sut)
        {
            sut.Divide(a, b).ShouldBe(a / b);
        }

        [Theory, AutoData]
        public void DivideByZero(int a, Calculator sut)
        {
            Assert.Throws<DivideByZeroException>(() => sut.Divide(a, 0));
        }
    }


}
