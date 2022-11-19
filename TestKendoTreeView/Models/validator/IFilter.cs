namespace TestKendoTreeView.Models.validator
{
    public interface IFilter<T, TOut>
    {
        TOut Execute(T context, Func<T, TOut> executeNext);
    }
}
