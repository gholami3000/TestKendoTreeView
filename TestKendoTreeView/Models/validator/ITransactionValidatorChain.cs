namespace TestKendoTreeView.Models.validator
{
    public interface ITransactionValidatorChain
    {
        KscResult Execute(AddModel command);
    }
}
