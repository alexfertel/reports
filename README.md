# Seminarios de LP 2019 - 2020

Este *repo* contiene los seminarios (informes), divididos por
grupo, de los estudiantes del curso `2019 - 2020` de la asignatura
**Lenguajes de programación**.

En las siguientes secciones de este *README* se especifica las reglas,
recomendaciones y requisitos para contribuir al repo y lograr mantener
el curso de manera no-presencial.

## Markdown

[Markdown](https://en.wikipedia.org/wiki/Markdown) es un *markup language* (como *HTML*) ligero
que se utiliza debido a su discreta sintaxis que permite leer el contenido antes y después de
renderear fácilmente. En este repositorio se brinda un *cheatsheet* de [referencia](markdown.pdf).  

### Compilar a LaTeX

En caso de hacer el seminario en `Markdown`, pueden contactar con el profesor del **Grupo 2**
para compilar a `LaTeX` el documento y mantener los estilos de las orientaciones de los seminarios. 

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

* `git clone [repo]` - Este comando *clona* el repositorio localmente, en el directorio actual.

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

El flujo para contribuir al repositorio es el siguiente:

1. Ser colaborador del repositorio. Esto implica que algún colaborador
le da acceso antes. Contactar con los profesores para pedir acceso.

2. Clonar el repo si no lo ha clonado: 

```bash
$ git clone https://github.com/alexfertel/reports.git
```

3. Crear una nueva rama y posicionar `HEAD` en ella:

```bash
$ git checkout -b [nombre de la rama]
```
 
4. Hacer los cambios, añadirlos y hacer commit.

```bash
$ echo "Hello, World!" > test.txt
$ git add test.txt
$ git commit -m "Add `test.txt` with the text 'Hello, World!'"
```

5. Subir la nueva rama con cambios.

```bash
$ git push origin [nombre de la rama]
```

6. Crear un *Pull Request* a `master`. Un *PR* es un feature muy útil
que permite mezclar 2 ramas del repositorio remoto. **NO** se puede pushear
a la rama `master`, de hecho, aunque lo intente, no podrá hacerlo. Siempre
debe crear un PR para mezclar sus cambios con `master` en el repositorio
remoto. En los PR se forman hilos de discusión, que se utilizarán para hacer
comentarios sobre los cambios y de esta forma los profesores podrán
revisar dichos cambios en conjunto con los estudiantes.

## Organización y nomenclatura

### Directorios y seminarios

El repositorio está organizado de la siguiente forma:

    ├── src/
    │   ├── grupo_1/
    │   │   └── ...
    │   └── grupo_2/
    │       └── ...
    ├── .gitignore
    └── README.md

En la carpeta `grupo_X` deberán ir los seminarios del grupo número `X`.
Los seminarios irán dentro de un directorio con el siguiente formato de nombre
`equipo_X_seminario_Y`, donde `X` es el número del equipo y `Y` es el número del seminario.

Dentro de la carpeta del seminario el seminario deberá nombrarse
`Seminario [Tema del Seminario].[pdf, md, docx]`. Un ejemplo del
directorio resultante sería el siguiente:

    ├── src/
    │   ├── grupo_1/
    │   │   ├── equipo_1_seminario_1/
    │   │   │    ├── Seminario C++98.pdf
    │   │   │    └── Code
    │   │   ├── equipo_2_seminario_2/
    │   │   │    ├── Seminario C++11.pdf
    │   │   │    └── Code
    │   │   └── equipo_3_seminario_3/
    │   │        └── ...
    │   └── grupo_2/
    │       └── ...
    ├── .gitignore
    └── README.md

### Ramas

Los nombres de las ramas deben definir bien qué seminario y de qué equipo viene,
manteniendo el siguiente formato: `grupo-Z/equipo-X/seminario-Y`, donde `X` es el número
del equipo y `Y` es el número del seminario que le toca a ese equipo y `Z` es el número del equipo, dado que cada equipo
hace al menos 3 seminarios, un posible ejemplo de rama sería `grupo-1/equipo-3/seminario-3`.


## Ejemplos

Ahora mismo además de los ejemplos que están en este *README*, pueden referirse al repo
para la estructura del directorio y los PRs.

Cualquier duda contactar con los profesores.



