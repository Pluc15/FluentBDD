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
        public void CanDoStandardATMTransactions()
        {
            Scenario.Create()
                .Step<ATMSteps>(s => s.GivenAUserHasXDollars(100))
                .Step<ATMSteps>(s => s.WhenTheUserWithdrawsX(75))
                .Step<ATMSteps>(s => s.ThenTheUserHasX(25))
                .Step<ATMSteps>(s => s.WhenTheUserDepositsX(5))
                .Step<ATMSteps>(s => s.ThenTheUserHasX(30));
        }
    }
}
