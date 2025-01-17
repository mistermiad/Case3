using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace calculator.lib.test.steps
{
    [Binding]
    public class SquareRootSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public SquareRootSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a number (.*) to calculate the Square Root")]
        public void WhenNumberIsCheckedForSR(int number)
        {
            _scenarioContext.Add("number", number);
        }

        [When("Square Root is calculated")]
        public void IGetSquareRoot()
        {
            var number = _scenarioContext.Get<int>("number");
            var SquareRoot = NumberAttributter.getSquareRoot(number);
            _scenarioContext.Add("getSquareRoot", SquareRoot);
        }

        [Then("the answer of the square root is (.*)")]
        public void ItShouldBeSquareRoot(double expectedSquareRoot)
        {
            var getSquareRoot = _scenarioContext.Get<double>("getSquareRoot");
            Assert.Equal(expectedSquareRoot, getSquareRoot);
        }
    }
}