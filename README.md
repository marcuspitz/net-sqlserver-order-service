# net-sqlserver-order-service
Basic .NET application with SQL Server to order products (.net core 3.1)

# Getting started
Set up MSSQL and run this on docker or if you'd prefer run via dotnet CLI or Visual Studio

## Setting up SQL Server
```
docker pull mcr.microsoft.com/mssql/server:2019-latest
```
Running MSSql container for sql1
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=M1sr0n$%*pA12@" -p 1435:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2019-latest
```

## Configs
appsettings.json describe all required configurations such as database

# Routes
## Auth
Sign-in and Sign-up
```
POST /Auth/signin
POST /Auth/signup
```

## User
Return all users (accept filters)
```
GET /Users
```

## Product
Return all products (accept filters)
```
GET /Products
```
Return one product by its ID
```
GET /Products/{ID}
```
Add a new product
```
POST /Products
```
Update an existing product
```
PUT /Products
```

## Order
Return all orders
```
GET /Orders
```
Return one order by its ID
```
GET /Orders/{ID}
```
Add a new order
```
POST /Orders
```