using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.Domain.POCOs
{
    [Table("SearchHistory")]
    public class SearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        public string City { get; set; }

        public string Info { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
