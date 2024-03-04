using PRG.Clients.RSP.Responses;
using Riok.Mapperly.Abstractions;

namespace PRG.Clients.RSP.Dtos
{
    [Mapper]
    internal partial class RspMapper
    {
        public partial GetUsersResponseDto MapUsers(GetUsersResponse response);
        public partial MemberDto MapMember(ValidateMembershipResponse response);
        public partial PromotionEntryDto[] MapPromotionEntries(List<PromotionEntryRecord> records);

        [MapProperty($"{nameof(PromotionEntryRecord.Member)}.{nameof(Member.MemberNumber)}", nameof(Member.MemberNumber))]
        public partial PromotionEntryDto MapPromotionEntry(PromotionEntryRecord records);
        public partial ResponseDto MapResponseBase(ResponseBase response);
    }
}
