using Newtonsoft.Json.Serialization;
using PRG.Clients.RSP.Dtos;
using PRG.Clients.RSP.Helpers;
using PRG.Clients.RSP.Interfaces;
using PRG.Clients.RSP.Requests;
using PRG.Clients.RSP.Responses;
using PRG.Clients.RSP.ValueObjects;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Text;

namespace PRG.Clients.RSP
{
    public class RSPClient : IRSPClient
    {
        private readonly RestClientOptions _options;
        private RestClient _client;
        private readonly RspMapper _mapper;

        //public bool IsAuthenticated { get; set; } = false;

        public RSPClient(string url)
        {
            _mapper = new RspMapper();
            _options = new RestClientOptions
            {
                BaseUrl = new Uri(url),
                CookieContainer = new System.Net.CookieContainer(),
                FollowRedirects = true,
            };
            _client = CreateClient(_options);
        }

        private static RestClient CreateClient(RestClientOptions options)
        {
            return new RestClient(options, configureSerialization: b => b.UseNewtonsoftJson(new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }));
        }

        public async Task<ResponseDto> LoginAsync(string username, string password, CancellationToken ct)
        {
            string csrfToken = await RspHelpers.GetCsrfTokenAsync(_client, ct);

            _options.Authenticator = new CsrfAuthenticator(csrfToken);
            _client = CreateClient(_options);

            RestRequest request = new RestRequest("/login")
                .AddJsonBody(new LoginRequest(username, password));

            ResponseBase response = await _client.PostAsync<ResponseBase>(request, ct);
            return _mapper.MapResponseBase(response);
        }

        public async Task<GetUsersResponseDto> GetUsersAsync(int page, int limit, string filter, CancellationToken ct)
        {
            RestRequest request = new RestRequest("/users")
                .AddJsonBody(new GetUsersRequest(page, limit, filter));

            GetUsersResponse response = await _client.PostAsync<GetUsersResponse>(request, ct);
            return _mapper.MapUsers(response);
        }

        public async Task<MemberDto> ValidateMembershipNumberAsync(string number, bool swipe, CancellationToken ct)
        {
            RspHelpers.ValidateMembershipNumber(number);

            RestRequest request = new RestRequest($"/membership/validate/{number}")
                .AddQueryParameter("swipe", swipe.ToString().ToLower());

            ValidateMembershipResponse response = await _client.GetAsync<ValidateMembershipResponse>(request, ct);
            return _mapper.MapMember(response);

        }

        public async Task<ResponseDto> PromotionsEntryAsync(string number, bool cardWasSwiped, CancellationToken ct)
        {
            RspHelpers.ValidateMembershipNumber(number);

            RestRequest request = new RestRequest($"/promotions/entry/attempt")
                .AddQueryParameter("memberNumber", number)
                .AddQueryParameter("cardWasSwiped", cardWasSwiped.ToString().ToLower());

            ResponseBase response = await _client.GetAsync<ResponseBase>(request, ct);
            return _mapper.MapResponseBase(response);

        }

        public async Task<IReadOnlyCollection<string>> GetActivePromotionsAsync(string clubCode, CancellationToken ct)
        {
            // https://rspuat.national.aaa.com/promotions/list/004
            RestRequest request = new($"/promotions/list/{clubCode}");

            GetPromotionsResponse[] response = await _client.GetAsync<GetPromotionsResponse[]>(request, ct);
            return response
                .Where(x => string.Equals("In Progress", x.Status, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Id).ToList();
        }

        public async Task<PromotionEntryDto[]> GetPromotionEntriesAsync(string promotionId, int page, CancellationToken ct)
        {
            RestRequest request = new RestRequest($"/promotions/{promotionId}/entries")
                .AddQueryParameter("page", page)
                .AddQueryParameter("sort", "DESC")
                .AddQueryParameter("sortBy", "_id");

            GetPromotionEntriesResponse response = await _client.GetAsync<GetPromotionEntriesResponse>(request, ct);
            var output = _mapper.MapPromotionEntries(response.Records);
            return output;
        }

        public async Task<string> CreateNewOrderAsync(string firstName, string lastName, string member, string shopID, string phoneNumber, string type, CancellationToken ct)
        {
            RestRequest request = new("/orders/new");
            CreateNewOrderRequest body = new()
            {
                CardWasSwiped = false,
                FirstName = firstName,
                LastName = lastName,
                MemberNumber = member,
                PhoneNumber = phoneNumber,
                ShopID = shopID,
                Type = type,
                Validated = true,
            };
            request.AddJsonBody(body);

            RspOrderResponse response = await _client.PostAsync<RspOrderResponse>(request, ct);
            return response.OrderID;
        }

        public async Task<string> GetVoucherAsync(string promotionID, string entryID, CancellationToken ct)
        {
            RestRequest request = new RestRequest("/promotions/voucher/modal")
                .AddQueryParameter("promotionID", promotionID)
                .AddQueryParameter("entryID", entryID);

            string response = await _client.GetAsync<string>(request, ct);
            return response;
        }

        public async Task<string> PrintVoucherAsync(string promotionID, string entryID, CancellationToken ct)
        {
            RestRequest request = new RestRequest("/promotions/voucher/print")
                .AddQueryParameter("promotionID", promotionID)
                .AddQueryParameter("entryID", entryID);

            var response = await _client.GetAsync(request, ct);

            // replace src
            var html = new StringBuilder(response.Content);

            html.Replace("src='/", $"src='{_options.BaseUrl}");


            return html.ToString();
        }
    }
}
