using WalletApp.Data.Enums;

namespace WalletApp.Data.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionTypeEnum Type { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Pending { get; set; }

        public int AuthorizedUserId { get; set; }
        public virtual User AuthorizedUser { get; set; }
        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }
    }
}
