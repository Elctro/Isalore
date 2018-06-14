
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
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash -
RUN apt-get install --yes nodejs 
#RUN update-alternatives --install /usr/bin/node node /usr/bin/nodejs 10
RUN npm install npm --global

#install build essentials
RUN apt-get install --yes build-essential

#install electron
RUN npm install electron-packager --global
RUN npm install --save-dev electron

#xui libs
RUN DEBIAN_FRONTEND=noninteractive apt-get --yes install libgtk2.0-0 libxss1 libgconf-2-4 libnss3 libasound2 xorg libcanberra-gtk-module

RUN mkdir /app
WORKDIR /app

COPY . ./

RUN dotnet restore
RUN dotnet electronize build /target linux
#RUN dotnet electronize start


