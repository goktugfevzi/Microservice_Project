// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MicroServices.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes ={ "catalog_fullpermission"}},
                new ApiResource("resource_photo_stock") { Scopes ={ "photo_stock_fullpermission"}},
                    new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
                        new ApiResource("resource_discount"){Scopes={"discount_fullpermission"}},
                            new ApiResource("resource_order"){Scopes={"order_fullpermission"}},
                                new ApiResource("resource_payment"){Scopes={"payment_fullpermission"}},
                                    new ApiResource("resource_cargo"){Scopes={"cargo_fullpermission"}},
                                    new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                  new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource()
                {Name="roles", DisplayName="Roles",Description="Kullanıcı Rolleri",UserClaims=new []{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {

                new ApiScope("catalog_fullpermission","Catalog API için full erişim"),
                new ApiScope("photo_stock_fullpermission","photo_stock API için full erişim"),
                new ApiScope("basket_fullpermission","basket API için full erişim"),
                new ApiScope("discount_fullpermission","discount API için full erişim"),
                new ApiScope("order_fullpermission","order API için full erişim"),
                new ApiScope("payment_fullpermission","payment API için full erişim"),
                new ApiScope("gateway_fullpermission","gateway API için full erişim"),
                new ApiScope("cargo_fullpermission","cargo API için full erişim"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "Casgem1",
                    ClientName = "CoreClient1",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={"catalog_fullpermission","photo_stock_fullpermission",IdentityServerConstants.LocalApi.ScopeName}
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "Casgem2",
                    ClientName = "CoreClient2",
                    AllowOfflineAccess=true,
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "photo_stock_fullpermission", "catlog_fullpermission","basket_fullpermission","order_fullpermission","discount_fullpermission","cargo_fullpermission", "payment_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,"roles"},
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                },
            };
    }
}