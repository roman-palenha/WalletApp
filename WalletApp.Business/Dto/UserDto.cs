namespace WalletApp.Business.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; }
        public DateTime? PointsDate { get; set; }
    }
}
