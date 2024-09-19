using DiscountProject.Services.DiscountSservices;
using DiscountProject.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace DiscountProject.Hubs;

public class DiscountHub(IDiscountServices discountServices) : Hub
{
    public async Task GenerateCode(GenerateModel param)
    {
        bool result = await discountServices.GenerateCode(param);
        await Clients.Caller.SendAsync("ReceiveGenerate", result);
    }

    public async Task UseCode(UseModel param)
    {
        byte result = await discountServices.UseCode(param);
        await Clients.Caller.SendAsync("ReceiveUse", result);
    }
}
