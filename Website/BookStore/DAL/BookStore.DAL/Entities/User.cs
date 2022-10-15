﻿using Microsoft.AspNetCore.Identity;
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
        [Required(ErrorMessage = "Bạn phải nhập họ và tên lót")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Họ và tên lót")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
        [RegularExpression(@"^(?:(?:31(\/)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Bạn phải nhập dd/MM/yyyy hoặc dd/MMM/yyyy")]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}
