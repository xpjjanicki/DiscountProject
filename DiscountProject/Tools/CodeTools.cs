using DiscountProject.Shared.Models;
using RandomString4Net;

namespace DiscountProject.Tools;

public static class CodeTools
{
    public static void GenerateLstOfCodes(GenerateModel parameters, List<FileContentModel> lstFileCodes)
    {
        List<string> exampleCodes = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, parameters.Count, maxLength: parameters.Length, randomLength: false, forceUnique: true);
        List<string> lstBadCodes = [];
        if (lstFileCodes.Count > 0)
            lstBadCodes = exampleCodes.Where(x => lstFileCodes.Any(y => y.Code == x)).ToList();

        int bads = lstBadCodes.Count;

        if (bads == 0)
        {
            foreach (var item in exampleCodes)
                lstFileCodes.Add(new(item, 15, true));
        }
        else
        {
            while (bads > 0)
            {
                exampleCodes = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, bads, maxLength: parameters.Length, randomLength: false, forceUnique: true);
                lstBadCodes = exampleCodes.Where(x => lstFileCodes.Any(y => y.Code == x)).ToList();

                exampleCodes.RemoveAll(x => exampleCodes.Any(y => y == x));

                foreach (var item in exampleCodes)
                    lstFileCodes.Add(new(item, 15, true));

                bads = lstBadCodes.Count;
            }
        }
    }
}
