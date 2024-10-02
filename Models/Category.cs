using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmek.Models
{
    public class Category
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("CategoryName")]
        [Required]
        public string Name { get; set; }

    }
}
