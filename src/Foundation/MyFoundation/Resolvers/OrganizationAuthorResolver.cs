using Schema.NET;

namespace MyFoundation.Resolvers
{
    public class OrganizationAuthorResolver
    {
        public Values<Organization, Person> GetAuthor()
        {
            return new Organization();
        }
    }
}