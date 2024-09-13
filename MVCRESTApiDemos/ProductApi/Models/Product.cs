using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int StoreId { get; set; }   
      
    }
}
