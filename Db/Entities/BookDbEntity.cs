using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BookCollection.Db.Entities
{
    public class BookDbEntity
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }

        [StringLength(256, MinimumLength = 1)]
        public string? Publisher { get; set; }
        public string? Description { get; set; }
    }
}
