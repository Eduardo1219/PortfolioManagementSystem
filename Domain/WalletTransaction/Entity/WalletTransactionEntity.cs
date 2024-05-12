using Domain.MongoBase.Entity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WalletTransaction.Entity
{
    public class WalletTransactionEntity : BaseMongoEntity
    {
        [BsonElement("WalletId")]
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
        Positive = 1,
        Negative = 2
    }

    public enum OperationType
    {
        Deposit = 1,
        Withdraw = 2,
        Buy = 3,
        Sell = 4,
    }
}
