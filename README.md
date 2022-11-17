# UDPTracker

ClientUDP project - Console Application with which one we can send testing UDP calls to specific address.
<br />
<br />
UDPTracker project - contains 2 APIs:
<br />
<br />
-UDPTracker - WEB API for UDP server listener which one saves the client data to the database(IP and Message).
<br />
-UDPReport - WEB API for returning saved messages from the database by filter (UDPReport calls UDPTracker GET endpoint).
<br />
<br />
Platforms: ASP.NET Core 6 for the APIs, .Net Core 6 for the console application.
<br />
Frameworks: Entity Framework
<br />
Db-Aprroach: Code-first
<br />
Database: MSSQL Server
<br />
Tools: Swagger

<br />
It is configured to start the both API projects(UDPTracker, UDPReport) when it is ran.
<br />
<br />

**Setup of the project**
<br />

**1.Before we update the database to the our local machine, make sure to switch the startup project to be UDPTracker**

![image](https://user-images.githubusercontent.com/57111468/202565155-f7199411-931f-414e-8db1-41b054b4ca3e.png)

**2.Open package manager console and switch to UDPTracker.Data class library and run the "update-database" command**

![image](https://user-images.githubusercontent.com/57111468/202566138-8fc22746-ca17-4d7d-83f2-3d1229bd871d.png)

**3.Open the properties of the solution and make sure to change to fire both projects on the start up <br />**
Startup Project -> Multiple startup projects -> UDPReport and UDPTracker -> Action "Start" <br />

![image](https://user-images.githubusercontent.com/57111468/202566803-cb352060-fb9c-4315-9d65-41ec4e6c6b0a.png)

After these changes you should see this option on the startup project dropdown

![image](https://user-images.githubusercontent.com/57111468/202567159-6e3a8c1e-9016-4092-ae33-4ecb5a86d7a7.png)


**4.Run it and afterwards start the ClientUDP project <br />**
You should be able to test the applications by typing some message to the console and afterwards from Swagger you can get the data to check if it is saved properly.
<br />
<br />
![image](https://user-images.githubusercontent.com/57111468/202568644-f4054fb9-a9ad-4c29-861c-baf4fcb49df8.png)
<br />
<br />
![image](https://user-images.githubusercontent.com/57111468/202569562-558275fd-76fe-4154-a626-8e86625196a4.png)
<br />
<br />
Database check
<br />
![image](https://user-images.githubusercontent.com/57111468/202569356-fc9af482-f9a3-4791-8164-20665ed589a2.png)
