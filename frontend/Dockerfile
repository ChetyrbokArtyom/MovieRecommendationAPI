# Этап сборки
FROM node:18.20.2 AS build

WORKDIR /app

COPY frontend/package.json frontend/package-lock.json ./

RUN npm ci

RUN npm rebuild esbuild --platform=linux

COPY frontend/ .

RUN npm run build --configuration=production

FROM nginx:alpine
COPY --from=build /app/dist/frontend /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]