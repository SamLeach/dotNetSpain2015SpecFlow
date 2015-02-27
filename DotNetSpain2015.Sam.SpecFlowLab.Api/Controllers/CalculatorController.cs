using DotNetSpain2015.Sam.SpecFlowLab.Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DotNetSpain2015.Sam.SpecFlowLab.Api.Controllers
{
    public class CalculatorController : ApiController
    {
        private Calculator calculator;

        public CalculatorController()
        {
            this.calculator = new Calculator();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok();
        }

        [HttpPost]
        [Route("calculator/{operand1}/{operand2}")]
        public IHttpActionResult Post(int operand1, int operand2)
        {
            return this.Ok(this.calculator.Add(operand1, operand2));
        }

        [HttpPost]
        [Route("calculator/{operand1}/{operand2}")]
        public IHttpActionResult Subtract(int operand1, int operand2)
        {
            // TODO: Use the Subtract calculator method to implement this POST method
            //return this.Ok(this.calculator.Add(operand1, operand2));
            return this.InternalServerError();
        }
    }
}