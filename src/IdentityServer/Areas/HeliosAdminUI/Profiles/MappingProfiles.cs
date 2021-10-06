using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes;
using IdentityServer.Areas.HeliosAdminUI.Models.Clients;
using IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources;
using System.Linq;
using System.Collections.Generic;
using Entities = IdentityServer4.EntityFramework.Entities;
using ModelEntities = IdentityServer4.Models;
using IdentityServer4.Models;
using IdentityServer.Models;
using IdentityServer.Areas.HeliosAdminUI.Models.UserManagement;

namespace IdentityServer.Areas.HeliosAdminUI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region ApiScopes
            CreateMap<Entities.ApiScope, ApiScopeViewModel>();
            CreateMap<CreateApiScopeModel, Entities.ApiScope>();
            CreateMap<UpdateApiScopeViewModel, Entities.ApiScope>().ReverseMap();
            #endregion

            #region IdentityResources
            CreateMap<Entities.IdentityResource, IdentityResourceViewModel>()
                .ForMember(m => m.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(u => u.Type)));
            CreateMap<Entities.IdentityResource, UpdateIdentityResourceViewModel>().ReverseMap();
            CreateMap<CreateIdentityResourceViewModel, Entities.IdentityResource>();
            #endregion

            #region Client
            CreateMap<Entities.Client, ClientViewModel>()
                .ForMember(c => c.AllowedGrantTypes, opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(a => a.GrantType)))
                .ForMember(c => c.AllowedScopes, opt => opt.MapFrom(src => src.AllowedScopes.Select(a => a.Scope)))
                .ForMember(c => c.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris[0].RedirectUri))
                .ForMember(c => c.PostLogoutRedirectUris, opt => opt.MapFrom(src => src.PostLogoutRedirectUris[0].PostLogoutRedirectUri));

            CreateMap<CreateClientViewModel, ModelEntities.Client>()
                .ForMember(c => c.ClientSecrets, opt => opt.MapFrom(src => new List<ModelEntities.Secret>
                {
                    new ModelEntities.Secret(src.ClientSecrets.Sha256(), null)
                }))
                .ForMember(c => c.RedirectUris, opt => opt.MapFrom(src => new List<string> { src.RedirectUris }))
                .ForMember(c => c.PostLogoutRedirectUris, opt => opt.MapFrom(src => new List<string> { src.PostLogoutRedirectUris }));

            CreateMap<Entities.Client, UpdateClientViewModel>()
            .ForMember(c => c.PostLogoutRedirectUris, opt => opt.MapFrom(src => src.PostLogoutRedirectUris[0].PostLogoutRedirectUri))
            .ForMember(c => c.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris[0].RedirectUri))
            .ForMember(c => c.AllowedScopesString, opt => opt.MapFrom(src => string.Join(",", src.AllowedScopes.Select(s => s.Scope))) );

            CreateMap<UpdateClientViewModel, ModelEntities.Client>()
                .ForMember(c => c.RedirectUris, opt => opt.MapFrom(src => new List<string> { src.RedirectUris }))
                .ForMember(c => c.PostLogoutRedirectUris, opt => opt.MapFrom(src => new List<string> { src.PostLogoutRedirectUris }));

            #endregion

            #region Users
            CreateMap<ApplicationUser, UserWithRoles>();
            CreateMap<ApplicationUser, UpdateUseRolesViewModel>().ReverseMap();
            CreateMap<CreateUserWithRoleWithViewModel, ApplicationUser>();
            #endregion

        }
    }
}
