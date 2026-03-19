# GMS — Gym Management System

Full-stack application for managing gyms: members (`Korisnik`), memberships (`Članarina`), trainers (`Trener`), nutritionists (`Nutricionist`), supplements (`Suplement`), seminars, reviews (`Recenzija`), FAQ, cities, suppliers, and reporting. The solution pairs an **ASP.NET Core** REST API with an **Angular** web client.

## Repository layout

| Folder | Description |
|--------|-------------|
| `GMS-backend/` | .NET 7 Web API (`GMS.sln`, project `GMS/GMS.csproj`) |
| `GMS-frontend/` | Angular 16 app (`gms-client` / `GMS-client`) |

## Tech stack

**Backend**

- .NET 7, ASP.NET Core Web API  
- Entity Framework Core 6 + SQL Server  
- Swagger (Swashbuckle), JWT-related packages, optional Azure AD / Microsoft Identity Web  
- Twilio (SMS), email sender service, RDLC reporting (`AspNetCore.Reporting`), SkiaSharp  

**Frontend**

- Angular 16, Angular Material & CDK  
- HTTP client with auth interceptor; hash-based routing  

## Main features (domain)

- User accounts with role separation: **member** vs **administrator** (route guards)  
- Memberships, gyms (`Teretana`), cities (`Grad`), genders (`Spol`)  
- Staff: trainers and nutritionists; seminar attendance (`Trener_Seminar`, `Nutricionist_Seminar`)  
- Member bookings: trainer and nutritionist appointments  
- Supplements: catalog, categories, suppliers (`Dobavljac`), member orders  
- Reviews, FAQ, optional **two-factor** flow (`TwofPage` / related endpoints)  
- **Reports** via dedicated reporting controller and embedded RDLC  

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)  
- [Node.js](https://nodejs.org/) (LTS recommended) and npm  
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB or full instance) accessible from the API  

## Configuration (backend)

1. Open `GMS-backend/GMS/appsettings.json` (or use **User Secrets** / environment variables for production).  
2. Set the `ConnectionStrings:db1` value to your SQL Server database (the API registers `ApplicationDbContext` with this connection string in `Program.cs`).  
3. Configure optional integrations as needed: SMTP (`MojEmailServer` section), Twilio, Azure AD — match whatever your deployment expects.

**Security:** Do not commit real passwords, API keys, or connection strings to source control. Prefer User Secrets locally and a secret store in production.

## Database

Migrations live under `GMS-backend/GMS/Migrations/`. After the connection string is correct, apply the schema from the backend project directory:

```bash
cd GMS-backend/GMS
dotnet ef database update
```

*(Requires the EF Core tools: `dotnet tool install --global dotnet-ef` if you do not have them.)*

## Run the API

From `GMS-backend/GMS`:

```bash
dotnet run
```

Typical URLs (see `Properties/launchSettings.json`):

- **Kestrel profile `GMS`:** `https://localhost:7174` and `http://localhost:5174`  
- **IIS Express:** e.g. `https://localhost:44357` (SSL port may vary)

Swagger UI is enabled in the pipeline (including non-Development per current `Program.cs`), so you can explore and try endpoints at `/swagger`.

## Run the Angular client

From `GMS-frontend`:

```bash
npm install
npm start
```

`npm start` runs `ng serve` (default dev server URL is usually `http://localhost:4200`).

### Point the UI at the API

The API base URL is set in `GMS-frontend/src/app/config.ts` (`Config.adresa`). Align it with how you run the backend:

- **IIS Express:** e.g. `https://localhost:44357/` (as in the current default)  
- **`dotnet run` (GMS profile):** e.g. `https://localhost:7174/`  

CORS is configured in the API to allow arbitrary origins for development; you still need a valid HTTPS dev certificate if you use `https://` locally.

## Build for production

**Backend**

```bash
cd GMS-backend/GMS
dotnet publish -c Release
```

**Frontend**

```bash
cd GMS-frontend
npm run build
```

Output: `GMS-frontend/dist/gms-client/`. The API serves static files from `wwwroot` if you copy the built client there or host the SPA separately.

## Tests

- **Frontend:** `npm test` (Karma/Jasmine).  
- **Backend:** no separate test project is included in this repository.

## API reference

Use **Swagger** at `/swagger` while the API is running. Controllers and endpoints follow the existing naming (e.g. `Korisnik`, `Clanarina`, `Authentification`, reporting).

## Contributing

1. Create a branch for your change.  
2. Keep backend and frontend contracts in sync when you change DTOs or routes.  
3. Run `dotnet build` and `ng build` (or tests) before opening a pull request.  
4. Never commit secrets; update configuration examples with placeholders only.

---

*Internal / academic naming (Bosnian/Croatian/Serbian labels in code and UI) is preserved in the codebase.*
