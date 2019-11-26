﻿// <auto-generated />
using System;
using FootballManager.Dal.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootballManager.Dal.Migrations
{
    [DbContext(typeof(ManagerContext))]
    partial class ManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FootBallManager.Entities.ComplexTypes.League", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Seasonid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Seasonid");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("FootBallManager.Entities.ComplexTypes.Matches", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FirstTeamid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<int?>("Leagueid")
                        .HasColumnType("int");

                    b.Property<int>("ScoreFirstTeam")
                        .HasColumnType("int");

                    b.Property<int>("ScoreSecondTeam")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTeamid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FirstTeamid");

                    b.HasIndex("Leagueid");

                    b.HasIndex("SecondTeamid");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootBallManager.Entities.ComplexTypes.Season", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Adress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PostalCodeid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PostalCodeid");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Coach", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CoachSkillid")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nationid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.Property<double>("WeeklyPaid")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("CoachSkillid");

                    b.HasIndex("Nationid");

                    b.ToTable("Coachs");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.CoachSkill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("CoachSkills");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Description", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PlayerDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Playerid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Playerid");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Nation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adressid")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MarketPriceValue")
                        .HasColumnType("float");

                    b.Property<int>("Nationid")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerSkillid")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerSkillid1")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Teamid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.Property<double>("WeeklyPaid")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("Adressid");

                    b.HasIndex("Nationid");

                    b.HasIndex("PlayerSkillid1");

                    b.HasIndex("Teamid");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.PlayerSkill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attacking")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<int>("Defending")
                        .HasColumnType("int");

                    b.Property<int>("GoolKeeping")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Playerid")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Technical")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PlayerSkills");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Postalcode", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Postalcodes");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Stadium", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<int>("Founded")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Coachid")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<int>("Founded")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Leagueid")
                        .HasColumnType("int");

                    b.Property<int>("Stadiumid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Coachid");

                    b.HasIndex("Leagueid");

                    b.HasIndex("Stadiumid");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Trophy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("teamid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("teamid");

                    b.ToTable("Trophies");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adressid")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdateUserid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Adressid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FootBallManager.Entities.ComplexTypes.League", b =>
                {
                    b.HasOne("FootBallManager.Entities.ComplexTypes.Season", "Season")
                        .WithMany("Leagues")
                        .HasForeignKey("Seasonid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.ComplexTypes.Matches", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamid");

                    b.HasOne("FootBallManager.Entities.ComplexTypes.League", null)
                        .WithMany("Matches")
                        .HasForeignKey("Leagueid");

                    b.HasOne("FootBallManager.Entities.Concrete.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamid");
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Adress", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Postalcode", "PostalCode")
                        .WithMany()
                        .HasForeignKey("PostalCodeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Coach", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.CoachSkill", "CoachSkill")
                        .WithMany()
                        .HasForeignKey("CoachSkillid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootBallManager.Entities.Concrete.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("Nationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Description", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Player", "Player")
                        .WithMany("Descriptions")
                        .HasForeignKey("Playerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Player", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("Adressid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootBallManager.Entities.Concrete.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("Nationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootBallManager.Entities.Concrete.PlayerSkill", "PlayerSkill")
                        .WithMany()
                        .HasForeignKey("PlayerSkillid1");

                    b.HasOne("FootBallManager.Entities.Concrete.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("Teamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Team", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("Coachid");

                    b.HasOne("FootBallManager.Entities.ComplexTypes.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("Leagueid");

                    b.HasOne("FootBallManager.Entities.Concrete.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("Stadiumid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.Trophy", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Team", "team")
                        .WithMany("Trophies")
                        .HasForeignKey("teamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootBallManager.Entities.Concrete.User", b =>
                {
                    b.HasOne("FootBallManager.Entities.Concrete.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("Adressid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
