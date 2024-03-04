using System.Net.NetworkInformation;

namespace PRG.Clients.RSP.Responses
{
    internal class Address
    {
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public object Country { get; set; }
    }


}
