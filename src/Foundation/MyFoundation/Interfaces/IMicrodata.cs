using Schema.NET;

namespace MyFoundation.Interfaces
{
    public interface IMicrodata
    {
        Thing GetMicrodata(IAuthorResolver authorResolver);
    }
}