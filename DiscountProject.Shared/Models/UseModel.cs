namespace DiscountProject.Shared.Models;

public class UseModel
{
    public string Code { get; set; } = string.Empty;

    public UseModel() {}

    public UseModel(string code)
    {
        Code = code;
    }
}
