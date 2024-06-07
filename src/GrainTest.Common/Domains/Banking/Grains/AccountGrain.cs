using GrainTest.Common.Domains.Banking.Events;
using GrainTest.Common.Domains.Banking.Model;
using Orleans.Concurrency;
using Petl.EventSourcing;

namespace GrainTest.Common.Domains.Banking.Grains;

[Reentrant]
public sealed class AccountGrain : EventSourcedGrain<BankAccount, BankAccountBaseEvent>, IAccountGrain
{
    public Task Open(Guid id)
    {
        if (!State.Id.Equals(Guid.Empty))
        {
            return Task.CompletedTask;
        }
        
        Raise(new AccountOpened { Id = id });
        return Task.CompletedTask;
    }
    
    public Task<bool> Withdraw(double amount)
    {
        if (amount > State.Balance)
        {
            return Task.FromResult(false);
        }

        Raise(new AmountWithdrawn { Amount = amount });

        return Task.FromResult(true);
    }

    public Task Deposit(double amount)
    {
        Raise(new AmountDeposited() { Amount = amount });

        return Task.FromResult(true);
    }

    public Task<double> GetBalance()
    {
        return Task.FromResult(State.Balance);
    }
}