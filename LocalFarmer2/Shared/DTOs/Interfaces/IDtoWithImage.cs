namespace LocalFarmer2.Shared.DTOs
{
    public interface IDtoWithImage
    {
        byte[] ImageData { get; set; }
        string ImageMimeType { get; set; }
    }
}
