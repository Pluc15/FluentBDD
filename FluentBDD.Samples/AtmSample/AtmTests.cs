using Xunit;

namespace FluentBDD.Samples.AtmSample
{
    public class AtmTests
    {
        public AtmTests()
        {
            Scenario.RegisterType<AtmSteps>();
        }

        [Fact]
        public void Can_do_standard_ATM_transactions()
        {
            Scenario.Create()
                .Step<AtmSteps>(s => s.Given_a_user_has_x_dollars(100))
                .Step<AtmSteps>(s => s.When_the_user_withdraws_x(75))
                .Step<AtmSteps>(s => s.Then_the_user_has_x(25))
                .Step<AtmSteps>(s => s.When_the_user_deposits_x(5))
                .Step<AtmSteps>(s => s.Then_the_user_has_x(30));
        }
    }
}
