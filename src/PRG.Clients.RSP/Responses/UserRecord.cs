using Newtonsoft.Json;

namespace PRG.Clients.RSP.Responses
{
    internal class UserRecord
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
        public List<Club> Clubs { get; set; }
        public object DaysUntilPasswordExpiration { get; set; }
        public bool SessionActive { get; set; }
    }

    public class GetPromotionsResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string ClubCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<string, string> Title { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Participation { get; set; }
    }
}
