# PRACTICA #2: PASTRYSHOP UNIT TESTS

[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,visualstudio,js,html,css&perline=3)](https://skillicons.dev)

PastryShop es una app web que permite la venta de productos de pasteleria para una tienda y permite a los administradores gestionar los recursos de la pagina.

Esta app esta construida con "Vanilla Javascript", html y css en el frontend y con "c# .Net Core" en el Backend (API).

Este repositorio tiene el objetivo de servir para gestionar las actualizaciones de codigo para la practica #2 de la materia de Gestion de Calidad de la Universidad Catolica Boliviana.

Esta practica consiste en realizar pruebas unitarias para cualquier app. En este caso, escogimos la app ya mencionada.

A continuacion se detallan las herramientas principales para esta practica y como ejecutar las pruebas, calcula la cobertura de codigo y calcular metricas como la complejidad ciclomatica.

## 1 Herramientas:

Las principales herramientas para realizar los unit tests fueron:

- Visual Studio (IDE)
- .Net Core (Framework web API)
- XUnit (Framework para UnitTesting)
- Nuggets (paquetes c#)
  - Moq
  - xunit
  - InMemory
- Extensiones visual studio:
  - Fine Code Coverage
- Funciones nativas de visual studio:
  - Metricas de codigo (Code Metrics Results)
  - Test Explorer

## 2 Proceso de Ejecucion:

1. *Instalar visual studio*  
   
   Si es su primera instalacion, recuerde agregar los paquetes para desarrollo web y API's (preferiblemente la version 2022 para evitar incompatibilidad)

2. *Clonar este repositorio*

3. *Abrir la solucion del proyecto* 
   
   Abrir o Ejecutar el archivo: 
   
   /P2-PastryShop-UnitTesting/Backend/PastryShopAPI/PastryShopAPI.sln

### 2.1 Ejecutar Tests

1. Click en "Test", en la barra de menus superior (en la ventana de visual studio)

2. Click sobre la opcion: "Test Explorer"

3. En la ventana abierta, click en la doble flecha verde para ejecutar todos los tests

  
### 2.2 Calcular Cobertura de Codigo

La herramienta que escogimos "Fine Code Coverage" es una extension y no un nugget, por lo tanto, es un feature del IDE y no es parte del codigo del proyecto.

Por eso es necesario instalarla para poder ejecutarla, como se muestra a continuacion:

1. *Instalar la extension "Fine Code Coverage"*

  a. Ir a "Extensions", en la barra de menus superior (en la ventana de visual studio)
  b. Click en "Manage Extensions" (se abrira una ventana del catalogo de extensiones)
  c. En la barra de busqueda de dicha ventana, escribir "fine"
  d. Click en "install" sobre la extension "Fine Code Coverage"
  
2. *Ejecutar "Fine Code Coverage"*
   
   Ejecutar nuevamente los tests deberia abrir "Fine Code Coverage" automaticamente.
   
   Si no se abre automaticamente, entonces:
   
   a. Click en "View", en la barra de menus superior (en la ventana de visual studio)
   b. Click en "Other Windows"
   c. Click en "Fine Code Coverage"
   
### 2.3 Calcular Complejidad Ciclomatica

Visual studio tiene una herramienta nativa para ver detalles del proyecto. 
Principalmente la complejidad ciclomatica de cada archivo y metodos.

Para usarla:

1. Click en "Analyze", en la barra de menus superior (en la ventana de visual studio)
2. Click en "Calculate Code Metrics"
3. Click en "For Solution"

### Tip de Productividad

Todas estas herramientas (fine code coverage, code metrics, run tests), se abren inicialmente como ventanas emergentes.
Se recomienda anclarlas en una seccion del IDE para no tener que hacer todos los pasos para abrirlas y asi simplemente hacer click en la ventana anclada y ejecutar cada herramienta.

1. Para los tests, click en el doble boton verde
2. Para Fine Code Coverage, abrir ventana anclada luego de ejecutar tests
3. Para Code Metrics, abrir ventana y apretar el boton de la parte superior-izquierda (luce como una ventana con signos vitales)
