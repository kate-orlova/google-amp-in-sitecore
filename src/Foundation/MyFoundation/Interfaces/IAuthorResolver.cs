using Schema.NET;

namespace MyFoundation.Interfaces
{
    public interface IAuthorResolver
    {
        Values<Organization, Person> GetAuthor();
    }
}