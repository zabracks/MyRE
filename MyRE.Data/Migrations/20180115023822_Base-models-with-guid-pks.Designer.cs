﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MyRE.Core.Models.Data;
using MyRE.Data;
using System;

namespace MyRE.Data.Migrations
{
    [DbContext(typeof(MyREContext))]
    [Migration("20180115023822_Base-models-with-guid-pks")]
    partial class Basemodelswithguidpks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RemoteAccountId")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("AccountId");

                    b.HasAlternateKey("RemoteAccountId")
                        .HasName("UNQ_RemoteAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.AppInstance", b =>
                {
                    b.Property<Guid>("AppInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<Guid>("AccountId");

                    b.Property<string>("InstanceServerBaseUri");

                    b.Property<string>("Name");

                    b.Property<string>("RemoteAppId")
                        .IsRequired();

                    b.HasKey("AppInstanceId");

                    b.HasAlternateKey("RemoteAppId")
                        .HasName("UNQ_RemoteAppId");

                    b.HasIndex("AccountId");

                    b.ToTable("AppInstances");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Block", b =>
                {
                    b.Property<Guid>("BlockId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("BlockId");

                    b.ToTable("Block");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.BlockStatement", b =>
                {
                    b.Property<Guid>("BlockStatementId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BlockId");

                    b.Property<int>("Position");

                    b.Property<Guid?>("StatementId");

                    b.HasKey("BlockStatementId");

                    b.HasIndex("BlockId");

                    b.HasIndex("StatementId");

                    b.ToTable("BlockStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Expression", b =>
                {
                    b.Property<Guid>("ExpressionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("ExpressionId");

                    b.ToTable("Expressions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Expression");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.FunctionParameter", b =>
                {
                    b.Property<Guid>("FunctionParameterId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("InvocationExpressionExpressionId");

                    b.Property<int>("Position");

                    b.Property<Guid?>("ValueExpressionId");

                    b.HasKey("FunctionParameterId");

                    b.HasIndex("InvocationExpressionExpressionId");

                    b.HasIndex("ValueExpressionId");

                    b.ToTable("FunctionParameter");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid>("ParentInstanceId");

                    b.HasKey("ProjectId");

                    b.HasIndex("ParentInstanceId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Routine", b =>
                {
                    b.Property<Guid>("RoutineId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BlockId");

                    b.Property<string>("Description")
                        .HasMaxLength(4096);

                    b.Property<int>("ExecutionMethod");

                    b.Property<string>("Name")
                        .HasMaxLength(1024);

                    b.Property<Guid?>("ProjectId");

                    b.HasKey("RoutineId");

                    b.HasIndex("BlockId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Statement", b =>
                {
                    b.Property<Guid>("StatementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("StatementId");

                    b.ToTable("Statements");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Statement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.InvocationExpression", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Expression");

                    b.Property<string>("FunctionName")
                        .HasMaxLength(64);

                    b.ToTable("InvocationExpression");

                    b.HasDiscriminator().HasValue("InvocationExpression");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.LiteralExpression", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Expression");

                    b.Property<string>("Value");

                    b.Property<int>("ValueType");

                    b.ToTable("LiteralExpression");

                    b.HasDiscriminator().HasValue("LiteralExpression");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.VariableNameExpression", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Expression");

                    b.Property<string>("VariableName")
                        .HasMaxLength(128);

                    b.ToTable("VariableNameExpression");

                    b.HasDiscriminator().HasValue("VariableNameExpression");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.ActionStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("ExpressionToEvaluateExpressionId");

                    b.HasIndex("ExpressionToEvaluateExpressionId");

                    b.ToTable("ActionStatement");

                    b.HasDiscriminator().HasValue("ActionStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.EventHandlerStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("BlockId");

                    b.Property<string>("Event")
                        .HasMaxLength(128);

                    b.HasIndex("BlockId");

                    b.ToTable("EventHandlerStatement");

                    b.HasDiscriminator().HasValue("EventHandlerStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.IfStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("BlockId")
                        .HasColumnName("IfStatement_BlockId");

                    b.Property<Guid?>("ConditionExpressionId");

                    b.HasIndex("BlockId");

                    b.HasIndex("ConditionExpressionId");

                    b.ToTable("IfStatement");

                    b.HasDiscriminator().HasValue("IfStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.VariableAssignmentStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("ValueExpressionId");

                    b.Property<Guid?>("VariableNameExpressionExpressionId");

                    b.HasIndex("ValueExpressionId");

                    b.HasIndex("VariableNameExpressionExpressionId");

                    b.ToTable("VariableAssignmentStatement");

                    b.HasDiscriminator().HasValue("VariableAssignmentStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.VariableDefinitionStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("VariableNameExpressionExpressionId")
                        .HasColumnName("VariableDefinitionStatement_VariableNameExpressionExpressionId");

                    b.Property<int>("VariableType");

                    b.HasIndex("VariableNameExpressionExpressionId");

                    b.ToTable("VariableDefinitionStatement");

                    b.HasDiscriminator().HasValue("VariableDefinitionStatement");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.WhileStatement", b =>
                {
                    b.HasBaseType("MyRE.Core.Models.Data.Statement");

                    b.Property<Guid?>("BlockId")
                        .HasColumnName("WhileStatement_BlockId");

                    b.Property<Guid?>("ConditionExpressionId")
                        .HasColumnName("WhileStatement_ConditionExpressionId");

                    b.HasIndex("BlockId");

                    b.HasIndex("ConditionExpressionId");

                    b.ToTable("WhileStatement");

                    b.HasDiscriminator().HasValue("WhileStatement");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyRE.Core.Models.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Account", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.AppInstance", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.BlockStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Block")
                        .WithMany("Statements")
                        .HasForeignKey("BlockId");

                    b.HasOne("MyRE.Core.Models.Data.Statement", "Statement")
                        .WithMany()
                        .HasForeignKey("StatementId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.FunctionParameter", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.InvocationExpression")
                        .WithMany("Parameters")
                        .HasForeignKey("InvocationExpressionExpressionId");

                    b.HasOne("MyRE.Core.Models.Data.Expression", "Value")
                        .WithMany()
                        .HasForeignKey("ValueExpressionId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Project", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.AppInstance", "ParentInstance")
                        .WithMany("Projects")
                        .HasForeignKey("ParentInstanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.Routine", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId");

                    b.HasOne("MyRE.Core.Models.Data.Project", "Project")
                        .WithMany("Routines")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.ActionStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Expression", "ExpressionToEvaluate")
                        .WithMany()
                        .HasForeignKey("ExpressionToEvaluateExpressionId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.EventHandlerStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.IfStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId");

                    b.HasOne("MyRE.Core.Models.Data.Expression", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionExpressionId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.VariableAssignmentStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Expression", "Value")
                        .WithMany()
                        .HasForeignKey("ValueExpressionId");

                    b.HasOne("MyRE.Core.Models.Data.VariableNameExpression", "VariableNameExpression")
                        .WithMany()
                        .HasForeignKey("VariableNameExpressionExpressionId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.VariableDefinitionStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.VariableNameExpression", "VariableNameExpression")
                        .WithMany()
                        .HasForeignKey("VariableNameExpressionExpressionId");
                });

            modelBuilder.Entity("MyRE.Core.Models.Data.WhileStatement", b =>
                {
                    b.HasOne("MyRE.Core.Models.Data.Block", "Block")
                        .WithMany()
                        .HasForeignKey("BlockId");

                    b.HasOne("MyRE.Core.Models.Data.Expression", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionExpressionId");
                });
#pragma warning restore 612, 618
        }
    }
}
