// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cloudscribe.Core.Storage.EFCore.MSSQL;

namespace cloudscribe.Core.Storage.EFCore.MSSQL.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20190314195701_cs-core-20190314")]
    partial class cscore20190314
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cloudscribe.Core.Models.Geography.GeoCountry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("ISOCode2")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("ISOCode3")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ISOCode2");

                    b.ToTable("cs_GeoCountry");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.Geography.GeoZone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.HasIndex("CountryId");

                    b.ToTable("cs_GeoZone");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteHost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HostName");

                    b.HasIndex("SiteId");

                    b.ToTable("cs_SiteHost");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("NormalizedRoleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("NormalizedRoleName");

                    b.HasIndex("SiteId");

                    b.ToTable("cs_Role");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountApprovalEmailCsv");

                    b.Property<string>("AddThisDotComUsername")
                        .HasMaxLength(50);

                    b.Property<string>("AliasId")
                        .HasMaxLength(36);

                    b.Property<bool>("AllowNewRegistration")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowPersistentLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("CaptchaOnLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("CaptchaOnRegistration")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyCountry")
                        .HasMaxLength(10);

                    b.Property<string>("CompanyFax")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyLocality")
                        .HasMaxLength(200);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyPhone")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyPostalCode")
                        .HasMaxLength(20);

                    b.Property<string>("CompanyPublicEmail")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyRegion")
                        .HasMaxLength(200);

                    b.Property<string>("CompanyStreetAddress")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyStreetAddress2")
                        .HasMaxLength(250);

                    b.Property<string>("CompanyWebsite")
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("CookiePolicySummary")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("DefaultEmailFromAddress")
                        .HasMaxLength(100);

                    b.Property<string>("DefaultEmailFromAlias")
                        .HasMaxLength(100);

                    b.Property<bool>("DisableDbAuth")
                        .HasColumnType("bit");

                    b.Property<string>("DkimDomain")
                        .HasMaxLength(255);

                    b.Property<string>("DkimPrivateKey");

                    b.Property<string>("DkimPublicKey");

                    b.Property<string>("DkimSelector")
                        .HasMaxLength(128);

                    b.Property<string>("EmailApiEndpoint");

                    b.Property<string>("EmailApiKey");

                    b.Property<string>("EmailSenderName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasDefaultValue("SmtpMailSender");

                    b.Property<string>("FacebookAppId")
                        .HasMaxLength(100);

                    b.Property<string>("FacebookAppSecret");

                    b.Property<string>("FooterContent");

                    b.Property<string>("ForcedCulture")
                        .HasMaxLength(10);

                    b.Property<string>("ForcedUICulture")
                        .HasMaxLength(10);

                    b.Property<string>("GoogleAnalyticsProfileId")
                        .HasMaxLength(25);

                    b.Property<string>("GoogleClientId")
                        .HasMaxLength(100);

                    b.Property<string>("GoogleClientSecret");

                    b.Property<string>("HeaderContent");

                    b.Property<bool>("IsDataProtected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsServerAdminSite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("LdapDomain")
                        .HasMaxLength(255);

                    b.Property<int>("LdapPort");

                    b.Property<string>("LdapRootDN")
                        .HasMaxLength(255);

                    b.Property<string>("LdapServer")
                        .HasMaxLength(255);

                    b.Property<bool>("LdapUseSsl");

                    b.Property<string>("LdapUserDNFormat")
                        .HasMaxLength(100);

                    b.Property<string>("LdapUserDNKey")
                        .HasMaxLength(10);

                    b.Property<string>("LoginInfoBottom");

                    b.Property<string>("LoginInfoTop");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(250);

                    b.Property<int>("MaxInvalidPasswordAttempts");

                    b.Property<string>("MicrosoftClientId")
                        .HasMaxLength(100);

                    b.Property<string>("MicrosoftClientSecret");

                    b.Property<int>("MinRequiredPasswordLength");

                    b.Property<string>("OidConnectAppId")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectAppSecret")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectAuthority")
                        .HasMaxLength(255);

                    b.Property<string>("OidConnectDisplayName")
                        .HasMaxLength(150);

                    b.Property<string>("PreferredHostName")
                        .HasMaxLength(250);

                    b.Property<string>("PrivacyPolicy");

                    b.Property<bool>("PwdRequireDigit")
                        .HasColumnType("bit");

                    b.Property<bool>("PwdRequireLowercase")
                        .HasColumnType("bit");

                    b.Property<bool>("PwdRequireNonAlpha")
                        .HasColumnType("bit");

                    b.Property<bool>("PwdRequireUppercase")
                        .HasColumnType("bit");

                    b.Property<string>("RecaptchaPrivateKey")
                        .HasMaxLength(255);

                    b.Property<string>("RecaptchaPublicKey")
                        .HasMaxLength(255);

                    b.Property<string>("RegistrationAgreement");

                    b.Property<string>("RegistrationPreamble");

                    b.Property<bool>("Require2FA");

                    b.Property<bool>("RequireApprovalBeforeLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("RequireConfirmedEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("RequireConfirmedPhone")
                        .HasColumnType("bit");

                    b.Property<bool>("RequireCookieConsent");

                    b.Property<bool>("RequiresQuestionAndAnswer")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowSiteNameLink");

                    b.Property<bool>("SignEmailWithDkim")
                        .HasColumnType("bit");

                    b.Property<string>("SiteFolderName")
                        .HasMaxLength(50);

                    b.Property<bool>("SiteIsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("SiteIsClosedMessage");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SmsClientId")
                        .HasMaxLength(255);

                    b.Property<string>("SmsFrom")
                        .HasMaxLength(100);

                    b.Property<string>("SmsSecureToken");

                    b.Property<string>("SmtpPassword");

                    b.Property<int>("SmtpPort");

                    b.Property<string>("SmtpPreferredEncoding")
                        .HasMaxLength(20);

                    b.Property<bool>("SmtpRequiresAuth")
                        .HasColumnType("bit");

                    b.Property<string>("SmtpServer")
                        .HasMaxLength(200);

                    b.Property<bool>("SmtpUseSsl")
                        .HasColumnType("bit");

                    b.Property<string>("SmtpUser")
                        .HasMaxLength(500);

                    b.Property<DateTime>("TermsUpdatedUtc");

                    b.Property<string>("Theme")
                        .HasMaxLength(100);

                    b.Property<string>("TimeZoneId")
                        .HasMaxLength(50);

                    b.Property<string>("TwitterConsumerKey")
                        .HasMaxLength(100);

                    b.Property<string>("TwitterConsumerSecret");

                    b.Property<bool>("UseEmailForLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("UseInvisibleRecaptcha")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AliasId");

                    b.HasIndex("SiteFolderName");

                    b.ToTable("cs_Site");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.SiteUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("AccountApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("AgreementAcceptedUtc");

                    b.Property<string>("AuthorBio");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255);

                    b.Property<bool>("CanAutoLockout")
                        .HasColumnType("bit");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedUtc");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<bool>("DisplayInMemberList")
                        .HasColumnType("bit");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EmailConfirmSentUtc");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("Gender");

                    b.Property<bool>("IsLockedOut")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginUtc");

                    b.Property<DateTime>("LastModifiedUtc");

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastPasswordChangeUtc");

                    b.Property<DateTime?>("LockoutEndDateUtc");

                    b.Property<bool>("MustChangePwd")
                        .HasColumnType("bit");

                    b.Property<string>("NewEmail")
                        .HasMaxLength(100);

                    b.Property<bool>("NewEmailApproved")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("RolesChanged")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(50);

                    b.Property<string>("Signature");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TimeZoneId")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("WebSiteUrl")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DisplayName");

                    b.HasIndex("NormalizedEmail");

                    b.HasIndex("NormalizedUserName");

                    b.HasIndex("SiteId");

                    b.ToTable("cs_User");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(255);

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClaimType");

                    b.HasIndex("SiteId");

                    b.HasIndex("UserId");

                    b.ToTable("cs_UserClaim");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("CaptureCount");

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<string>("Continent")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .HasMaxLength(255);

                    b.Property<DateTime>("FirstCaptureUtc");

                    b.Property<string>("HostName")
                        .HasMaxLength(255);

                    b.Property<string>("IpAddress")
                        .HasMaxLength(50);

                    b.Property<long>("IpAddressLong");

                    b.Property<string>("Isp")
                        .HasMaxLength(255);

                    b.Property<DateTime>("LastCaptureUtc");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Region")
                        .HasMaxLength(255);

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TimeZone")
                        .HasMaxLength(255);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IpAddress");

                    b.HasIndex("UserId");

                    b.ToTable("cs_UserLocation");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserLogin", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(100);

                    b.HasKey("UserId", "SiteId", "LoginProvider", "ProviderKey");

                    b.HasIndex("SiteId");

                    b.HasIndex("UserId");

                    b.ToTable("cs_UserLogin");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("cs_UserRole");
                });

            modelBuilder.Entity("cloudscribe.Core.Models.UserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("SiteId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "SiteId", "LoginProvider", "Name");

                    b.HasIndex("SiteId");

                    b.HasIndex("UserId");

                    b.ToTable("cs_UserToken");
                });
#pragma warning restore 612, 618
        }
    }
}
