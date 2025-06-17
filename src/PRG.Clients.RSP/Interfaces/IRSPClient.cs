using PRG.Clients.RSP.Dtos;
using PRG.Clients.RSP.Requests;

namespace PRG.Clients.RSP.Interfaces
{
    public interface IRSPClient
    {
        Task<string> CreateNewOrderAsync(string firstName, string lastName, string member, string shopID, string phoneNumber, string type, CancellationToken ct);
        Task<PromotionEntryDto[]> GetPromotionEntriesAsync(string promotionId, int page, CancellationToken ct);
        Task<GetUsersResponseDto> GetUsersAsync(int page, int limit, string filter, CancellationToken ct);
        Task<string> GetVoucherAsync(string promotionID, string entryID, CancellationToken ct);
        Task<ResponseDto> LoginAsync(string username, string password, CancellationToken ct);
        Task<string> PrintVoucherAsync(string promotionID, string entryID, CancellationToken ct);
        Task<ResponseDto> PromotionsEntryAsync(string number, bool cardWasSwiped, CancellationToken ct);
        Task<MemberDto> ValidateMembershipNumberAsync(string number, bool swipe, CancellationToken ct);
        Task<IReadOnlyCollection<string>> GetActivePromotionsAsync(string clubCode, CancellationToken ct);
        Task<string> CreateNewOrderAsync(string firstName, string lastName, string member, string shopID, string phoneNumber, string type, VehicleDto vehicle, CancellationToken ct);
    }

    public interface IRSPClientAsync
    {
        Task<ResponseDto> LoginAsync(string username, string password, CancellationToken ct);
        Task<ResponseDto> PromotionsEntryAsync(string memberNumber, bool cardWasSwiped, CancellationToken ct);
        Task<MemberDto> ValidateMembershipNumberAsync(string number, bool swipe, CancellationToken ct);
    }
}
