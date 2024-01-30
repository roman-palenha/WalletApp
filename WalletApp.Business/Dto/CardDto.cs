using WalletApp.Data;

namespace WalletApp.Business.Dto
{
    public class CardDto
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public double Available => Constants.MaxBalance - Balance;
    }
}
