FROM node:10.16.0-alpine

RUN mkdir /usr/src/app
WORKDIR /usr/src/app

COPY package.json /usr/src/app/package.json
COPY package-lock.json /usr/src/app/package-lock.json

RUN npm install --save \
    && npm install -g @angular/cli

COPY . /usr/src/app

CMD ng serve --host 0.0.0.0

EXPOSE 4200:4200