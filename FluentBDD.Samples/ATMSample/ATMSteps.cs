using System;
using FluentAssertions;

namespace FluentBDD.Samples.ATMSample
{
    public class ATMSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ATMSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        public void GivenAUserHasXDollars(int amount)
        {
            var atm = new ATMSession();
            _scenarioContext.Add(atm);
            atm.Deposite(100);
        }

        public void WhenTheUserWithdrawsX(int X)
        {
            _scenarioContext.Get<ATMSession>().Withdraw(X);
        }

        public void WhenTheUserDepositsX(int X)
        {
            _scenarioContext.Get<ATMSession>().Deposite(X);
        }

        public void ThenTheUserHasX(int X)
        {
            _scenarioContext.Get<ATMSession>().GetBalance().Should().Be(X);
        }
    }
}
