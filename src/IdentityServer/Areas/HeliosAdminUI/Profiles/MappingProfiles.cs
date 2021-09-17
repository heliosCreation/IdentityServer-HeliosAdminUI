using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.Create.ApiScopes;
using IdentityServer.Areas.HeliosAdminUI.Models.Update.ApiScopes;
using IdentityServer.Areas.HeliosAdminUI.Models.ViewModel;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer.Areas.HeliosAdminUI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApiScope, ApiScopeViewModel>();
            CreateMap<CreateApiScopeModel, ApiScope>();
            CreateMap<UpdateApiScopeViewModel, ApiScope>().ReverseMap();
        }
    }
}
