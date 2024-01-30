using WalletApp.Data.Enums;

namespace WalletApp.Business.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Pending { get; set; }
        public int AuthorizedUserId { get; set; }
        public int RecipientId { get; set; }
    }
}
