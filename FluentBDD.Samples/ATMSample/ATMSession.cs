using System;

namespace FluentBDD.Samples.ATMSample
{
    public class ATMSession
    {
        private int _balance = 0;

        public void Deposite(int amount)
        {
            _balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (_balance < amount) throw new InvalidOperationException("Balance too low");
            _balance -= amount;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}
