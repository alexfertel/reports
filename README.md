# Seminarios de LP 2019 - 2020

Este *repo* contiene los seminarios (informes), divididos por
grupo, de los estudiantes del curso `2019 - 2020` de la asignatura
**Lenguajes de programación**.

En las siguientes secciones de este *README* se especifica las reglas,
recomendaciones y requisitos para contribuir al repo y lograr mantener
el curso de manera no-presencial.

## Git

**GIT** es un [sistema de control de versiones distribuido](https://en.wikipedia.org/wiki/Git).
Es requisito su uso, pues estaremos usándolo para gestionar este repositorio y poder utilizar
las herramientas que nos brinda [GitHub](https://github.com/).

### Instalación

Pueden encontrar cómo instalarlo en su *SO* de preferencia 
[aquí](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git).

Luego de la instalación, en su sistema debe encontrarse un *CLI* 
(*Command Line Interface*) que le permitirá ejecutar **comandos**
desde una terminal (En el caso de *Windows* dependerá de como haya decidido
instalarlo, pero se le recomienda instalar de forma que se le provea una terminal).

El siguiente comando debe mostrar la versión de `git` que se instaló:

```bash
$ git --version
git version 2.17.1
```

Si en su terminal ocurre algún problema, intente instalarlo nuevamente o pida ayuda.

### Principales comandos

Para contribuir a este repositorio ud deberá conocer ciertos comandos básicos de `git`.
Todos los comandos se ejecutan desde una terminal localizada en la carpeta del repositorio
con la siguiente sintaxis:

```bash
$ git [comando] [argumentos]
```

Donde `comando` es la función a ejecutar y `argumentos` se auto-explican.

A continuación se explican los que se consideran imprescindibles de forma simplificada, tome esta sección como referencia
cuando no recuerde bien qué hace algún comando básico, no para aprender dichos comandos, para esto
refiérase a la documentación. Todos los comandos de `git` permiten el argumento `--help` que muestra una
ayuda completa sobre el comando.

* `git status` - Este comando muestra el estado actual del repositorio de `git`. Es el comando más básico
                y a donde deben referirse cuando tengan dudas, puesto que siempre muestra ayuda básica.

* `git add [path]` - Este comando pasa un archivo de estar *untracked* o *modified* al *staging area*. Para más
                    info sobre esto, navegue [aquí](https://backlog.com/git-tutorial/git-workflow/).

* `git commit -m "Mensaje del commit"` - Este comando añade al historial de `git` los archivos a los que se le ha
                hecho `git add` (*index* o *staging area*).

* `git checkout [commit|branch]` - Este comando permite navegar por el historial de `git`. `commit` es un
                identificador de un *commit* o un *substring* de este que lo identifique unívocamente. `branch`
                es el nombre de una rama en el repositorio.

* `git branch -v` - Este comando muestra las ramas actuales del repo.

* `git checkout -b [nombre]` - Este comando crea una rama nueva y mueve `HEAD` para esa rama.

### *Workflow* básico



 


