namespace GrainTest.Common.Domains.Banking.Grains;

public interface IAccountGrain : IGrainWithGuidKey
{
    Task Open(Guid id);
    
    Task<bool> Withdraw(double amount);

    Task Deposit(double amount);

    Task<double> GetBalance();
}