FROM node:lts-alpine

# Crear directorio de trabajo
RUN mkdir -p /opt/app

WORKDIR /opt/app

RUN npm install -g typescript ts-node

# Copia la Aplicación
COPY . .

RUN npm install --quiet

EXPOSE 3000

# Start
CMD [ "npm", "run", "dev" ]
