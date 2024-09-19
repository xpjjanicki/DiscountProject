namespace DiscountProject.Shared.Models;

public class GenerateModel
{
    public ushort Count { get; set; }

    public byte Length { get; set; }

    public GenerateModel() {}
    public GenerateModel(ushort count, byte length) 
    {
        Count = count;
        Length = length;
    }
}
