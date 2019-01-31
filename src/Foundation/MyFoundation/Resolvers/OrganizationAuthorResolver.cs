using MyFoundation.Interfaces;
using Schema.NET;

namespace MyFoundation.Resolvers
{
    public class OrganizationAuthorResolver : IAuthorResolver
    {
        public Values<Organization, Person> GetAuthor()
        {
            return new Organization();
        }
    }
}