namespace IdentityServer.Areas.HeliosAdminUI.Models.Clients
{
    public enum GrantTypesEnum
    {
        Implicit,
        ImplicitAndClientCredentials,
        Code,
        CodeAndClientCredentials,
        Hybrid,
        HybridAndClientCredentials,
        ClientCredentials,
        ResourceOwnerPassword,
        ResourceOwnerPasswordAndClientCredentials,
        DeviceFlow
    }
}
