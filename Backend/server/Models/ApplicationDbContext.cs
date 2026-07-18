using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ServicesGatway.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=IsraFlight_LocalDB;Trusted_Connection=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.HasKey(e => e.AirplaneId).HasName("PK__Airplane__5ED76B858470A223");

            entity.ToTable("Airplane");

            entity.Property(e => e.AirplaneId).HasColumnName("AirplaneID");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.Nickname).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8D5F0CD00");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.IsManager).HasColumnType("bit");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flight__8A9E148EAB90B873");

            entity.ToTable("Flight", tb => tb.HasTrigger("trg_SetAvailableSeats"));

            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.AirplaneId).HasColumnName("AirplaneID");
            entity.Property(e => e.ArrivalAirport).HasMaxLength(100);
            entity.Property(e => e.ArrivalCity).HasMaxLength(100);
            entity.Property(e => e.ArrivalCountry).HasMaxLength(100);
            entity.Property(e => e.ArrivalDateTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureAirport).HasMaxLength(100);
            entity.Property(e => e.DepartureCity).HasMaxLength(100);
            entity.Property(e => e.DepartureCountry).HasMaxLength(100);
            entity.Property(e => e.DepartureDateTime).HasColumnType("datetime");

            // הגדרת שדה המחיר
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC627E69FB46E");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
        });
        OnModelCreatingPartial(modelBuilder);

        // --- נתוני דמה למטוסים (10 שורות) ---
        modelBuilder.Entity<Airplane>().HasData(
            new Airplane { AirplaneId = 1, Manufacturer = "Boeing", Nickname = "Dreamliner", YearOfManufacture = 2019, ImageUrl = null, SeatCount = 250 },
            new Airplane { AirplaneId = 2, Manufacturer = "Airbus", Nickname = "A320neo", YearOfManufacture = 2021, ImageUrl = null, SeatCount = 180 },
            new Airplane { AirplaneId = 3, Manufacturer = "Boeing", Nickname = "737 MAX", YearOfManufacture = 2023, ImageUrl = null, SeatCount = 200 },
            new Airplane { AirplaneId = 4, Manufacturer = "Airbus", Nickname = "A330", YearOfManufacture = 2015, ImageUrl = null, SeatCount = 300 },
            new Airplane { AirplaneId = 5, Manufacturer = "Boeing", Nickname = "777", YearOfManufacture = 2018, ImageUrl = null, SeatCount = 350 },
            new Airplane { AirplaneId = 6, Manufacturer = "Embraer", Nickname = "E190", YearOfManufacture = 2020, ImageUrl = null, SeatCount = 100 },
            new Airplane { AirplaneId = 7, Manufacturer = "Airbus", Nickname = "A350", YearOfManufacture = 2022, ImageUrl = null, SeatCount = 320 },
            new Airplane { AirplaneId = 8, Manufacturer = "Boeing", Nickname = "747", YearOfManufacture = 2010, ImageUrl = null, SeatCount = 400 },
            new Airplane { AirplaneId = 9, Manufacturer = "ATR", Nickname = "72-600", YearOfManufacture = 2019, ImageUrl = null, SeatCount = 70 },
            new Airplane { AirplaneId = 10, Manufacturer = "Airbus", Nickname = "A220", YearOfManufacture = 2023, ImageUrl = null, SeatCount = 130 }
        );

        // --- נתוני דמה ללקוחות (10 שורות) ---
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, Password = "admin", FullName = "מוריה בוכריס", Email = "moriya@israflight.co.il", PhoneNumber = "050-0000000", IsManager = true },
            new Customer { CustomerId = 2, Password = "123", FullName = "Hagai Moskovich", Email = "hagai@example.com", PhoneNumber = "052-1234567", IsManager = false },
            new Customer { CustomerId = 3, Password = "123", FullName = "Israel Israeli", Email = "israel@example.com", PhoneNumber = "054-9876543", IsManager = false },
            new Customer { CustomerId = 4, Password = "123", FullName = "Sarah Cohen", Email = "sarah@example.com", PhoneNumber = "050-1112223", IsManager = false },
            new Customer { CustomerId = 5, Password = "123", FullName = "David Levi", Email = "david@example.com", PhoneNumber = "053-4445556", IsManager = false },
            new Customer { CustomerId = 6, Password = "123", FullName = "Yael Golan", Email = "yael@example.com", PhoneNumber = "052-7778889", IsManager = false },
            new Customer { CustomerId = 7, Password = "123", FullName = "Avi Cohen", Email = "avi@example.com", PhoneNumber = "054-0001112", IsManager = false },
            new Customer { CustomerId = 8, Password = "123", FullName = "Michal Ron", Email = "michal@example.com", PhoneNumber = "050-3334445", IsManager = false },
            new Customer { CustomerId = 9, Password = "123", FullName = "Dan Shapira", Email = "dan@example.com", PhoneNumber = "053-6667778", IsManager = false },
            new Customer { CustomerId = 10, Password = "123", FullName = "Ruth Katz", Email = "ruth@example.com", PhoneNumber = "052-9990001", IsManager = false }
        );

        // --- נתוני דמה לטיסות (10 שורות) ---
        modelBuilder.Entity<Flight>().HasData(
            new Flight { FlightId = 1, AirplaneId = 1, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "New York", ArrivalAirport = "JFK", ArrivalCountry = "USA", DepartureDateTime = new DateTime(2026, 6, 10, 10, 0, 0), ArrivalDateTime = new DateTime(2026, 6, 10, 15, 30, 0), IsSabbathLanding = false, AvailableSeats = 250, Price = 850.00m },
            new Flight { FlightId = 2, AirplaneId = 2, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "London", ArrivalAirport = "Heathrow", ArrivalCountry = "UK", DepartureDateTime = new DateTime(2026, 6, 12, 8, 0, 0), ArrivalDateTime = new DateTime(2026, 6, 12, 11, 45, 0), IsSabbathLanding = false, AvailableSeats = 180, Price = 465.56m },
            new Flight { FlightId = 3, AirplaneId = 3, DepartureCity = "Paris", DepartureAirport = "CDG", DepartureCountry = "France", ArrivalCity = "Tel Aviv", ArrivalAirport = "Ben Gurion", ArrivalCountry = "Israel", DepartureDateTime = new DateTime(2026, 6, 15, 20, 0, 0), ArrivalDateTime = new DateTime(2026, 6, 16, 1, 30, 0), IsSabbathLanding = false, AvailableSeats = 200, Price = 320.90m },
            new Flight { FlightId = 4, AirplaneId = 6, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "Rome", ArrivalAirport = "Fiumicino", ArrivalCountry = "Italy", DepartureDateTime = new DateTime(2026, 7, 1, 14, 0, 0), ArrivalDateTime = new DateTime(2026, 7, 1, 17, 0, 0), IsSabbathLanding = false, AvailableSeats = 100, Price = 250.00m },
            new Flight { FlightId = 5, AirplaneId = 2, DepartureCity = "Berlin", DepartureAirport = "Brandenburg", DepartureCountry = "Germany", ArrivalCity = "Tel Aviv", ArrivalAirport = "Ben Gurion", ArrivalCountry = "Israel", DepartureDateTime = new DateTime(2026, 7, 5, 9, 30, 0), ArrivalDateTime = new DateTime(2026, 7, 5, 14, 30, 0), IsSabbathLanding = false, AvailableSeats = 180, Price = 290.50m },
            new Flight { FlightId = 6, AirplaneId = 5, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "Bangkok", ArrivalAirport = "Suvarnabhumi", ArrivalCountry = "Thailand", DepartureDateTime = new DateTime(2026, 8, 10, 22, 0, 0), ArrivalDateTime = new DateTime(2026, 8, 11, 13, 0, 0), IsSabbathLanding = false, AvailableSeats = 350, Price = 950.00m },
            new Flight { FlightId = 7, AirplaneId = 4, DepartureCity = "Madrid", DepartureAirport = "Barajas", DepartureCountry = "Spain", ArrivalCity = "Tel Aviv", ArrivalAirport = "Ben Gurion", ArrivalCountry = "Israel", DepartureDateTime = new DateTime(2026, 8, 15, 18, 0, 0), ArrivalDateTime = new DateTime(2026, 8, 15, 23, 45, 0), IsSabbathLanding = false, AvailableSeats = 300, Price = 340.00m },
            new Flight { FlightId = 8, AirplaneId = 9, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "Athens", ArrivalAirport = "Eleftherios Venizelos", ArrivalCountry = "Greece", DepartureDateTime = new DateTime(2026, 9, 1, 7, 0, 0), ArrivalDateTime = new DateTime(2026, 9, 1, 9, 15, 0), IsSabbathLanding = false, AvailableSeats = 70, Price = 150.00m },
            new Flight { FlightId = 9, AirplaneId = 7, DepartureCity = "Dubai", DepartureAirport = "DXB", DepartureCountry = "UAE", ArrivalCity = "Tel Aviv", ArrivalAirport = "Ben Gurion", ArrivalCountry = "Israel", DepartureDateTime = new DateTime(2026, 9, 10, 16, 0, 0), ArrivalDateTime = new DateTime(2026, 9, 10, 18, 30, 0), IsSabbathLanding = false, AvailableSeats = 320, Price = 220.75m },
            new Flight { FlightId = 10, AirplaneId = 10, DepartureCity = "Tel Aviv", DepartureAirport = "Ben Gurion", DepartureCountry = "Israel", ArrivalCity = "Amsterdam", ArrivalAirport = "Schiphol", ArrivalCountry = "Netherlands", DepartureDateTime = new DateTime(2026, 10, 5, 6, 30, 0), ArrivalDateTime = new DateTime(2026, 10, 5, 11, 30, 0), IsSabbathLanding = false, AvailableSeats = 130, Price = 410.00m }
        );

        // --- נתוני דמה לכרטיסים (10 שורות) ---
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket { TicketId = 1, FlightId = 1, CustomerId = 2, PurchaseDate = new DateTime(2026, 5, 20, 9, 15, 0) },
            new Ticket { TicketId = 2, FlightId = 2, CustomerId = 3, PurchaseDate = new DateTime(2026, 5, 22, 14, 30, 0) },
            new Ticket { TicketId = 3, FlightId = 3, CustomerId = 4, PurchaseDate = new DateTime(2026, 5, 23, 10, 0, 0) },
            new Ticket { TicketId = 4, FlightId = 4, CustomerId = 5, PurchaseDate = new DateTime(2026, 6, 1, 8, 45, 0) },
            new Ticket { TicketId = 5, FlightId = 5, CustomerId = 6, PurchaseDate = new DateTime(2026, 6, 10, 16, 20, 0) },
            new Ticket { TicketId = 6, FlightId = 6, CustomerId = 7, PurchaseDate = new DateTime(2026, 7, 15, 11, 10, 0) },
            new Ticket { TicketId = 7, FlightId = 7, CustomerId = 8, PurchaseDate = new DateTime(2026, 7, 20, 19, 0, 0) },
            new Ticket { TicketId = 8, FlightId = 8, CustomerId = 9, PurchaseDate = new DateTime(2026, 8, 5, 12, 30, 0) },
            new Ticket { TicketId = 9, FlightId = 9, CustomerId = 10, PurchaseDate = new DateTime(2026, 8, 25, 9, 0, 0) },
            new Ticket { TicketId = 10, FlightId = 10, CustomerId = 2, PurchaseDate = new DateTime(2026, 9, 2, 14, 15, 0) }
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
