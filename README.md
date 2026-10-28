-Ultratumba-
Prototipo de plataformas 2D para la evaluacion. Cuenta la historia de un esqueleto que logró escapar de la cueva en busca de un mejor pasar.

-Como correrlo-
Clona o descarga el repositorio.
Ábrelo en Unity (versión LTS recomendada).
Entra a Assets/Scenes, abre la escena MainMenu y dale al Play. (También hay un build funcional en la carpeta /Build).

-Controles-
Moverse: A / D o las flechas izquierda y derecha.
Saltar: W, Flecha Arriba o Espacio.
Menú: Clic con el mouse en los botones.

-Detalles tecnicos-
Motor: Unity 6.5
Físicas: Rigidbody2D con gravedad ajustada y detección de suelo
Audio: Música de fondo en loop y efectos de sonido independientes (PlayOneShot) para saltos, pasos con intervalo y clics de interfaz.

-Equipo-
Todo: Victor Alejandro Aroca Candia

-Riesgos y Mitigaciones-
Riesgo: Que el personaje atravesara el suelo o se quedara pegado en las esquinas por las físicas.
Mitigación: Ajuste fino de los colliders (BoxCollider2D) y uso de un radio de detección de suelo (OverlapCircle)
Riesgo: Que el sonido de los pasos o de las monedas saturara o sonara repetidamente en milisegundos.
Mitigación: Implementación de un pequeño temporizador (cooldown) para los pasos y uso de PlayOneShot para efectos independientes.
