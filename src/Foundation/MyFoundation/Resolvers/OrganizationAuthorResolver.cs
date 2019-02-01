using MyFoundation.Interfaces;
using Schema.NET;

namespace MyFoundation.Resolvers
{
    public class OrganizationAuthorResolver : IAuthorResolver
    {
        public Values<Organization, Person> GetAuthor()
        {
            // TODO: 1. create a local setting for organisation
            return new Organization();
        }
    }
}