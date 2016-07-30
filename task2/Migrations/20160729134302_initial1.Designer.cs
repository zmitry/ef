﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DatabaseApplication;

namespace task2.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20160729134302_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("DatabaseApplication.NavLink", b =>
                {
                    b.Property<int>("NavLinkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PageId");

                    b.Property<int>("ParentLinkID");

                    b.Property<int>("Position");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.HasKey("NavLinkId");

                    b.HasIndex("PageId");

                    b.HasIndex("ParentLinkID");

                    b.ToTable("NavLinks");
                });

            modelBuilder.Entity("DatabaseApplication.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<string>("UrlName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("DatabaseApplication.RelatedPage", b =>
                {
                    b.Property<int>("RelatedPageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Page1ID");

                    b.Property<int>("Page2ID");

                    b.HasKey("RelatedPageId");

                    b.HasIndex("Page1ID");

                    b.HasIndex("Page2ID");

                    b.ToTable("RelatedPages");
                });

            modelBuilder.Entity("DatabaseApplication.NavLink", b =>
                {
                    b.HasOne("DatabaseApplication.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseApplication.NavLink", "ParentLink")
                        .WithMany()
                        .HasForeignKey("ParentLinkID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatabaseApplication.RelatedPage", b =>
                {
                    b.HasOne("DatabaseApplication.Page", "Page1")
                        .WithMany()
                        .HasForeignKey("Page1ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatabaseApplication.Page", "Page2")
                        .WithMany()
                        .HasForeignKey("Page2ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}