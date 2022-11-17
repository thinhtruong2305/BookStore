using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Queries.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic
{
    public static class Register
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IBookQueries, BookQueries>();
            services.AddScoped<ICategoryQueries, CategoryQueries>();
            services.AddScoped<IBookImageQueries, BookImageQueries>();
            services.AddScoped<IAuthorQueries, AuthorQueries>();
            services.AddScoped<IAuthorQueries, AuthorQueries>();
            services.AddScoped<IOrderQueries, OrderQueries>();
            services.AddScoped<IPublisherQueries, PublisherQueries>();
            services.AddScoped<ISeriesQueries, SeriesQueries>();
            services.AddScoped<ITagQueries, TagQueries>();
            services.AddScoped<IUserQueries, UserQueries>();
            return services;
        }
    }
}
