namespace PRG.Clients.RSP.Responses
{

    internal class ValidateMembershipResponse
    {
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Phones Phones { get; set; }
        public string Expiration { get; set; }
        public string MemberLevel { get; set; }
        public Address Address { get; set; }
        public string JoinDate { get; set; }
        public string LevelEffectiveDate { get; set; }
        public bool IsClubEmployee { get; set; }
    }


}
