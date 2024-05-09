namespace PRG.Clients.RSP.Dtos
{
    public class PromotionEntryDto
    {
        public string AwardValue { get; set; }
        public bool IsWinner { get; set; }
        public string MemberNumber { get; set; }
        public string OrderID { get; set; }
        public string PromotionID { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool ValidEntry { get; set; }
        public bool WasSwiped { get; set; }
        public string Id { get; set; }
        public string InvalidEntryReason { get; set; }
    }
}
