﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cloudscribe.Core.IdentityServer.EFCore.SQLite;

namespace cloudscribe.Core.IdentityServer.EFCore.SQLite.Migrations.PersistedGrantDb
{
    [DbContext(typeof(PersistedGrantDbContext))]
    [Migration("20190109170809_csids-grants-20190109")]
    partial class csidsgrants20190109
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("cloudscribe.Core.IdentityServer.EFCore.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired();

                    b.Property<string>("SiteId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200);

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("SiteId");

                    b.ToTable("csids_DeviceFlowCodes");
                });

            modelBuilder.Entity("cloudscribe.Core.IdentityServer.EFCore.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data")
                        .IsRequired();

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("SiteId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200);

                    b.HasKey("Key", "Type");

                    b.HasIndex("SiteId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("SubjectId", "ClientId");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.ToTable("csids_PersistedGrants");
                });
#pragma warning restore 612, 618
        }
    }
}
