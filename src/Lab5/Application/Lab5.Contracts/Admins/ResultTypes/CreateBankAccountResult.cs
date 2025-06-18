namespace Lab5.Contracts.Admins.ResultTypes;

public abstract record CreateBankAccountResult
{
    public sealed record Success() : CreateBankAccountResult;

    public sealed record Failure(string Message) : CreateBankAccountResult;
}