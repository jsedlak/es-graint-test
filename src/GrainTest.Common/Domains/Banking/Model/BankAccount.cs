using GrainTest.Common.Domains.Banking.Events;

namespace GrainTest.Common.Domains.Banking.Model;

public class BankAccount
{
    public Guid Id { get; set; }
    
    public double Balance { get; set; }

    public void Apply(AccountOpened @event)
    {
        Id = @event.Id;
    }

    public void Apply(AmountWithdrawn @event)
    {
        Balance -= @event.Amount;
    }

    public void Apply(AmountDeposited @event)
    {
        Balance += @event.Amount;
    }
}