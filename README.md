# LibraryManager-WPF

A full-featured **City Library Management System** built with C#, WPF, and WCF. The system provides two dedicated interfaces — one for librarians and one for clients — connected through a centralized WCF service with an MS Access database.

---

## Architecture

```
┌─────────────────────┐     ┌─────────────────────┐
│   SAFRANIT (WPF)    │     │   LAKOACH (WPF)     │
│   Librarian App     │     │   Client App        │
└────────┬────────────┘     └────────┬────────────┘
         │                           │
         └──────────┬────────────────┘
                    │ WCF (basicHttpBinding)
         ┌──────────▼────────────────┐
         │    Aimen Service Host     │
         │   (Console自 WCF Host)    │
         └──────────┬────────────────┘
                    │
         ┌──────────▼────────────────┐
         │    MS Access Database     │
         │    (MyAccess.accdb)       │
         └───────────────────────────┘
```

## Features

### Librarian Dashboard (SAFRANIT)
- **Book Management** — Add, update, search books with cover images
- **Category Management** — Book genres & publishers
- **Member Registration** — Add/edit members with Israeli ID validation
- **Membership Management** — Subscribe & renew memberships with expiry tracking
- **Borrowing & Returns** — Issue books, track overdue items
- **Copy Management** — Manage multiple copies per book (BTB)

### Client Portal (LAKOACH)
- **Browse Books** — View all available books with cover images
- **Borrow Books** — Search by book code/serial, borrow within limit
- **Return Books** — Return by code or view all borrowed & return
- **Membership Check** — View active subscriptions

### Technical Highlights
- **Multi-tier architecture**: Model → ViewModel(DAL) → WCF Service → WPF UI
- **WCF communication**: Async service calls between client and server
- **Parameterized SQL**: Protection against SQL injection
- **Reflection-based ORM**: Generic SQL builder for all entities
- **Input validation**: Israeli ID check digit, phone, email, Hebrew text
- **Image handling**: Upload and display book cover images
- **RTL support**: Full Hebrew UI with right-to-left layout

## Prerequisites

- Visual Studio 2022 with **.NET Desktop Development** workload
- .NET Framework 4.7.2
- Microsoft Access Database Engine 2016 Redistributable ([download](https://www.microsoft.com/en-us/download/details.aspx?id=54920))

## Getting Started

1. **Clone the repo**
   ```bash
   git clone https://github.com/ShiraSiton/LibraryManager-WPF.git
   ```

2. **Start the WCF service**
   - Open `Aimen/Aimen.sln` in Visual Studio
   - Set **Host** as the startup project
   - Run (F5) — console shows: `Server is running. Keep this window open!`

3. **Launch the apps**
   - Open `LAKOACH/LAKOACH.sln` (client app) OR `SAFRANIT/SAFRANIT.sln` (librarian app)
   - Run while the WCF host is active

> ⚠ The WCF service **must** be running before launching the client apps.

## Project Structure

```
├── Aimen/                          # Server solution
│   ├── Aimen/                      # (reserved)
│   ├── Model/                      # Entity classes (BooksList, Clients, etc.)
│   ├── ViewModel/                  # DAL with generic SQL builder
│   ├── WcfServiceLibrary1/         # WCF service contract & implementation
│   ├── Host/                       # Console app hosting the WCF service
│   ├── Data/                       # MS Access database file
│   └── Test/                       # Test project
├── LAKOACH/                        # Client WPF app (borrowing)
├── SAFRANIT/                       # Librarian WPF app (management)
└── Images/                         # Book cover images
```

## Screenshots

### Librarian App (SAFRANIT)

| Home Page | Customer Registration |
|:---:|:---:|
| ![Home Page](screenshots/Home%20page.png) | ![Customer Registration](screenshots/Customer%20registration.png) |

| Book Editing | Types of Book | Types of Books |
|:---:|:---:|:---:|
| ![Book Editing](screenshots/Book%20editing.png) | ![Types of Book](screenshots/Types%20of%20book.png) | ![Types of Books](screenshots/Types%20of%20books.png) |

| Publishing Houses | Viewing Books in Library |
|:---:|:---:|
| ![Publishing Houses](screenshots/Publishing%20houses.png) | ![Viewing Books in Library](screenshots/Viewing%20books%20in%20the%20library.png) |

### Client App (LAKOACH)

| Borrowing Books | Return by ID | Return by Book Code |
|:---:|:---:|:---:|
| ![Borrowing Books](screenshots/Borrowing%20books.png) | ![Return by ID](screenshots/Return%20by%20ID.png) | ![Return by Book Code](screenshots/Return%20by%20book%20code.png) |

| Book Care |
|:---:|
| ![Book Care](screenshots/Book%20care.png) |
```
