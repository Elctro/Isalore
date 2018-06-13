FROM ubuntu:16.04

#update first
RUN apt-get update
RUN apt-get -qq update
RUN apt-get --yes install wget curl apt-transport-https

#install dotnet
RUN wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update
RUN apt-get --yes install dotnet-sdk-2.1

#install node and npm
RUN apt-get install --yes nodejs npm
RUN update-alternatives --install /usr/bin/node node /usr/bin/nodejs 10

#install build essentials
RUN apt-get install --yes build-essential

#install electron
RUN npm install electron-packager --global
RUN npm install --save-dev electron

RUN mkdir /app
WORKDIR /app

COPY . ./

RUN dotnet restore
RUN dotnet electronize build /target linux
#RUN dotnet electronize start
