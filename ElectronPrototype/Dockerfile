FROM microsoft/dotnet

RUN npm install

RUN mkdir /app
WORKDIR /app

COPY /Isalore/ ./

RUN dotnet restore
RUN dotnet electronize init
RUN dotnet electronize start