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

Una vez se creen los contenedores esperar aprx. 4min para que cargue la instancia de SQL

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/contenedores.png)

Abrir el navegador e Ir a: http://localhost:5155/

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/web-init.png)

## Despliegue sin Makefile
Para instalar solo con docker ejecutar los siguientes comandos en la raíz del proyecto

```sh
  docker build -t mssql:dev ./Database
  
  dotnet publish
  
  docker build -t videoweb:dev .
  
  docker-compose up -d
```

## Capturas de la aplicación


### Añadir Video

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/add-1.png)

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/add-2.png)


### Lista de Videos

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/list-1.png)


### Detalle Video

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/detail-1.png)


### Ver Video

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/detail-2.png)

### Eliminar Video

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/delete-1.png)

![alt text](https://github.com/juanmaabanto/VideoWeb/blob/main/Docs/Images/list-2.png)
