using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes;
using IdentityServer.Areas.HeliosAdminUI.Models.Clients;
using IdentityServer.Areas.HeliosAdminUI.Models.IdentityResources;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.Areas.HeliosAdminUI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApiScope, ApiScopeViewModel>();
            CreateMap<CreateApiScopeModel, ApiScope>();
            CreateMap<UpdateApiScopeViewModel, ApiScope>().ReverseMap();

            CreateMap<IdentityResource, IdentityResourceViewModel>()
                .ForMember(m => m.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(u => u.Type)));
            CreateMap<IdentityResource, UpdateIdentityResourceViewModel>().ReverseMap();
            CreateMap<CreateIdentityResourceViewModel, IdentityResource>();

            CreateMap<Client, ClientViewModel>()
                .ForMember(c => c.AllowedGrantTypes, opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(a => a.GrantType)))
                .ForMember(c => c.AllowedScopes, opt => opt.MapFrom(src => src.AllowedScopes.Select(a => a.Scope)))
                .ForMember(c => c.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris[0].RedirectUri))
                .ForMember(c => c.PostLogoutRedirectUris, opt => opt.MapFrom(src => src.PostLogoutRedirectUris[0].PostLogoutRedirectUri));
        }

    }
}
