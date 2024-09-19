using DiscountProject.Shared.Models;
using DiscountProject.Tools;

namespace DiscountProject.Services.DiscountSservices;

public class DiscountServices : IDiscountServices
{
    public readonly string PathToCodesFile = Path.Combine(Environment.CurrentDirectory, "codes.csv");

    public async Task<bool> GenerateCode(GenerateModel parameters)
    {
        if (!ParametersValidator.ValidateGenerate(parameters))
            return false;

        List<FileContentModel> lstFileCodes = FileTools.ReadCodesFile(PathToCodesFile);
        
        CodeTools.GenerateLstOfCodes(parameters, lstFileCodes);

        FileTools.WriteCodesFile(PathToCodesFile, lstFileCodes);

        return true;
    }

    public async Task<byte> UseCode(UseModel parameters)
    {
        if (!ParametersValidator.ValidateUse(parameters))
            return 0;

        List<FileContentModel> lstFileCodes = FileTools.ReadCodesFile(PathToCodesFile);
        FileContentModel? result = lstFileCodes.Find(x => x.Code == parameters.Code && x.IsActive);

        if (result is not null)
        {
            result.IsActive = false;
            FileTools.WriteCodesFile(PathToCodesFile, lstFileCodes);

            return result.Discount;
        }
        else
        {
            return 0;
        }
    }
}
