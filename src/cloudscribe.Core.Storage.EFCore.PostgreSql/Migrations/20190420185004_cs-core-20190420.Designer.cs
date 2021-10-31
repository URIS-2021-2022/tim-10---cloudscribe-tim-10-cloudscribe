﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using cloudscribe.Core.Storage.EFCore.PostgreSql;

namespace cloudscribe.Core.Storage.EFCore.PostgreSql.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20190420185004_cs-core-20190420")]
    partial class cscore20190420
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("cloudscribe.Core.Models.Geography.GeoCountry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ISOCode2")
                        .IsRequired()
                        .HasColumnName("iso_code2")
                        .HasMaxLength(2);

                    b.Property<string>("ISOCode3")
                        .IsRequired()
                        .HasColumnName("iso_code3")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_cs_geo_country");

                    b.HasIndex("ISOCode2")
                        .HasName("ix_cs_geo_country_iso_code2");

                    b.ToTable("cs_geo_country");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.Geography.GeoZone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(255);

                    b.Property<Guid>("CountryId")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_cs_geo_zone");

                    b.HasIndex("Code")
                        .HasName("ix_cs_geo_zone_code");

                    b.HasIndex("CountryId")
                        .HasName("ix_cs_geo_zone_country_id");

                    b.ToTable("cs_geo_zone");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteHost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasColumnName("host_name")
                        .HasMaxLength(255);

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.HasKey("Id")
                        .HasName("pk_cs_site_host");

                    b.HasIndex("HostName")
                        .HasName("ix_cs_site_host_host_name");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_site_host_site_id");

                    b.ToTable("cs_site_host");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("NormalizedRoleName")
                        .IsRequired()
                        .HasColumnName("normalized_role_name")
                        .HasMaxLength(50);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("role_name")
                        .HasMaxLength(50);

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.HasKey("Id")
                        .HasName("pk_cs_role");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("ix_cs_role_id");

                    b.HasIndex("NormalizedRoleName")
                        .HasName("ix_cs_role_normalized_role_name");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_role_site_id");

                    b.ToTable("cs_role");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AccountApprovalEmailCsv")
                        .HasColumnName("account_approval_email_csv");

                    b.Property<string>("AddThisDotComUsername")
                        .HasColumnName("add_this_dot_com_username")
                        .HasMaxLength(50);

                    b.Property<string>("AliasId")
                        .HasColumnName("alias_id")
                        .HasMaxLength(36);

                    b.Property<bool>("AllowNewRegistration")
                        .HasColumnName("allow_new_registration");

                    b.Property<bool>("AllowPersistentLogin")
                        .HasColumnName("allow_persistent_login");

                    b.Property<bool>("CaptchaOnLogin")
                        .HasColumnName("captcha_on_login");

                    b.Property<bool>("CaptchaOnRegistration")
                        .HasColumnName("captcha_on_registration");

                    b.Property<string>("CompanyCountry")
                        .HasColumnName("company_country")
                        .HasMaxLength(10);

                    b.Property<string>("CompanyFax")
                        .HasColumnName("company_fax")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyLocality")
                        .HasColumnName("company_locality")
                        .HasMaxLength(200);

                    b.Property<string>("CompanyName")
                        .HasColumnName("company_name")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyPhone")
                        .HasColumnName("company_phone")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyPostalCode")
                        .HasColumnName("company_postal_code")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyPublicEmail")
                        .HasColumnName("company_public_email")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyRegion")
                        .HasColumnName("company_region")
                        .HasMaxLength(200);

                    b.Property<string>("CompanyStreetAddress")
                        .HasColumnName("company_street_address")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyStreetAddress2")
                        .HasColumnName("company_street_address2")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyWebsite")
                        .HasColumnName("company_website")
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("CookiePolicySummary")
                        .HasColumnName("cookie_policy_summary")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnName("created_utc");

                    b.Property<string>("DefaultEmailFromAddress")
                        .HasColumnName("default_email_from_address")
                        .HasMaxLength(100);

                    b.Property<string>("DefaultEmailFromAlias")
                        .HasColumnName("default_email_from_alias")
                        .HasMaxLength(100);

                    b.Property<bool>("DisableDbAuth")
                        .HasColumnName("disable_db_auth");

                    b.Property<string>("DkimDomain")
                        .HasColumnName("dkim_domain")
                        .HasMaxLength(255);

                    b.Property<string>("DkimPrivateKey")
                        .HasColumnName("dkim_private_key");

                    b.Property<string>("DkimPublicKey")
                        .HasColumnName("dkim_public_key");

                    b.Property<string>("DkimSelector")
                        .HasColumnName("dkim_selector")
                        .HasMaxLength(128);

                    b.Property<string>("EmailApiEndpoint")
                        .HasColumnName("email_api_endpoint");

                    b.Property<string>("EmailApiKey")
                        .HasColumnName("email_api_key");

                    b.Property<string>("EmailSenderName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("email_sender_name")
                        .HasMaxLength(100)
                        .HasDefaultValue("SmtpMailSender");

                    b.Property<string>("FacebookAppId")
                        .HasColumnName("facebook_app_id")
                        .HasMaxLength(100);

                    b.Property<string>("FacebookAppSecret")
                        .HasColumnName("facebook_app_secret");

                    b.Property<string>("FooterContent")
                        .HasColumnName("footer_content");

                    b.Property<string>("ForcedCulture")
                        .HasColumnName("forced_culture")
                        .HasMaxLength(10);

                    b.Property<string>("ForcedUICulture")
                        .HasColumnName("forced_ui_culture")
                        .HasMaxLength(10);

                    b.Property<string>("GoogleAnalyticsProfileId")
                        .HasColumnName("google_analytics_profile_id")
                        .HasMaxLength(25);

                    b.Property<string>("GoogleClientId")
                        .HasColumnName("google_client_id")
                        .HasMaxLength(100);

                    b.Property<string>("GoogleClientSecret")
                        .HasColumnName("google_client_secret");

                    b.Property<string>("HeaderContent")
                        .HasColumnName("header_content");

                    b.Property<bool>("IsDataProtected")
                        .HasColumnName("is_data_protected");

                    b.Property<bool>("IsServerAdminSite")
                        .HasColumnName("is_server_admin_site");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnName("last_modified_utc");

                    b.Property<string>("LdapDomain")
                        .HasColumnName("ldap_domain")
                        .HasMaxLength(255);

                    b.Property<int>("LdapPort")
                        .HasColumnName("ldap_port");

                    b.Property<string>("LdapRootDN")
                        .HasColumnName("ldap_root_dn")
                        .HasMaxLength(255);

                    b.Property<string>("LdapServer")
                        .HasColumnName("ldap_server")
                        .HasMaxLength(255);

                    b.Property<bool>("LdapUseSsl")
                        .HasColumnName("ldap_use_ssl");

                    b.Property<string>("LdapUserDNFormat")
                        .HasColumnName("ldap_user_dn_format")
                        .HasMaxLength(100);

                    b.Property<string>("LdapUserDNKey")
                        .HasColumnName("ldap_user_dn_key")
                        .HasMaxLength(10);

                    b.Property<string>("LoginInfoBottom")
                        .HasColumnName("login_info_bottom");

                    b.Property<string>("LoginInfoTop")
                        .HasColumnName("login_info_top");

                    b.Property<string>("LogoUrl")
                        .HasColumnName("logo_url")
                        .HasMaxLength(250);

                    b.Property<int>("MaxInvalidPasswordAttempts")
                        .HasColumnName("max_invalid_password_attempts");

                    b.Property<string>("MicrosoftClientId")
                        .HasColumnName("microsoft_client_id")
                        .HasMaxLength(100);

                    b.Property<string>("MicrosoftClientSecret")
                        .HasColumnName("microsoft_client_secret");

                    b.Property<int>("MinRequiredPasswordLength")
                        .HasColumnName("min_required_password_length");

                    b.Property<string>("OidConnectAppId")
                        .HasColumnName("oid_connect_app_id")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectAppSecret")
                        .HasColumnName("oid_connect_app_secret")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectAuthority")
                        .HasColumnName("oid_connect_authority")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectDisplayName")
                        .HasColumnName("oid_connect_display_name")
                        .HasMaxLength(150);

                    b.Property<string>("OidConnectScopesCsv")
                        .HasColumnName("oid_connect_scopes_csv");

                    b.Property<string>("PreferredHostName")
                        .HasColumnName("preferred_host_name")
                        .HasMaxLength(250);

                    b.Property<string>("PrivacyPolicy")
                        .HasColumnName("privacy_policy");

                    b.Property<bool>("PwdRequireDigit")
                        .HasColumnName("pwd_require_digit");

                    b.Property<bool>("PwdRequireLowercase")
                        .HasColumnName("pwd_require_lowercase");

                    b.Property<bool>("PwdRequireNonAlpha")
                        .HasColumnName("pwd_require_non_alpha");

                    b.Property<bool>("PwdRequireUppercase")
                        .HasColumnName("pwd_require_uppercase");

                    b.Property<string>("RecaptchaPrivateKey")
                        .HasColumnName("recaptcha_private_key")
                        .HasMaxLength(255);

                    b.Property<string>("RecaptchaPublicKey")
                        .HasColumnName("recaptcha_public_key")
                        .HasMaxLength(255);

                    b.Property<string>("RegistrationAgreement")
                        .HasColumnName("registration_agreement");

                    b.Property<string>("RegistrationPreamble")
                        .HasColumnName("registration_preamble");

                    b.Property<bool>("Require2FA")
                        .HasColumnName("require2_fa");

                    b.Property<bool>("RequireApprovalBeforeLogin")
                        .HasColumnName("require_approval_before_login");

                    b.Property<bool>("RequireConfirmedEmail")
                        .HasColumnName("require_confirmed_email");

                    b.Property<bool>("RequireConfirmedPhone")
                        .HasColumnName("require_confirmed_phone");

                    b.Property<bool>("RequireCookieConsent")
                        .HasColumnName("require_cookie_consent");

                    b.Property<bool>("RequiresQuestionAndAnswer")
                        .HasColumnName("requires_question_and_answer");

                    b.Property<bool>("ShowSiteNameLink")
                        .HasColumnName("show_site_name_link");

                    b.Property<bool>("SignEmailWithDkim")
                        .HasColumnName("sign_email_with_dkim");

                    b.Property<bool>("SingleBrowserSessions")
                        .HasColumnName("single_browser_sessions");

                    b.Property<string>("SiteFolderName")
                        .HasColumnName("site_folder_name")
                        .HasMaxLength(50);

                    b.Property<bool>("SiteIsClosed")
                        .HasColumnName("site_is_closed");

                    b.Property<string>("SiteIsClosedMessage")
                        .HasColumnName("site_is_closed_message");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnName("site_name")
                        .HasMaxLength(255);

                    b.Property<string>("SmsClientId")
                        .HasColumnName("sms_client_id")
                        .HasMaxLength(255);

                    b.Property<string>("SmsFrom")
                        .HasColumnName("sms_from")
                        .HasMaxLength(100);

                    b.Property<string>("SmsSecureToken")
                        .HasColumnName("sms_secure_token");

                    b.Property<string>("SmtpPassword")
                        .HasColumnName("smtp_password");

                    b.Property<int>("SmtpPort")
                        .HasColumnName("smtp_port");

                    b.Property<string>("SmtpPreferredEncoding")
                        .HasColumnName("smtp_preferred_encoding")
                        .HasMaxLength(20);

                    b.Property<bool>("SmtpRequiresAuth")
                        .HasColumnName("smtp_requires_auth");

                    b.Property<string>("SmtpServer")
                        .HasColumnName("smtp_server")
                        .HasMaxLength(200);

                    b.Property<bool>("SmtpUseSsl")
                        .HasColumnName("smtp_use_ssl");

                    b.Property<string>("SmtpUser")
                        .HasColumnName("smtp_user")
                        .HasMaxLength(500);

                    b.Property<DateTime>("TermsUpdatedUtc")
                        .HasColumnName("terms_updated_utc");

                    b.Property<string>("Theme")
                        .HasColumnName("theme")
                        .HasMaxLength(100);

                    b.Property<string>("TimeZoneId")
                        .HasColumnName("time_zone_id")
                        .HasMaxLength(50);

                    b.Property<string>("TwitterConsumerKey")
                        .HasColumnName("twitter_consumer_key")
                        .HasMaxLength(100);

                    b.Property<string>("TwitterConsumerSecret")
                        .HasColumnName("twitter_consumer_secret");

                    b.Property<bool>("UseEmailForLogin")
                        .HasColumnName("use_email_for_login");

                    b.Property<bool>("UseInvisibleRecaptcha")
                        .HasColumnName("use_invisible_recaptcha");

                    b.HasKey("Id")
                        .HasName("pk_cs_site");

                    b.HasIndex("AliasId")
                        .HasName("ix_cs_site_alias_id");

                    b.HasIndex("SiteFolderName")
                        .HasName("ix_cs_site_site_folder_name");

                    b.ToTable("cs_site");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<bool>("AccountApproved")
                        .HasColumnName("account_approved");

                    b.Property<DateTime?>("AgreementAcceptedUtc")
                        .HasColumnName("agreement_accepted_utc");

                    b.Property<string>("AuthorBio")
                        .HasColumnName("author_bio");

                    b.Property<string>("AvatarUrl")
                        .HasColumnName("avatar_url")
                        .HasMaxLength(255);

                    b.Property<string>("BrowserKey")
                        .HasColumnName("browser_key")
                        .HasMaxLength(50);

                    b.Property<bool>("CanAutoLockout")
                        .HasColumnName("can_auto_lockout");

                    b.Property<string>("Comment")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnName("created_utc");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnName("date_of_birth");

                    b.Property<bool>("DisplayInMemberList")
                        .HasColumnName("display_in_member_list");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EmailConfirmSentUtc")
                        .HasColumnName("email_confirm_sent_utc");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .HasColumnName("first_name")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .HasColumnName("gender");

                    b.Property<bool>("IsLockedOut")
                        .HasColumnName("is_locked_out");

                    b.Property<DateTime?>("LastLoginUtc")
                        .HasColumnName("last_login_utc");

                    b.Property<DateTime>("LastModifiedUtc")
                        .HasColumnName("last_modified_utc");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastPasswordChangeUtc")
                        .HasColumnName("last_password_change_utc");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnName("lockout_end_date_utc");

                    b.Property<bool>("MustChangePwd")
                        .HasColumnName("must_change_pwd");

                    b.Property<string>("NewEmail")
                        .HasColumnName("new_email")
                        .HasMaxLength(100);

                    b.Property<bool>("NewEmailApproved")
                        .HasColumnName("new_email_approved");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnName("normalized_user_name")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number")
                        .HasMaxLength(50);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<bool>("RolesChanged")
                        .HasColumnName("roles_changed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp")
                        .HasMaxLength(50);

                    b.Property<string>("Signature")
                        .HasColumnName("signature");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.Property<string>("TimeZoneId")
                        .HasColumnName("time_zone_id")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasMaxLength(50);

                    b.Property<string>("WebSiteUrl")
                        .HasColumnName("web_site_url")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("pk_cs_user");

                    b.HasIndex("DisplayName")
                        .HasName("ix_cs_user_display_name");

                    b.HasIndex("NormalizedEmail")
                        .HasName("ix_cs_user_normalized_email");

                    b.HasIndex("NormalizedUserName")
                        .HasName("ix_cs_user_normalized_user_name");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_user_site_id");

                    b.ToTable("cs_user");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type")
                        .HasMaxLength(255);

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_cs_user_claim");

                    b.HasIndex("ClaimType")
                        .HasName("ix_cs_user_claim_claim_type");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_user_claim_site_id");

                    b.HasIndex("UserId")
                        .HasName("ix_cs_user_claim_user_id");

                    b.ToTable("cs_user_claim");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CaptureCount")
                        .HasColumnName("capture_count");

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(255);

                    b.Property<string>("Continent")
                        .HasColumnName("continent")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasMaxLength(255);

                    b.Property<DateTime>("FirstCaptureUtc")
                        .HasColumnName("first_capture_utc");

                    b.Property<string>("HostName")
                        .HasColumnName("host_name")
                        .HasMaxLength(255);

                    b.Property<string>("IpAddress")
                        .HasColumnName("ip_address")
                        .HasMaxLength(50);

                    b.Property<long>("IpAddressLong")
                        .HasColumnName("ip_address_long");

                    b.Property<string>("Isp")
                        .HasColumnName("isp")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastCaptureUtc")
                        .HasColumnName("last_capture_utc");

                    b.Property<double>("Latitude")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnName("longitude");

                    b.Property<string>("Region")
                        .HasColumnName("region")
                        .HasMaxLength(255);

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.Property<string>("TimeZone")
                        .HasColumnName("time_zone")
                        .HasMaxLength(255);

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_cs_user_location");

                    b.HasIndex("IpAddress")
                        .HasName("ix_cs_user_location_ip_address");

                    b.HasIndex("UserId")
                        .HasName("ix_cs_user_location_user_id");

                    b.ToTable("cs_user_location");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserLogin", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name")
                        .HasMaxLength(100);

                    b.HasKey("UserId", "SiteId", "LoginProvider", "ProviderKey")
                        .HasName("pk_cs_user_login");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_user_login_site_id");

                    b.HasIndex("UserId")
                        .HasName("ix_cs_user_login_user_id");

                    b.ToTable("cs_user_login");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_cs_user_role");

                    b.HasIndex("RoleId")
                        .HasName("ix_cs_user_role_role_id");

                    b.HasIndex("UserId")
                        .HasName("ix_cs_user_role_user_id");

                    b.ToTable("cs_user_role");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.Property<Guid>("SiteId")
                        .HasColumnName("site_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(450);

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "SiteId", "LoginProvider", "Name")
                        .HasName("pk_cs_user_token");

                    b.HasIndex("SiteId")
                        .HasName("ix_cs_user_token_site_id");

                    b.HasIndex("UserId")
                        .HasName("ix_cs_user_token_user_id");

                    b.ToTable("cs_user_token");
                });
#pragma warning restore 612, 618
        }
    }
}
