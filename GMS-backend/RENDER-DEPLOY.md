# Deploy GMS Backend to Render (Supabase → Render → Vercel)

This guide walks you through deploying the GMS backend to Render with PostgreSQL on Supabase.

---

## Prerequisites

- **GitHub account** with the gms Deploy repo pushed
- **Render account** – https://render.com (free tier available)
- **Supabase** – PostgreSQL database (Project Settings → Database for connection details)
- **Environment variables** – set in Render dashboard (do not commit `.env`)

---

## Step 1: Generate PostgreSQL migrations (one-time, local)

The app uses **PostgreSQL** and EF Core migrations. Generate the initial migration once with a local or Supabase Postgres DB:

1. Copy `.env.example` to `.env` in `GMS-backend` (or `GMS-backend/GMS` when running from there).
2. Set `DB_MODE=local` and local Postgres vars, or `DB_MODE=supabase` and Supabase vars (from Supabase Dashboard → Project Settings → Database).
3. From repo root:
   ```bash
   cd GMS-backend/GMS
   dotnet ef migrations add InitPostgres
   ```
4. Commit the new files under `GMS/Migrations/` (e.g. `*_InitPostgres.cs` and updated `ApplicationDbContextModelSnapshot.cs`).

If you use the DesignTimeDbContextFactory default (no .env), it uses `Host=localhost;Port=5432;Database=GMS_db;Username=postgres;Password=postgres`. Ensure Postgres is running locally or use Supabase in `.env`.

---

## Step 2: Push code to GitHub

1. Commit and push all changes.
2. Ensure `GMS-backend` contains `Dockerfile`, `GMS/` (with `Program.cs`, `GMS.csproj`, `Migrations/`).
3. Do **not** commit `.env` – add `.env` to `.gitignore` if not already.

---

## Step 3: Create a Web Service on Render

1. Go to https://dashboard.render.com and log in.
2. Click **New +** → **Web Service**.
3. Connect GitHub and select the **gms Deploy** repository.
4. Click **Connect**.

---

## Step 4: Configure the Web Service

| Field | Value |
|-------|-------|
| **Name** | `gms-api` (or any name) |
| **Region** | Choose closest (e.g. Frankfurt) |
| **Root Directory** | `GMS-backend` |
| **Runtime** | **Docker** |
| **Build/Start** | Leave default (Render uses the Dockerfile) |

If you prefer **native .NET** instead of Docker:

| Field | Value |
|-------|-------|
| **Runtime** | `.NET` |
| **Build Command** | `dotnet publish GMS/GMS.csproj -c Release -o out` |
| **Start Command** | `dotnet out/GMS.dll` |

---

## Step 5: Add Environment Variables

In **Environment**, add these. Get DB values from **Supabase → Project Settings → Database** (use **Session mode** pooler for connection string).

| Key | Value | Secret? | Where to get |
|-----|-------|---------|----------------|
| `ENVIRONMENT` | `production` | No | — |
| `FRONTEND_URL` | `https://________.vercel.app` | No | **Vercel** – frontend URL after deploy (no trailing slash) |
| `DB_MODE` | `supabase` | No | — |
| `DB_SUPABASE_HOST` | | No | Supabase → Database → Session mode → Host |
| `DB_SUPABASE_PORT` | `5432` | No | — |
| `DB_SUPABASE_NAME` | `postgres` | No | — |
| `DB_SUPABASE_USER` | | No | Supabase → Session pooler user (e.g. `postgres.PROJECT_REF`) |
| `DB_SUPABASE_PASSWORD` | | **Yes** | Supabase → Database password |
| `DOTNET_EnableDiagnostics` | `0` | No | Optional, faster cold start |

Use **Add Secret** for `DB_SUPABASE_PASSWORD`.

---

## Step 6: Instance type and deploy

- Choose **Free** for free tier (service may sleep after inactivity; cold start ~30–60 s).
- Click **Create Web Service**. Render builds and deploys.

In **Logs** you should see:

- `Database mode: Supabase`
- `Environment: Production (Render)`
- `Now listening on: http://0.0.0.0:XXXX`
- `Pending migrations detected. Applying migrations...` (first deploy)

---

## Step 7: Update FRONTEND_URL after Vercel deploy

1. Deploy the frontend to Vercel (see `GMS-frontend/VERCEL-DEPLOY.md`).
2. In Render → your service → **Environment**.
3. Set `FRONTEND_URL` to your Vercel URL (e.g. `https://gms-xxx.vercel.app`, no trailing slash).
4. Save – Render redeploys. CORS will allow only that frontend.

---

## Troubleshooting

| Problem | Check |
|---------|--------|
| Build fails | Root Directory = `GMS-backend`; Dockerfile path; .NET 7 SDK in Dockerfile |
| "Database connection not configured" | All `DB_SUPABASE_*` (or `DB_*` for local) set on Render |
| 503 / app not starting | Logs for exceptions; PORT is set by Render automatically |
| CORS errors | Set `FRONTEND_URL` to exact Vercel URL (no trailing slash) |
| Cold start slow | Normal on free tier; optional: UptimeRobot to ping the service |
