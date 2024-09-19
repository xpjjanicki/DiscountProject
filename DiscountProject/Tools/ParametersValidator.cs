using DiscountProject.Shared.Models;

namespace DiscountProject.Tools;

public static class ParametersValidator
{
    public static bool ValidateGenerate(GenerateModel parameters)
    {
        if (parameters is null)
            return false;

        if (parameters.Count > 2000 || parameters.Count < 0)
            return false;

        if (parameters.Length > 8 || parameters.Length < 7)
            return false;

        return true;
    }

    public static bool ValidateUse(UseModel parameters)
    {
        if (parameters.Code is null || parameters.Code.Length == 0)
            return false;

        return true;
    }
}
