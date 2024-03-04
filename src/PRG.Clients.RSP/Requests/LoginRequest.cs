namespace PRG.Clients.RSP.Requests;

internal class Navigator
{
    public string AppVersion { get; set; } = "5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
    public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
    public string AppName { get; set; } = "Netscape";
}

internal class LoginRequest
{
    public Navigator Navigator { get; set; } = new Navigator();
    public string Username { get; set; }
    public string Password { get; set; }
    public string WindowSize { get; set; } = "1920 x 382";

    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
