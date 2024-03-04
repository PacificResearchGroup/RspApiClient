namespace PRG.Clients.RSP.Responses
{

    internal class GetPromotionEntriesResponse
    {
        public int Count { get; set; }
        public List<PromotionEntryRecord> Records { get; set; }
    }


}
