using BookStore.Common.Shared.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class User : IdentityUser
    {
        /*[Required(ErrorMessage = "Bạn phải nhập họ và tên lót")]
        [Display(Name = "Họ và tên lót")]*/
        public string FirstName { get; set; }

        /*[Required(ErrorMessage = "Bạn phải nhập tên")]
        [Display(Name = "Tên")]*/
        public string LastName { get; set; }

        /*[Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]*/
        public DateTime DateOfBirth { get; set; }

        /*[Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]*/
        public string Address { get; set; }

        public static implicit operator User(EntityEntry<User> v)
        {
            return v.Entity;
        }
    }
}
