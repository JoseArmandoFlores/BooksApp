using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Shared.Models
{
    public class Books
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string Excerpt { get; set; }
        [Required]
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
