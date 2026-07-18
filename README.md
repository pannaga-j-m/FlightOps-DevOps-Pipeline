# Flight Management System

A flight management and booking system built using a Client-Server architecture. The project consists of a C# Backend that manages the database, and a Python-based desktop Frontend application that serves as the user interface.

## User Interface

### Welcome Screen
<img width="1920" height="1080" alt="‏‏צילום מסך (1823)" src="https://github.com/user-attachments/assets/675d6ea0-9f7b-41dc-b450-6aec010dd2d0" />

### Main Dashboard & Flight Search
<img width="1920" height="1080" alt="‏‏צילום מסך (1821)" src="https://github.com/user-attachments/assets/1bc10d40-9aac-419d-aa7c-6b67ccec47f5" />

### Admin Panel - Add Airplane
<img width="1920" height="1080" alt="‏‏צילום מסך (1822)" src="https://github.com/user-attachments/assets/9fa06fef-82e9-4f77-b0d0-f1260f938cf5" />

---

## Project Structure

The codebase is divided into two main parts to separate the user interface from the data logic:

* **Backend (C#):** A Web API that receives requests from the client, handles user authentication, and communicates with the database using Entity Framework Core.
* **Frontend (Python):** A desktop GUI application built with the CustomTkinter library. The code is organized using the MVC (Model-View-Controller) pattern to separate the visual design from the API communication logic.

## Core Features

* Authentication system with different permissions for Administrators and regular Customers.
* Real-time flight searching and filtering, including a daily landing schedule.
* Flight ticket booking system that saves reservations directly to the database.
* Automated database creation and seeding with 10 rows of sample data per table for testing.

## Technologies Used

* **Backend:** C#, ASP.NET Core Web API, Entity Framework Core
* **Frontend:** Python, CustomTkinter, Requests
* **Database:** SQL Server (LocalDB)

---

## Getting Started (Step-by-Step Installation)

To run the application properly, you must set up and start the Backend server and database first, and only then run the Python Frontend application.

### Step 1: Clone the Repository
Open your terminal or command prompt and run:
git clone https://github.com/moriya-buchris/Flight-Management-System.git

### Step 2: Backend and Database Setup

1. Open Visual Studio.
2. Open the solution file located at: Backend/server.sln
3. Create Database and Seed Data:
   * In the top menu, go to: Tools -> NuGet Package Manager -> Package Manager Console.
   * In the console window that opens at the bottom, type the following command and press Enter:
     Update-Database
   * This command will automatically create the database on your local machine using SQL Server LocalDB and insert 10 rows of ready-to-use sample data into each table.
4. Run the Server: Press the Play button (or F5) in Visual Studio. A browser window will open, and the server will start running. Keep this server running in the background.

### Step 3: Frontend Setup and Execution

1. Open the Frontend folder in your preferred Python IDE (such as VS Code or PyCharm).
2. Install Required Libraries: Open the terminal in your Python IDE and install the required external packages by running:
   pip install -r requirements.txt
3. Run the Application: Execute the main application file to open the graphical interface:
   python Main.py

---

## Testing the System
To log in as an Administrator and view all the seeded system data, you can use the following pre-configured credentials:
* Username: moriya@israflight.co.il
* Password: admin
