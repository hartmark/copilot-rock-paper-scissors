using Microsoft.AspNetCore.Mvc.ModelBinding;
using RockPaperScissors.Core;

namespace RockPaperScissors.Api;

public class MoveModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var payloadBody = (await new StreamReader(bindingContext.ActionContext.HttpContext.Request.BodyReader.AsStream()).ReadToEndAsync())
            .TrimStart('"')
            .TrimEnd('"');

        if (string.IsNullOrWhiteSpace(payloadBody))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }
        
        if (int.TryParse(payloadBody, out var intValue))
        {
            if (Enum.IsDefined(typeof(Move), intValue))
            {
                bindingContext.Result = ModelBindingResult.Success((Move)intValue);
                return;
            }
        }
        else if (Enum.TryParse<Move>(payloadBody, true, out var enumValue))
        {
            bindingContext.Result = ModelBindingResult.Success(enumValue);
            return;
        }

        bindingContext.Result = ModelBindingResult.Failed();
        bindingContext.ModelState.AddModelError("Move", $"The 'move' parameter is invalid. PayloadBody: {payloadBody}");
    }
}