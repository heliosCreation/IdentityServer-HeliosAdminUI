using AutoMapper;
using IdentityServer.Areas.HeliosAdminUI.Models.ApiScopes;
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
        }

    }
}
