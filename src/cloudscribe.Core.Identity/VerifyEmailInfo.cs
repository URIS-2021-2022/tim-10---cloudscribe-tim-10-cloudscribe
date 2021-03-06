// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2017-05-23
// Last Modified:			2017-05-23
// 

using cloudscribe.Core.Models;

namespace cloudscribe.Core.Identity
{
    public class VerifyEmailInfo
    {
        public VerifyEmailInfo(
            IUserContext user,
            string emailVerificationToken
            )
        {
            User = user;
            EmailVerificationToken = emailVerificationToken;

        }

        public IUserContext User { get; }
        public string EmailVerificationToken { get; }
    }
}
