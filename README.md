# GttCertificates-BackEnd

Este proyecto se basa en una app que gestiona los certificados de una entidad, teniendo la capacidad de leerlos, modificarlos, 
renovarlos y crear tickets en Jira creando incidencias con cada certificado caducado. Esta es la parte del BackEnd que está conectada
con el front, aquí pongo el link que conecta con este repositorio: 

https://github.com/pedronicolas/gtt-certificates

## ¿Cómo lanzarlo?

Ejecútalo en Visual Studio y se abrirá una pestaña automáticamente. La app tendrá que ser relanzada para que se apliquen cambios.

## Funcionalidades

En la primera versión(v1), subida para la entrega en la empresa, la app contiene las siguientes funcionalidades:
  -  
 - Implementación de base de datos en PostgreSQL. 
 
 - Manejo de autenticación con JWT, en la cabecera de todas las peticiones a la API. 
 
 - Tarea diaria que funciona cada 12 horas, comprobando si los certificados están caducados.
 
 ## Conexión con otros componentes
Este Back en .NET, está conectado a un Front en Angular. Para acceder al repositorio y poder conectarlos, aquí te dejo el enlace. Gracias por tu atención y espero que lo disfrutes. LET'S CODE.
 https://github.com/pedronicolas/gtt-certificates
