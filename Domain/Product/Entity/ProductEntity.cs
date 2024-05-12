using Domain.Base.Entity;
using Domain.ProductWallet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.Entity
{
    public class ProductEntity : BaseEntity
    {
        [Required]
        public string Description {  get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price {  get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow.AddDays(-3);
        public DateTime? LastChangeDate { get; set; }
        [Required]
        public bool Active {  get; set; }
        public List<ProductWalletEntity>? productWalletEntities { get; set; }
    }
}
