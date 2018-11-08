namespace MyFoundation.Interfaces
{
    public interface IExternalImageProcessor
    {
        string Resize(string url, int width, string additionalParameters);
        string Crop(string url, int width, int height);
    }
}