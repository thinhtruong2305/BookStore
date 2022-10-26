using BookStore.Common.Shared.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("BookImage")]
    public class BookImage : BaseEntity
    {
        public int BookImageId { get; set; }
        public int BookId { get; set; }

        [Required(ErrorMessage = "Bạn không được để trống")]
        public string FileUpload { get; set; }
        public Book Book { get; set; }
    }
}
