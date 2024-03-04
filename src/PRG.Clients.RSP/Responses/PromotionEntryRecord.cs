using Newtonsoft.Json;

namespace PRG.Clients.RSP.Responses
{
    internal class PromotionEntryRecord
    {
        public bool ValidEntry { get; set; }
        public object InvalidEntryReason { get; set; }
        public bool IsWinner { get; set; }
        public string AwardValue { get; set; }
        public string OrderID { get; set; }
        public bool WasSwiped { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        public Member Member { get; set; }
        public string PromotionID { get; set; }
        public DateTime TimeCreated { get; set; }
    }


}
