using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;

namespace DotNetSpain2015.Sam.SpecFlowLab.Intro.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private Calculator calculator;
        private List<int> operands;
        private int result;
        private int expectedResult = 120;

        public SpecFlowFeature1Steps()
        {
            this.calculator = new Calculator();
            this.operands = new List<int>();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand)
        {
            this.operands.Add(operand);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            this.result = this.calculator.Add(this.operands.First(), this.operands.Last());
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(this.expectedResult, this.result);
        }
    }
}
