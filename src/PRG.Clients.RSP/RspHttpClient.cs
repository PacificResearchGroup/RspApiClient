using Newtonsoft.Json;
using PRG.Clients.RSP.Dtos;
using PRG.Clients.RSP.Helpers;
using PRG.Clients.RSP.Interfaces;
using PRG.Clients.RSP.Requests;
using PRG.Clients.RSP.Responses;
using PRG.Clients.RSP.ValueObjects;
using RestSharp;
using System.Net.Http.Json;

namespace PRG.Clients.RSP
{
    public class RspHttpClient : IRSPClientAsync
    {
        private readonly RspMapper _mapper;
        private readonly HttpClient _client;

        public RspHttpClient(string baseURL)
        {
            _mapper = new RspMapper();
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseURL);
        }

        public async Task<ResponseDto> LoginAsync(string username, string password, CancellationToken ct)
        {
            string csrfToken = await RspHelpers.GetCsrfTokenAsync(_client, ct);
            _client.DefaultRequestHeaders.Add("Csrf-Token", csrfToken);

            var body = new LoginRequest(username, password);
            var response = await _client.PostAsJsonAsync("/login", body, ct);
            var data = await response.Content.ReadFromJsonAsync<ResponseBase>(ct);

            return _mapper.MapResponseBase(data);
        }

        public GetUsersResponseDto GetUsers(int page, int limit, string filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> PromotionsEntryAsync(string memberNumber, bool cardWasSwiped, CancellationToken ct)
        {
            RspHelpers.ValidateMembershipNumber(memberNumber);

            var response = await _client.GetAsync($"/promotions/entry/attempt?memberNumber={memberNumber}&cardWasSwiped={cardWasSwiped.ToString().ToLower()}", ct);
            var content = await response.Content.ReadFromJsonAsync<ResponseBase>(ct);

            return _mapper.MapResponseBase(content);
        }

        public async Task<MemberDto> ValidateMembershipNumberAsync(string number, bool swipe, CancellationToken ct)
        {
            RspHelpers.ValidateMembershipNumber(number);

            var response = await _client.GetAsync($"/membership/validate/{number}?swipe={swipe.ToString().ToLower()}", ct);
            var content = await response.Content.ReadFromJsonAsync<ValidateMembershipResponse>(ct);

            return _mapper.MapMember(content);
        }
    }
}
