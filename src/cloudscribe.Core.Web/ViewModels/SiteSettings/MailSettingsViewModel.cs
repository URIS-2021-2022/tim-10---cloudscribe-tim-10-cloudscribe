// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2016-01-18
// Last Modified:			2018-05-07
// 

using cloudscribe.Core.Web.Components.Messaging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cloudscribe.Core.Web.ViewModels.SiteSettings
{
    public class MailSettingsViewModel
    {
        public MailSettingsViewModel()
        {
            AvailableEmailProviders = new List<SelectListItem>();
            TestMessage = new SiteMessageModel();
        }

        public Guid SiteId { get; set; } = Guid.Empty;

        public IList<SelectListItem> AvailableEmailProviders { get; set; }

        public string EmailSenderName { get; set; } = "SmtpMailSender";
        public string EmailApiKey { get; set; }
        public string EmailApiEndpoint { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email has a maximum length of 100 characters")]
        public string DefaultEmailFromAddress { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "Email alias has a maximum length of 100 characters")]
        public string DefaultEmailFromAlias { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Smtp User has a maximum length of 500 characters")]
        public string SmtpUser { get; set; } = string.Empty;
        
        public string SmtpPassword { get; set; } = string.Empty;
        [StringLength(200, ErrorMessage = "Smtp Server has a maximum length of 200 characters")]
        public string SmtpServer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Smtp Port cannot be left blank, if you are not using smtp just leave the default value of 25.")]
        [DisplayName("Smtp port")]
        [Range(0, int.MaxValue, ErrorMessage = "Smtp port is required to be an integer.")]
        public int? SmtpPort { get; set; } = 25;
        
        public bool SmtpRequiresAuth { get; set; } = false;
        
        public bool SmtpUseSsl { get; set; } = false;
        [StringLength(20, ErrorMessage = "Smtp Preferred Encoding has a maximum length of 20 characters")]
        public string SmtpPreferredEncoding { get; set; } = string.Empty;

        public SiteMessageModel TestMessage { get; set; }

    }
}
