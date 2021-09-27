using IdentityServer.Areas.HeliosAdminUI.Models.Clients.Submodel;

namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients
{
    public class CreateClientViewModel
    {
        public CreateClientViewModel()
        {
            ClientBasics = new ClientBasics();
            ClientAuthentificationLogout = new ClientAuthentificationLogout();
            ClientToken = new ClientToken();
            ClientConsentScreen = new ClientConsentScreen();
        }

        public ClientBasics ClientBasics { get; set; }
        public ClientAuthentificationLogout ClientAuthentificationLogout { get; set; }
        public ClientToken ClientToken { get; set; }
        public ClientConsentScreen ClientConsentScreen { get; set; }
    }
}
