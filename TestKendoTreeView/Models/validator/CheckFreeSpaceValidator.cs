using Flo;
using TestKendoTreeView.Models;

public class CheckFreeSpaceInSourceValidator : IHandler<AddModel, KscResult>
{
    private readonly MyServices myServices;
    public CheckFreeSpaceInSourceValidator(MyServices myServices)
    {
        this.myServices = myServices;
    }
    public async Task<KscResult> HandleAsync(AddModel command,Func<AddModel, Task<KscResult>> next)
    {
        if (command.Weight > 4)
            return new KscResult
            {
                Success = false
            };

        return await next.Invoke(command);
    }
}


public class CheckFreeSpaceInDestinationValidator : IHandler<AddModel, KscResult>
{
    public async Task<KscResult> HandleAsync(AddModel command, Func<AddModel, Task<KscResult>> next)
    {
        if (command.RoutId == 1)
            return new KscResult
            {
                Success = false
            };

        return await next.Invoke(command);
    }
}
