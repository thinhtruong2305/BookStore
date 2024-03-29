﻿using BookStore.Logic.Shared.Catalog.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace BookStore.Logic.Shared.Catalog.Implement
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _bookContentFolder;
        private readonly IWebHostEnvironment webHostEnvironment;
        private const string BOOK_CONTENT_FOLDER_NAME = "uploads";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _bookContentFolder = Path.Combine(webHostEnvironment.WebRootPath, BOOK_CONTENT_FOLDER_NAME);
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = webHostEnvironment.WebRootPath + fileName;
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{BOOK_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_bookContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition)?.FileName?.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + BOOK_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
