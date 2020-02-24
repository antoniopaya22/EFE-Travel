FROM node:12.16.0-alpine

# Crear directorio de trabajo
RUN mkdir -p /opt/app

WORKDIR /opt/app

RUN npm install

ENV HOST 0.0.0.0
EXPOSE 3000

# Start
CMD [ "npm", "run", "dev" ]
