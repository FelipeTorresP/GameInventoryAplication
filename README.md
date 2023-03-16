# GameBackEnd

## Arquitectura

use Microservicios y DDD (Domain-Driven Design) para construir este proyecto de inventario de campeones y autenticación de usuario tiene varias ventajas.

Por ejemplo, al dividir el sistema en microservicios se puede lograr una mayor escalabilidad y modularidad, lo que significa que cada servicio puede ser desarrollado y desplegado de forma independiente sin afectar a los demás. Además, al implementar DDD, se puede asegurar que el diseño del sistema esté enfocado en el dominio del problema y en las necesidades del negocio, lo que puede hacer que el sistema sea más fácil de mantener y extender en el futuro.

Otras ventajas pueden incluir la reducción de acoplamiento entre los diferentes componentes del sistema, la posibilidad de utilizar tecnologías específicas para cada microservicio, y la capacidad de hacer pruebas y depuración de forma aislada y específica para cada servicio. En general, usar Microservicios y DDD puede mejorar la flexibilidad, la eficiencia y la calidad del sistema.

## Autenticacion

Claro que sí. JWT (JSON Web Tokens) fue elegido como método de autenticación porque es una forma segura y eficiente de transmitir información de identidad entre diferentes sistemas o servicios. Al utilizar JWT, se genera un token que contiene información del usuario autenticado, como su identificador único, y se firma digitalmente con una clave secreta. De esta forma, el token puede ser verificado por otros servicios y se puede estar seguro de que la información es válida y no ha sido modificada.

Además, se añadió la posibilidad de probar los endpoints protegidos con JWT en el Swagger, utilizando un botón de "Authorize" que permite incluir el token de autenticación en las solicitudes. Esto facilita las pruebas manuales y la depuración de los endpoints protegidos por autenticación JWT, ya que se puede generar el token fácilmente y probar su validez.

Adicionalmente, para esta autenticacion se uso la libreria de el identity proporcionada por microsoft para realizar la tarea.

## Base de datos

Para facilitar las pruebas y asegurarnos de que todo funcione correctamente, decidimos utilizar una base de datos en memoria en lugar de una base de datos real. Esto nos permitió crear y destruir la base de datos durante las pruebas sin apuntar a una base de datos real. Sin embargo, es importante destacar que esta solución puede ser fácilmente reemplazada por una base de datos real para su uso en producción.

Claro, aunque en este proyecto se optó por utilizar una base de datos relacional en memoria para facilitar el desarrollo y las pruebas, sería recomendable considerar el uso de una base de datos no relacional en un entorno de producción debido a la alta cantidad de transacciones y consultas que puede tener un sistema de gestión de inventario de juegos en línea. Una base de datos no relacional puede ofrecer una mejor escalabilidad y rendimiento para manejar grandes volúmenes de datos y consultas.

## Pruebas unitarias

se eligió MSTest para la realización de pruebas unitarias debido a que es una herramienta de pruebas integrada en Visual Studio, lo que facilita su uso y configuración en el proyecto. Además, es una herramienta ampliamente utilizada en proyectos .NET y cuenta con una sintaxis clara y sencilla para escribir pruebas unitarias, sin embargo tambien e trabajado con nUnit y Xunit.

## Secretos

En cuanto al almacenamiento del secreto utilizado para la autenticación JWT, se optó por guardar este valor en el archivo de configuración "appsettings.json" por motivos de simplicidad y facilidad en el desarrollo y pruebas de la solución. Sin embargo, es importante tener en cuenta que esto no es una práctica recomendada en entornos de producción. Para evitar exponer secretos en el código, se puede optar por utilizar variables de entorno para almacenar información confidencial y así garantizar una mayor seguridad en la gestión de credenciales sensibles.

## Codemaid

También utilicé la herramienta de Visual Studio llamada Codemaid para mantener mi código limpio y organizado. Esta herramienta me permitió eliminar rápidamente código innecesario, identar correctamente mi código y mantener mis nombres de variables y métodos consistentes en todo el proyecto. Esto me permitió centrarme en el desarrollo de nuevas características en lugar de preocuparme por el mantenimiento del código existente.


## Commentarios

Es importante mencionar que, al desarrollar un código limpio y estructurado, el mismo debe ser fácil de entender y autodocumentado en la medida de lo posible. Por supuesto, siempre es buena práctica agregar comentarios para explicar detalles importantes o complejos en el código. En este sentido, trate de dejar comentarios en las secciones críticas o complejas, pero evitando hacerlo en exceso para no entorpecer la lectura del código. En lugar de depender exclusivamente de los comentarios, enfoqué mis esfuerzos en desarrollar un código legible y fácil de entender, con nombres de variables y funciones descriptivos y estructuras de código coherentes.

## Adicional

las inyecciones de dependencias se hicieron con el método AddScoped() es porque se desea que cada solicitud HTTP tenga su propia instancia de las clases inyectadas.
