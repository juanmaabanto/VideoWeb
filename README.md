# VideoWeb
Test Afex

## Despliegue
Se requiere:
1. Docker, https://www.docker.com/products/docker-desktop/
2. Makefile, si se usa windows https://linuxhint.com/run-makefile-windows/

Una vez instalado ir a la raíz del proyecto y escribir en un terminal;

```sh
  make up

```

Una vez se creen los contenedores esperar aprx. 3min para que cargue la instancia de SQL

Abrir el navegador e Ir a: http://localhost:5155/

## Despliegue sin Makefile
Para instalar solo con docker ejecutar los siguientes comandos en la raíz del proyecto

```sh
  docker build -t mssql:dev ./Database
  
  dotnet publish
  
  docker build -t videoweb:dev .
  
  docker-compose up -d
```

## Capturas de la aplicación
