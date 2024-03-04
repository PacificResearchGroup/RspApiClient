namespace PRG.Clients.RSP.Dtos
{
    public class MemberDto
    {
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public PhonesDto Phones { get; set; }
        public string Expiration { get; set; }
        public string MemberLevel { get; set; }
        public AddressDto Address { get; set; }
        public string JoinDate { get; set; }
        public string LevelEffectiveDate { get; set; }
        public bool IsClubEmployee { get; set; }
    }
}
