using Microsoft.Extensions.DependencyInjection;
using MyFoundation.Interfaces;
using MyFoundation.Models;
using Schema.NET;
using Sitecore.DependencyInjection;

namespace MyFoundation.Resolvers
{
    public class OrganizationAuthorResolver : IAuthorResolver
    {
        public Values<Organization, Person> GetAuthor()
        {
            var localSettings = ServiceLocator.ServiceProvider.GetService<LocalSettings>();
            return localSettings.GetOrganizationMicrodata();
        }
    }
}