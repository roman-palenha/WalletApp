namespace WalletApp.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; }
        public DateTime? PointsDate { get; set; }
        public virtual ICollection<CardBalance> Balances { get; set; }
    }
}
