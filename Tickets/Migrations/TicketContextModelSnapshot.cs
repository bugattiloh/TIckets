﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tickets.Infrastructure;

namespace Tickets.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Tickets.Infrastructure.Models.Segment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AirlineCode")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ArriveDatetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ArrivePlace")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DepartDatetime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartPlace")
                        .HasColumnType("text");

                    b.Property<string>("DocNumber")
                        .HasColumnType("text");

                    b.Property<string>("DocType")
                        .HasColumnType("text");

                    b.Property<int>("FlightNum")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OperationPlace")
                        .HasColumnType("text");

                    b.Property<DateTime>("OperationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("OperationType")
                        .HasColumnType("text");

                    b.Property<string>("PassengerType")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("text");

                    b.Property<int>("TicketType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TicketNumber", "SerialNumber")
                        .IsUnique();

                    b.ToTable("Segments");
                });
#pragma warning restore 612, 618
        }
    }
}
