using Domain.MongoBase.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WalletTransaction.Entity
{
    public class WalletTransactionEntity : BaseMongoEntity
    {
        [BsonElement("WalletId")]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid WalletId { get; set; }
        [BsonElement("Amount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Amount { get; set; }
        [BsonElement("PreviousBalance")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal PreviousBalance { get; set; }
        [BsonElement("LaterBalance")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal LaterBalance { get; set; }
        [BsonElement("OperationDate")]
        public DateTime OperationDate { get; set; }
        [BsonElement("ModificationType")]
        public ModificationType ModificationType { get; set; }
        [BsonElement("OperationType")]
        public OperationType OperationType { get; set; }
    }

    public enum ModificationType
    {
        [Description("Add value to balance")]
        Positive = 1,
        [Description("Remove value to balance")]
        Negative = 2
    }

    public enum OperationType
    {
        [Description("Deposit value")]
        Deposit = 1,
        [Description("Withdraw value")]
        Withdraw = 2,
        [Description("Buy a product and discount value from balance")]
        Buy = 3,
        [Description("Sell a product and add value to balance")]
        Sell = 4,
    }
}
