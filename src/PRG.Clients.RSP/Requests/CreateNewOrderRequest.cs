namespace PRG.Clients.RSP.Requests;

internal class CreateNewOrderRequest
{
    public bool CardWasSwiped { get; set; }
    public string Type { get; set; }
    public string MemberNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool Validated { get; set; }
    public string ShopID { get; set; }
}
