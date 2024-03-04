namespace PRG.Clients.RSP.Dtos
{
    public class RecordDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string ClubCode { get; set; }
        public string ShopID { get; set; }
        public bool Active { get; set; }
        public bool Locked { get; set; }
        public object LastLoginTime { get; set; }
        public object LastOrderUpdateTime { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public List<ClubDto> Clubs { get; set; }
        public object DaysUntilPasswordExpiration { get; set; }
        public bool SessionActive { get; set; }
    }
}
