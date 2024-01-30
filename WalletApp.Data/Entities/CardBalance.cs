namespace WalletApp.Data.Entities
{
    public class CardBalance : BaseEntity
    {
        public double Balance { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
