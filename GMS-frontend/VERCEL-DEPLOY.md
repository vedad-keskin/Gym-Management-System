# Deploy GMS Angular frontend to Vercel

## Quick reference

| Environment | API URL |
|-------------|---------|
| **Local** (`ng serve`) | `https://localhost:7174/` (from `environment.ts`) |
| **Production** (`ng build`) | Set in `src/environments/environment.prod.ts` → your Render backend URL |

Before deploying, set the production API URL in **`src/environments/environment.prod.ts`** to your Render backend URL (e.g. `https://gms-api.onrender.com/`). The production build replaces the environment file via `fileReplacements` in `angular.json`.

---

## Vercel deployment steps

### Step 1: Set production API URL

Edit `GMS-frontend/src/environments/environment.prod.ts` and set `apiUrl` to your Render backend URL (e.g. `https://gms-api.onrender.com/`). Commit the change.

### Step 2: Push code to GitHub

Commit and push the frontend (including environments and config).

### Step 3: Create Vercel project

1. Go to https://vercel.com and sign up (GitHub recommended).
2. Click **Add New Project**.
3. Import your **gms Deploy** repository.
4. Click **Import**.

### Step 4: Configure the project

| Field | Value |
|-------|-------|
| **Framework Preset** | Angular |
| **Root Directory** | `GMS-frontend` (or the folder that contains your Angular app in the repo) |
| **Build Command** | `npm run build` |
| **Output Directory** | `dist/gms-client` |
| **Install Command** | `npm install --legacy-peer-deps` (or `npm install` if you don’t need it) |

**Important:** Keep **Root Directory** and **Output Directory** correct. The repo must contain a `vercel.json` in the frontend folder so all routes are served by `index.html` (SPA). If you see 404 after deploy, check that Output Directory is exactly `dist/gms-client` and that `vercel.json` is committed.

### Step 5: Deploy

Click **Deploy**. Vercel builds and deploys the app.

### Step 6: Update Render CORS

After deploy, Vercel shows your URL (e.g. `https://gms-xxx.vercel.app`).

1. In Render Dashboard, open your backend service.
2. Go to **Environment**.
3. Set **`FRONTEND_URL`** to your Vercel URL (e.g. `https://gms-xxx.vercel.app`, no trailing slash).
4. Save (Render redeploys). CORS will then allow only your Vercel frontend.
