using TestKendoTreeView.Models.validator;

namespace TestKendoTreeView.Models
{
    public class CheckFreeSpaceInDestinationValidator1 : IFilter<AddModel, KscResult>
    {
        //private readonly MyServices myServices;     
        public KscResult Execute(AddModel context, Func<AddModel, KscResult> executeNext)
        {
            if (context.Weight > 4)
                return new KscResult
                {
                    Success = false
                };

            return executeNext(context);

        }
    }
}
