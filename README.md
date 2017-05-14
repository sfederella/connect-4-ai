# Implementación de Sistema Inteligente 

## Red Neuronal Artificial

El juego **4 en Línea** (*Connect 4* en inglés) tiene un tablero de 7 columnas y 6 filas.

Las fichas del **Jugador A** se representan con `O` y las del **Jugador B**, con `X`.

A cada celda de la matriz 7x6 le asignaremos un número identificador, de la siguiente manera: 

​| C1 | C2 | C3 | C4 | C5 | C6 | C7
--- | --- | --- | --- | --- | --- | --- | ---
**R1** | 1 | 2 | 3 | 4 | 5 | 6 | 7
**R2** | 8 | 9 | 10 | 11 | 12 | 13 | 14
**R3** | 15 | 16 | 17 | 18 | 19 | 20 | 21
**R4** | 22 | 23 | 24 | 25 | 26 | 27 | 28
**R5** | 29 | 30 | 31 | 32 | 33 | 34 | 35
**R6** | 36 | 37 | 38 | 39 | 40 | 41 | 42

Cada celda puede encontrarse en uno de tres estados:

​Estado | Valor numérico
--- | ---
​Ocupada por ficha del Jugador A | -1
​Ocupada por ficha del Jugador B | 1
​Vacía | 0

Representaremos el estado del tablero manera tabular, utilizando el formato `CSV`, donde el número identificador de la celda indica su posición en el registro.

Por ejemplo, si el estado del tablero es:

​| C1 | C2 | C3 | C4 | C5 | C6 | C7
--- | --- | --- | --- | --- | --- | --- | ---
**R1** |  |  | |  |  |  | 
**R2** |  |  | | X |  |  | 
**R3** |  |  |  | X | X  | O | 
**R4** |  |  |  | O | O | X | 
**R5** |  |  |  | O | X | O | 
**R6** |  |  | X | O | O | X |

El registro o fila que representa su estado en formato `CSV` es:

`0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, -1, 0, 0, 0, 0, -1, -1, 1, 0, 0, 0, 0, -1, 1, -1, 0, 0, 0, 1, -1, -1, 1, 0`

## Entrenamiento

Entrenaremos de manera supervisada a la RNA.

Al registro del estado del tablero le añadimos una columna que representa la jugada a realizar (en que columna colocar la ficha) según el estado dado.

Siguiendo el ejemplo anterior, si el experto determina que la mejor jugada es la columna 3, el registro queda:

`0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, -1, 0, 0, 0, 0, -1, -1, 1, 0, 0, 0, 0, -1, 1, -1, 0, 0, 0, 1, -1, -1, 1, 0, 3`

Utilizando un jugador automatizado con una estrategia defensiva de juego y haciéndolo jugar contra sí mismo con un parámetro de aleatoriedad de jugadas, generamos el dataset con el cual entrenaremos a la RNA.

A este dataset le aplicamos un filtro posterior, removiendo jugadas duplicadas y contradictorias.

## Implementación

Para implementar la RNA y correr los experimentos, utilizaremos *Azure Machine Learning*.

## Experimentos

#### Parámetros Fijos

* 80% del dataset utilizado para entrenar la RNA, 20% utilizado para la comprobación
* RNA multicapa back propagation
* 1 capa de entrada con 42 neuronas
* 1 capa de salida con 7 neuronas
* 0,1 como coeficiente de entrenamiento
* Función gausianna

#### Resultados

​| Neuronas en capa oculta 1 |  Neuronas en capa oculta 2 | Iteraciones | Tiempo de entrenamiento (segundos) | Exactitud del modelo
--- | --- | --- | --- | --- 
E1 | 100 | - | 100 | PENDIENTE | PENDIENTE
E2 | 100 | - | 1000 | PENDIENTE | PENDIENTE
E3 | 100 | - | 10000 | PENDIENTE | PENDIENTE
E4 | 1764 | - | 100 | 1 | 0,482998
E5 | 1764 | - | 1000 | 1 | 0,469088
E6 | 1764 | - | 10000 | 2262 | 0,472952
E7 | 74088 | - | 100 | 1037 | 0,452087
E8 | 74088 | - | 1000 | PENDIENTE | PENDIENTE
E9 | 100 | 100 | 100 | PENDIENTE | PENDIENTE
E9 | 100 | 100 | 1000 | PENDIENTE | PENDIENTE
E9 | 100 | 100 | 10000 | 1007 | 0,412674
E10 | 1000 | 1000 | 100 | PENDIENTE| PENDIENTE
E10 | 1000 | 1000 | 1000 | 2292 | 0,491499
E11 | 1000 | 1000 | 2500 | 6671 | 0,502318
E12 | 1000 | 1000 | 10000 | 27749 | 0.49459

### Referencias

* [4 en Línea](https://es.wikipedia.org/wiki/Conecta_4)
* [CSV](https://tools.ietf.org/html/rfc4180)
* [Azure Machine Learning](https://docs.microsoft.com/es-es/azure/machine-learning/machine-learning-create-experiment)
* [Net#](https://docs.microsoft.com/es-es/azure/machine-learning/machine-learning-azure-ml-netsharp-reference-guide)
