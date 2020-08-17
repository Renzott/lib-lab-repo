# Proyecto de Bandeja de Credito


# Tecnologias usadas

  - Next.js
  - .NetCore 3.1
  - Flask (Python)


### Descripcion

Esta es una aplicacion de recibo de Creditos, analisis y resultados.
Se esta usando Next.js en el Frontend.
NetCore para el Backend
Y para finalizar, Flask como una API fictica

### Enlaces:

Se recomienda visitar las urls en este orden, heroku deactiva las aplicaciones a los 30 min;

NetCore:
https://lilab-backend-netcore.herokuapp.com/ (si te aparece un mensaje de "status code 404", esta bien, a cierto servidor se le olvido poner un mensaje al inicio)

Flask-Python:
https://lilab-backend-python.herokuapp.com/

Next.js Frontend:
https://lilab-next-repo-git-master.renzott.vercel.app/

Credenciales
mail: maria@credito.com
password: patito

### Installation

En cada carpeta estara las aplicaciones separadas

Para netcore, esta corre en linux:
```sh
$ chmod 333 ./creditos-backend   
$ ./creditos-backend 
```
El codigo esta en una carpeta aparte llamada: "creditos-backend"


En Python solo se debe instalar los requerimientos 

```sh
$ pip install -r requirements.txt
$ python main.py
```

Para Next.js solo deben instalar los paquetes de npm y correr la aplicacion
```sh
$ npm install
$ npm run dev
```

#### Importante

Recuerden cambiar las URLS de los diferentes puertos, en caso de errores de conexion
Puede ser que el puerto de netcore cambie, asi que tenga en cuenta eso

