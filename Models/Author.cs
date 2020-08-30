using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int idAuthor { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

    }
}
