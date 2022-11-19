using TestKendoTreeView.Models.validator;

namespace TestKendoTreeView.Models
{
   

    public class CheckFreeSpaceInSourceValidator1 : ITransactionValidatorChain
    {
        private readonly ITransactionValidatorChain next;
        //private readonly MyServices myServices;

        public CheckFreeSpaceInSourceValidator1(ITransactionValidatorChain next)
        {
            this.next = next;
        }
        public KscResult Execute(AddModel model)
        {
            if (model.RoutId == 1)
                return new KscResult
                {
                    Success = false
                };

            return next.Execute(model);
        }
    }
}
