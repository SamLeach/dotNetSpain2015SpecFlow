using DotNetSpain2015.Sam.SpecFlowLab.Api.Controllers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using System.Web.Http;
using NUnit.Framework;
using System.Web.Http.Results;

namespace DotNetSpain2015.Sam.SpecFlowLab.Api.Specs
{
    [Binding]
    public class WebApiSumSteps
    {
        private CalculatorController calculatorController;
        private List<int> operands;
        private IHttpActionResult httpActionResult;

        public WebApiSumSteps()
        {
            this.calculatorController = new CalculatorController();
            this.operands = new List<int>();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GinIHaveEnteredIntoTheCalculator(int operand)
        {
            this.operands.Add(operand);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            this.httpActionResult = this.calculatorController.Post(this.operands.First(), this.operands.Last());
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            var contentResult = this.httpActionResult as OkNegotiatedContentResult<int>;
            var sumResult = contentResult.Content;
            Assert.AreEqual(p0, sumResult);
        }
    }
}
