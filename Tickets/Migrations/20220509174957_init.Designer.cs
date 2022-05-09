﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tickets.Infrastructure;

namespace Tickets.Migrations
{
    [DbContext(typeof(TicketContext))]
    [Migration("20220509174957_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Tickets.Infrastructure.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DocNumber")
                        .HasColumnType("text");

                    b.Property<string>("DocType")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PassengerType")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("text");

                    b.Property<int>("TicketType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.Refund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("OperationPlace")
                        .HasColumnType("text");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OperationType")
                        .HasColumnType("text");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Refunds");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.RouteSegment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AirlineCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("ArriveDatetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ArrivePlace")
                        .HasColumnType("text");

                    b.Property<DateTime>("DepartDatetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartPlace")
                        .HasColumnType("text");

                    b.Property<int>("FlightNum")
                        .HasColumnType("integer");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("OperationPlace")
                        .HasColumnType("text");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OperationType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.Passenger", b =>
                {
                    b.HasOne("Tickets.Infrastructure.Models.Ticket", "Ticket")
                        .WithOne("Passenger")
                        .HasForeignKey("Tickets.Infrastructure.Models.Passenger", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.RouteSegment", b =>
                {
                    b.HasOne("Tickets.Infrastructure.Models.Ticket", "Ticket")
                        .WithMany("Routes")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Tickets.Infrastructure.Models.Ticket", b =>
                {
                    b.Navigation("Passenger");

                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}