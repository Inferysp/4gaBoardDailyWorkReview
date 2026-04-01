# React/Vite client - use Debian-based Node 20 to satisfy Vite and native deps
FROM node:20-bullseye AS build
WORKDIR /app

# Copy package.json only (do NOT copy package-lock.json) so npm resolves native optional deps for Linux
COPY package.json ./

# Install dependencies inside the container (will generate a lock for the container platform)
RUN npm install --no-audit --no-fund --silent

COPY . .

# Build (Vite output -> dist)
RUN npm run build

FROM nginx:stable-alpine AS runtime
COPY nginx.conf /etc/nginx/conf.d/default.conf
# Vite outputs to /app/dist
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]