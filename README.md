# Sistema de Liquidacion de Haberes

Este proyecto consiste en el desarrollo de un sistema que permita la administración de los empleados y la liquidación de sus haberes.

## Tecnologías a utilizar :computer:

- Visual Studio 2019 - IDE.
- C# - lenguaje de programación.
- ASP.NET MVC - framework de desarrollo.
- Entity Framework - ORM.
- SQL Server - gestor de bases de datos.

## Pre requisitos :clipboard:

Tener instalado: 

- Visual Studio 2019.
- SQL Server.

## Detalles técnicos :wrench:

Se toma como convención que todos los empleados trabajan los 30 días del mes, ya que no tenemos un sistema que nos aporte esa información.  Por lo que a todos los empleados se les asignará el 8,33% sobre el sueldo básico por el presentismo.

## Base de Datos :floppy_disk:

### Diseño de la Base de Datos 

![alt-tag](https://github.com/BrunoFrancioni/sistema-liquidacion-haberes/blob/master/diagrama.png)

### Tabla Obras Sociales :pill:

La empresa otorga la posibilidad de elegir a los empleados entre 3 Obras Sociales, que incluyen cobertura tanto para el mismo como para su grupo familiar.

| Obra Social | Plan |
| ------------- | ------------- |
| Swiss Medical | SMG70 |
| OSDE | 510 |
| Galeno | 550 |

### Tabla Empleados :construction_worker:

Cuando se registra un empleado se piden:

- Nombre.
- Apellido.
- Lugar de trabajo - se considera que la empresa sólo tiene una sucursal y se ubica en Capital Federal.
- CUIL.
- Antigüedad - se guarda la antigüedad reconocida por la empresa.
- Fecha de Ingreso.
- Fecha de Egreso - que puede ser nula.
- Obra Social.
- Categoría - se guarda la categoría en la que el empleado trabaja y a partir de esta se obtiene el sector.
- Activo - lo empleados no se eliminan de la base de datos, sino que cuando no trabajan mas en la empresa se los identifica como no activos.

### Tabla Sector :briefcase:

Para el desarrollo de esta sistema, adoptamos el `Convenio Colectivo de Trabajo` con código `42/1989`, a partir del cuál definimos los sectores a trabajar y las categorías con sus respectivos salario base.

Los sectores que el mismo define son:

- Maestranza y Servicios.
- Administrativo.
- Cajero.
- Personal Auxiliar.
- Auxiliar Especializado.
- Vendedor.

### Tabla Categorías :office:

Dentro de cada Sector, se establecen diferentes Categorías y en ellas el salario base a cobrar.

**Maestranza y Servicios**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 33.660,46 |
| B | $ 33.797,85 |
| C | $ 34.244,32 |

**Administrativo**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 34.148,74 |
| B | $ 34.340,18 |
| C | $ 34.531,51 |
| D | $ 35.105,62 |
| E | $ 35.583,92 |
| F | $ 36.285,58 |

**Cajero**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 34.308,14 |
| B | $ 34.531,50 |
| C | $ 34.818,54 |

**Personal Auxiliar**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 34.308,14 |
| B | $ 34.627,07 |
| C | $ 35.679,61 |

**Auxiliar Especializado**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 34.691,02 |
| B | $ 35.265,03 |

**Vendedor**

| Categoría | Salario Base |
| ------------- | ------------- |
| A | $ 34.308,14 |
| B | $ 35.265,15 |
| C | $ 35.583,92 |
| D | $ 36.285,58 |


### Tabla Bancos :bank:

La empresa otorga la posibilidad de elegir a los empleados entre 5 bancos, que son con los que esta trabaja.

- Galicia.
- Macro.
- Santander Río.
- BBVA.
- Credicoop.

### Tabla Cuentas Bancarias :dollar:

Se establece que cada cuenta bancaria pertenece a un sólo banco y tiene su propio cbu.

### Tabla Depósitos :moneybag:

Por cada depósito de sueldo, se guarda el empleado y la fecha de depósito.

### Aspectos de mejorar del sistema

- Pobre desarrollo de FrontEnd. Es un sistema estático en el que en cada solicitud se tiene que recargar la página para ir hasta el servidor.
- Tiene funcionamiento estático. No posee lógica para que funcione mes a mes.
- Los legajos no tienen lógica. Sólo toman el valor número de ID colocado por la Base de Datos autoincrementalmente.
- No tiene la capacidad de registrar la asistencia de cada empledado, ni los depósitos registrados cada mes, asi como también los feriados trabajados y las horas extras trabajadas.
- No posee Pruebas Unitarias que realmente prueben el sistema y nos permitan analizar su correcto funcionamiento a medida que desarrollamos.