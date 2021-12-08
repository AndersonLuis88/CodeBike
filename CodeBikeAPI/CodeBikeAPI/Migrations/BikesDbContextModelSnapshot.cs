using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CodeBikeAPI.DataAccess.EF;

namespace CodeBikeAPI.Migrations
{
    [DbContext(typeof(BikesDbContext))]
    partial class BikesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("RentBikes.DataAccess.Models.Bike", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .UseIdentityColumn();

                b.Property<bool>("IsAvailable")
                    .HasColumnType("bit");

                b.Property<bool>("IsRent")
                    .HasColumnType("bit");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                b.Property<Guid>("PublicId")
                    .HasColumnType("uniqueidentifier");

                b.Property<decimal>("RentCost")
                    .HasColumnType("decimal(18,0)");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                b.HasKey("Id");

                b.ToTable("Bikes");
            });
#pragma warning restore 612, 618
        }
    }
}

