using Xunit;
using Autofac;

namespace FluentBDD.Samples.ATMSample
{
    public class ATMTests
    {
        public ATMTests()
        {
            Scenario.ContainerBuilder.RegisterType<ATMSteps>();
        }

        [Fact]
        public void Can_do_standard_ATM_transactions()
        {
            Scenario.Create()
                .Step<ATMSteps>(s => s.Given_a_user_has_x_dollars(100))
                .Step<ATMSteps>(s => s.When_the_user_withdraws_x(75))
                .Step<ATMSteps>(s => s.Then_the_user_has_x(25))
                .Step<ATMSteps>(s => s.When_the_user_deposits_x(5))
                .Step<ATMSteps>(s => s.Then_the_user_has_x(30));
        }
    }
}
