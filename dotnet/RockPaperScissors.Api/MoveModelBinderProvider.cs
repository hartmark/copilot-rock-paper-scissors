using Microsoft.AspNetCore.Mvc.ModelBinding;
using RockPaperScissors.Core;

namespace RockPaperScissors.Api;

public class MoveModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        return context.Metadata.ModelType == typeof(Move) ? new MoveModelBinder() : null;
    }
}