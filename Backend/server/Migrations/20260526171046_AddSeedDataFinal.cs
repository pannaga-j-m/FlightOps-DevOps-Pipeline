using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airplane",
                columns: new[] { "AirplaneID", "ImageURL", "Manufacturer", "Nickname", "SeatCount", "YearOfManufacture" },
                values: new object[,]
                {
                    { 1, null, "Boeing", "Dreamliner", 250, 2019 },
                    { 2, null, "Airbus", "A320neo", 180, 2021 },
                    { 3, null, "Boeing", "737 MAX", 200, 2023 },
                    { 4, null, "Airbus", "A330", 300, 2015 },
                    { 5, null, "Boeing", "777", 350, 2018 },
                    { 6, null, "Embraer", "E190", 100, 2020 },
                    { 7, null, "Airbus", "A350", 320, 2022 },
                    { 8, null, "Boeing", "747", 400, 2010 },
                    { 9, null, "ATR", "72-600", 70, 2019 },
                    { 10, null, "Airbus", "A220", 130, 2023 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "Email", "FullName", "IsManager", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "moriya@israflight.co.il", "מוריה בוכריס", true, "admin", "050-0000000" },
                    { 2, "hagai@example.com", "Hagai Moskovich", false, "123", "052-1234567" },
                    { 3, "israel@example.com", "Israel Israeli", false, "123", "054-9876543" },
                    { 4, "sarah@example.com", "Sarah Cohen", false, "123", "050-1112223" },
                    { 5, "david@example.com", "David Levi", false, "123", "053-4445556" },
                    { 6, "yael@example.com", "Yael Golan", false, "123", "052-7778889" },
                    { 7, "avi@example.com", "Avi Cohen", false, "123", "054-0001112" },
                    { 8, "michal@example.com", "Michal Ron", false, "123", "050-3334445" },
                    { 9, "dan@example.com", "Dan Shapira", false, "123", "053-6667778" },
                    { 10, "ruth@example.com", "Ruth Katz", false, "123", "052-9990001" }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "FlightID", "AirplaneID", "ArrivalAirport", "ArrivalCity", "ArrivalCountry", "ArrivalDateTime", "AvailableSeats", "DepartureAirport", "DepartureCity", "DepartureCountry", "DepartureDateTime", "IsSabbathLanding", "Price" },
                values: new object[,]
                {
                    { 1, 1, "JFK", "New York", "USA", new DateTime(2026, 6, 10, 15, 30, 0, 0, DateTimeKind.Unspecified), 250, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 6, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 850.00m },
                    { 2, 2, "Heathrow", "London", "UK", new DateTime(2026, 6, 12, 11, 45, 0, 0, DateTimeKind.Unspecified), 180, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 6, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), false, 465.56m },
                    { 3, 3, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 6, 16, 1, 30, 0, 0, DateTimeKind.Unspecified), 200, "CDG", "Paris", "France", new DateTime(2026, 6, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), false, 320.90m },
                    { 4, 6, "Fiumicino", "Rome", "Italy", new DateTime(2026, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 100, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 7, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 250.00m },
                    { 5, 2, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 7, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), 180, "Brandenburg", "Berlin", "Germany", new DateTime(2026, 7, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), false, 290.50m },
                    { 6, 5, "Suvarnabhumi", "Bangkok", "Thailand", new DateTime(2026, 8, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), 350, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 8, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), false, 950.00m },
                    { 7, 4, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 8, 15, 23, 45, 0, 0, DateTimeKind.Unspecified), 300, "Barajas", "Madrid", "Spain", new DateTime(2026, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), false, 340.00m },
                    { 8, 9, "Eleftherios Venizelos", "Athens", "Greece", new DateTime(2026, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 70, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 9, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 150.00m },
                    { 9, 7, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 9, 10, 18, 30, 0, 0, DateTimeKind.Unspecified), 320, "DXB", "Dubai", "UAE", new DateTime(2026, 9, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 220.75m },
                    { 10, 10, "Schiphol", "Amsterdam", "Netherlands", new DateTime(2026, 10, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), 130, "Ben Gurion", "Tel Aviv", "Israel", new DateTime(2026, 10, 5, 6, 30, 0, 0, DateTimeKind.Unspecified), false, 410.00m }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketID", "CustomerID", "FlightID", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2026, 5, 20, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 2, new DateTime(2026, 5, 22, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, 3, new DateTime(2026, 5, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, 4, new DateTime(2026, 6, 1, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 6, 5, new DateTime(2026, 6, 10, 16, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 7, 6, new DateTime(2026, 7, 15, 11, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 8, 7, new DateTime(2026, 7, 20, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 9, 8, new DateTime(2026, 8, 5, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 10, 9, new DateTime(2026, 8, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, 10, new DateTime(2026, 9, 2, 14, 15, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Airplane",
                keyColumn: "AirplaneID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flight",
                keyColumn: "FlightID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ticket",
                keyColumn: "TicketID",
                keyValue: 10);
        }
    }
}
