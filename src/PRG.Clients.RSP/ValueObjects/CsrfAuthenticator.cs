using RestSharp;
using RestSharp.Authenticators;

namespace PRG.Clients.RSP.ValueObjects
{
    internal class CsrfAuthenticator : IAuthenticator
    {
        private readonly string _csrfToken;

        public CsrfAuthenticator(string csrfToken)
        {
            _csrfToken = csrfToken;
        }

        public ValueTask Authenticate(IRestClient client, RestRequest request)
        {
            request.AddHeader("Csrf-Token", _csrfToken);
            return ValueTask.CompletedTask;
        }
    }
}
