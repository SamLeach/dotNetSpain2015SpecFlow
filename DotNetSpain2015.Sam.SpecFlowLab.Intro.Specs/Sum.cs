using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace DotNetSpain2015.Sam.SpecFlowLab.Intro.Specs
{
    [Binding]
    public class Sum
    {
        private Calculator calculator;
        private IList<int> operands;
        private int result;
        private IList<int> actualTableResults;
        private IEnumerable<Operands> tableOperands;

        public Sum()
        {
            this.calculator = new Calculator();
            this.operands = new List<int>();
            this.tableOperands = new List<Operands>();
            this.actualTableResults = new List<int>();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            var expectedTableResults = new List<int>();

            foreach (var row in table.Rows)
            {
                expectedTableResults.Add(int.Parse(row["Result"]));
            }

            CollectionAssert.AreEqual(expectedTableResults, this.actualTableResults);
        }


        [Given(@"I have entered the following")]
        public void GivenIHaveEnteredTheFollowing(Table table)
        {
            this.tableOperands = table.CreateSet<Operands>();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand)
        {
            this.operands.Add(operand);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            if (this.tableOperands.Any())
            {
                foreach (var operand in tableOperands)
                {
                    this.actualTableResults.Add(this.calculator.Add(operand.Operand1, operand.Operand2));        
                }
                return;
            }

            this.result = this.calculator.Add(this.operands.First(), this.operands.Last());
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, this.result);
        }
    }
}
