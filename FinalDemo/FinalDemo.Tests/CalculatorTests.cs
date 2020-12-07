using System;
using System.Collections.Generic;
using System.Text;
using FinalDemo.lib;
using Xunit;

namespace FinalDemo.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_SimpleValueShouldCalculate()
        {
            double expected = 5;
            double fact = Calculator.Add(2, 3);
            Assert.Equal(expected, fact);
        }
        [Fact]
        public void Subtract_SimpleValueShouldCalculate()
        {
            double expect = 0;
            double fact = Calculator.Subtract(5, 5);
            Assert.Equal(expect, fact);
        }
    }
}
