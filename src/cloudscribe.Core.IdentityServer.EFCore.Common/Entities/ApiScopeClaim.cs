﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace cloudscribe.Core.IdentityServer.EFCore.Entities
{
    public class ApiScopeClaim : UserClaim
    {
        public ApiScope ApiScope { get; set; }
    }
}
