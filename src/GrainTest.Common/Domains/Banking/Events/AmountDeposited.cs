namespace GrainTest.Common.Domains.Banking.Events;

public sealed class AmountDeposited : BankAccountBaseEvent
{
    public double Amount { get; set; }
}