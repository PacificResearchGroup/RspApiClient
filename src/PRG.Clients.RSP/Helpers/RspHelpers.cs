using PRG.Clients.RSP.Exceptions;
using RestSharp;
using System.Text.RegularExpressions;

namespace PRG.Clients.RSP.Helpers
{
    internal static partial class RspHelpers
    {
        public static void ValidateMembershipNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new NotValidMembershipNumber("Membership number is empty");
            }

            int length = number.Count(char.IsDigit);
            if (length != 16)
            {
                throw new NotValidMembershipNumber();
            }
        }

        public static async Task<string> GetCsrfTokenAsync(RestClient client, CancellationToken ct)
        {
            RestResponse response = await client.GetAsync(new RestRequest());

            Regex regex = GetCsrfToken();
            Match match = regex.Match(response.Content);

            if (match.Success)
            {
                string output = match.Groups[1].Value;
                return output;
            }

            return "";
        }

        public static async Task<string> GetCsrfTokenAsync(HttpClient client, CancellationToken ct)
        {
            var response = await client.GetAsync("", ct);

            var html = await response.Content.ReadAsStringAsync(ct);

            Regex regex = GetCsrfToken();
            Match match = regex.Match(html);

            if (match.Success)
            {
                string output = match.Groups[1].Value;
                return output;
            }

            return "";
        }

        [GeneratedRegex("<meta name=\"csrf-token\" content=\"(.*?)\">")]
        private static partial Regex GetCsrfToken();
    }
}
