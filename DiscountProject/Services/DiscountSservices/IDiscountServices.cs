using DiscountProject.Shared.Models;

namespace DiscountProject.Services.DiscountSservices;

public interface IDiscountServices
{
    Task<bool> GenerateCode(GenerateModel parameters);
    Task<byte> UseCode(UseModel parameters);
}
