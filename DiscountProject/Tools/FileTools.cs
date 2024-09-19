using DiscountProject.Shared.Models;

namespace DiscountProject.Tools;

public static class FileTools
{
    public static void WriteCodesFile(string path, List<FileContentModel> lstFiles)
    {
        using StreamWriter outputFile = new(path);
        foreach (var code in lstFiles)
        {
            string active = code.IsActive ? "1" : "0";
            outputFile.WriteLineAsync($"{code.Code};{code.Discount};{active}");
        }
    }

    public static List<FileContentModel> ReadCodesFile(string path)
    {
        if (!File.Exists(path))
            return [];

        List<FileContentModel> codes = [];

        using (StreamReader sr = File.OpenText(path))
        {
            string? currLine = string.Empty;

            while ((currLine = sr.ReadLine()) != null)
            {
                string[] arr = currLine.Split(';');
                codes.Add(new(arr[0], byte.Parse(arr[1]), arr[2] == "1"));
            }
        }

        return codes;
    }
}
