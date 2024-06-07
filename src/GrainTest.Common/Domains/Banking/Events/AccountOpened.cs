namespace GrainTest.Common.Domains.Banking.Events;

public sealed class AccountOpened : BankAccountBaseEvent
{
    public Guid Id { get; set; }
}