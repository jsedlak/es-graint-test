namespace GrainTest.Common.Domains.Banking.Events;

public sealed class AmountWithdrawn : BankAccountBaseEvent
{
    public double Amount { get; set; }
}