using BookStore.Common.Shared.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class BookImage : BaseEntity
    {
        public int BookImageId { get; set; }
        public int BookId { get; set; }
        public string FileUpload { get; set; }
        public Book Book { get; set; }
    }
}
