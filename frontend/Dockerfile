FROM node:12.16.0-alpine

# Crear carpeta app
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Instalar dependencias
RUN apk update && apk upgrade && apk add git

# Copiar directorio & npm i
ONBUILD COPY . /usr/src/app/
ONBUILD RUN npm install

# Build app
ONBUILD RUN npm run build

ENV HOST 0.0.0.0
EXPOSE 3000

# Start
CMD [ "npm", "start" ]
