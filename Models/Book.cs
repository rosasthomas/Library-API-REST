using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int idBook { get; set; }

        public int idAuthor;
        
        [ForeignKey("idAuthor")]
        public Author Authors { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string section { get; set; }
        public string genre { get; set; }
        public int year { get; set; }
        public string publisher { get; set; }
        
    }
}
