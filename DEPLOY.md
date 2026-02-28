# GMS deployment: Supabase → Render → Vercel

Deploy the GMS app in three steps:

1. **Supabase** – PostgreSQL database (hosted).
2. **Render** – Backend (.NET 7, Docker or native .NET).
3. **Vercel** – Frontend (Angular).

---

## Order of operations

1. **Create Supabase project**  
   https://supabase.com → New project. Note Database password and, under **Project Settings → Database**, the **Session mode** connection details (host, user, port).

2. **Deploy backend to Render**  
   Follow **[GMS-backend/RENDER-DEPLOY.md](GMS-backend/RENDER-DEPLOY.md)**.  
   - Use **Root Directory**: `GMS-backend`.  
   - Set env vars: `DB_MODE=supabase`, `DB_SUPABASE_*`, `ENVIRONMENT=production`.  
   - Leave `FRONTEND_URL` empty for now (set after Vercel deploy).

3. **Deploy frontend to Vercel**  
   Follow **[GMS-frontend/VERCEL-DEPLOY.md](GMS-frontend/VERCEL-DEPLOY.md)**.  
   - Set `apiUrl` in `src/environments/environment.prod.ts` to your Render URL (e.g. `https://gms-api.onrender.com/`).  
   - After deploy, copy the Vercel URL.

4. **Set CORS on Render**  
   In Render → your backend service → **Environment**, set `FRONTEND_URL` to your Vercel URL (e.g. `https://gms-xxx.vercel.app`, no trailing slash). Save so the service redeploys.

---

## Local development

- **Backend**: Copy `GMS-backend/.env.example` to `GMS-backend/.env`, set `DB_MODE=local` (or `supabase`) and DB vars. Run from `GMS-backend/GMS`: `dotnet run`.
- **Frontend**: From `GMS-frontend`: `npm install` and `ng serve`. API URL is in `src/environments/environment.ts` (default `https://localhost:7174/`).
