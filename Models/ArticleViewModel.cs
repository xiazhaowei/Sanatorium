using System;
using System.ComponentModel.DataAnnotations;

namespace Sanatorium.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name ="文章标题")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "文章内容")]
        [Required]
        public string Content { get; set; }
    }
}