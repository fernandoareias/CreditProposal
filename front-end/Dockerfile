# Use uma imagem de Node.js como base
FROM node:18 as build

# Defina o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copie os arquivos do projeto para o contêiner
COPY ./front-end/ .

# Instale as dependências usando o npm (ou yarn, se preferir)
RUN npm install --legacy-peer-deps

# Build the React app for production
RUN npm run build

# Use Nginx as the production server
FROM nginx:alpine

# Copy the built React app to Nginx's web server directory
COPY --from=build /app/build /usr/share/nginx/html

# Expose port 80 for the Nginx server
EXPOSE 80

# Start Nginx when the container runs
CMD ["nginx", "-g", "daemon off;"]`