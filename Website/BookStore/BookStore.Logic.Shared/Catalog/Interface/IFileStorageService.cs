using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Catalog.Interface
{
    public interface IFileStorageService
    {
        public string GetFileUrl(string fileName);

        public Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        public Task<string> SaveFile(IFormFile file);

        public Task DeleteFileAsync(string fileName);
    }
}
