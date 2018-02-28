﻿using System.ComponentModel.DataAnnotations;

namespace Sanatorium.Models
{
    public class ManagerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string State { get; set; }
    }
    public class RegionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
    public class StreetViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string RegionName { get; set; }
    }
    public class CommunityViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string StreetName { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "手机号")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "请输入{0}")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "电话")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "姓名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(30, ErrorMessage = "{0}长度不足{2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "两次输入密码不相符.")]
        public string ConfirmPassword { get; set; }       
     
        
    }

    public class MyAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }
    }


}
