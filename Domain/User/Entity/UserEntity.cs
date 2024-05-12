using Domain.Base.Entity;
using Domain.User.Entity.Enum;
using Domain.Wallet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Entity
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(-3);
        public DateTime? LastChangeDate { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public UserEnum Permission { get; set; }
        public WalletEntity? Wallet { get; set; }
    }
}
