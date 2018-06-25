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
        
        public void Given_a_user_has_x_dollars(int amount)
        {
            var atm = new ATMSession();
            _scenarioContext.Add(atm);
            atm.Deposite(100);
        }

        public void When_the_user_withdraws_x(int x)
        {
            _scenarioContext.Get<ATMSession>().Withdraw(x);
        }

        public void When_the_user_deposits_x(int x)
        {
            _scenarioContext.Get<ATMSession>().Deposite(x);
        }

        public void Then_the_user_has_x(int x)
        {
            _scenarioContext.Get<ATMSession>().GetBalance().Should().Be(x);
        }
    }
}
