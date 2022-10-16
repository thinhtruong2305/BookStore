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
            return services;
        }
    }
}
