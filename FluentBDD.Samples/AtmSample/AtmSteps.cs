using FluentAssertions;

namespace FluentBDD.Samples.AtmSample
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AtmSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AtmSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        public void Given_a_user_has_x_dollars(int amount)
        {
            var atm = new AtmSession();
            _scenarioContext.Add(atm);
            atm.Deposite(100);
        }

        public void When_the_user_withdraws_x(int x)
        {
            _scenarioContext.Get<AtmSession>().Withdraw(x);
        }

        public void When_the_user_deposits_x(int x)
        {
            _scenarioContext.Get<AtmSession>().Deposite(x);
        }

        public void Then_the_user_has_x(int x)
        {
            _scenarioContext.Get<AtmSession>().GetBalance().Should().Be(x);
        }
    }
}
