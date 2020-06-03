﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramingJokes.Data;

namespace ProgramingJokes.Data.Migrations
{
    [DbContext(typeof(JokeContext))]
    [Migration("20200602044556_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgramingJokes.Data.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JokeId");

                    b.Property<string>("Punchline");

                    b.Property<string>("Setup");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("ProgramingJokes.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProgramingJokes.Data.UserLikedJokes", b =>
                {
                    b.Property<int>("JokeId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("JokeNumber");

                    b.Property<bool>("Liked");

                    b.HasKey("JokeId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLikedJokes");
                });

            modelBuilder.Entity("ProgramingJokes.Data.UserLikedJokes", b =>
                {
                    b.HasOne("ProgramingJokes.Data.Joke", "Joke")
                        .WithMany("UserLikedJokes")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProgramingJokes.Data.User", "User")
                        .WithMany("UserLikedJokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
