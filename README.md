# UDPTracker

ClientUDP project - Console Application with which one we can send testing UDP calls to specific address.
UDPTracker project - contains 2 APIs:
-UDPTracker - WEB API for UDP server listener which one saves our data to the database(IP and Message).
-UDPReport - WEB API for returning saved messages from the database by UDPTracker endpoint -> GET method.

Platforms: ASP.NET Core 6 for the APIs, .Net Core 6 for the console application.
Frameworks: Entity Framework
Db-Aprroach: Code-first
Database: MSSQL Server
Tools: Swagger
