namespace DiscountProject.Shared.Models;

public class FileContentModel
{
    public string Code { get; set; } = string.Empty;

    public byte Discount { get; set; } = 15;

    public bool IsActive { get; set; } = true;

    public FileContentModel() {}

    public FileContentModel(string code, byte discount, bool isActive) 
    {
        Code = code;
        Discount = discount;
        IsActive = isActive;
    }
}
