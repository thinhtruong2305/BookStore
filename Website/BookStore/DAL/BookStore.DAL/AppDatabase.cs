using BookStore.DAL.Configuration;
using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class AppDatabase : IdentityDbContext<User>
    {
        public const string ConnectString = @"Data Source=DESKTOP-J98APIA;Initial Catalog=BookStore;User ID=sa;Password=Thinhyeuhocbai123";
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(ConnectString);
            builder.UseLoggerFactory(GetLoggerFactory());
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookImageConfiguration());
            modelBuilder.ApplyConfiguration(new EditionConfiguration());
            modelBuilder.ApplyConfiguration(new EditionPublisherConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public virtual DbSet<Author> Authors => Set<Author>();
        public virtual DbSet<AuthorBook> AuthorBooks => Set<AuthorBook>();
        public virtual DbSet<Book> Books => Set<Book>();
        public virtual DbSet<BookImage> BookImages => Set<BookImage>();
        public virtual DbSet<Edition> Editions => Set<Edition>();
        public virtual DbSet<EditionPublisher> EditionPublishers => Set<EditionPublisher>();
        public virtual DbSet<Info> Infos => Set<Info>();
        public virtual DbSet<Menu> Menus => Set<Menu>();
        public virtual DbSet<Order> Orders => Set<Order>();
        public virtual DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
        public virtual DbSet<Publisher> Publishers => Set<Publisher>();
        public virtual DbSet<Rating> Ratings => Set<Rating>();
        public virtual DbSet<Tag> Tags => Set<Tag>();
        public virtual DbSet<Series> Series => Set<Series>();
        public virtual DbSet<User> Users => Set<User>();
    }
}
