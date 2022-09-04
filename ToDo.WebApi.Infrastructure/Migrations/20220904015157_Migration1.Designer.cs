﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDo.WebApi.Infrastructure.Contexts;

#nullable disable

namespace ToDo.WebApi.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220904015157_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToDo.WebApi.Domain.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean");

                    b.Property<int>("TodoListId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("ToDo.WebApi.Domain.Entities.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("ToDo.WebApi.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("ToDo.WebApi.Domain.Entities.TodoList", "List")
                        .WithMany("Items")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("ToDo.WebApi.Domain.Entities.TodoList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
