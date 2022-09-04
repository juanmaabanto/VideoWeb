create-testdb:
	@echo "Creando base de datos MSSQL"
	@docker build -t mssql:dev ./Database
	# @docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssw0rd' -e 'MSSQL_PID=Express' --name sqlserver -p 14339:1433 -d mssql:dev

create-web:
	@echo "Creando aplicación web"
	@dotnet publish
	@docker build -t videoweb:dev .
	# @docker run -e 'ASPNETCORE_ENVIRONMENT=development' --name videoweb -p 5155:80 -d videoweb:dev

up: create-testdb create-web
	@docker-compose up -d