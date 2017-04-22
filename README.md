# Implementación de Sistema Inteligente 

## Red Neuronal Artificial

El juego **4 en Línea** (*Connect 4* en inglés) tiene un tablero de 7 columnas y 6 filas.

Las fichas del **Jugador A** se representan con `O` y las del **Jugador B**, con `X`.

A cada celda de la matriz 7x6 le asignaremos un número identificador, de la siguiente manera: 

​| C1 | C2 | C3 | C4 | C5 | C6 | C7
--- | --- | --- | --- | --- | --- | --- | ---
**R6** | 36 | 37 | 38 | 39 | 40 | 41 | 42
**R5** |  29 | 30 | 31 | 32 | 33 | 34 | 35
**R4** | 22 | 23 | 24 | 25 | 26 | 27 | 28
**R3** | 15 | 16 | 17 | 18 | 19 | 20 | 21
**R2** | 8 | 9 | 10 | 11 | 12 | 13 | 14
**R1** | 1 | 2 | 3 | 4 | 5 | 6 | 7

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
**R6** |  |  | |  |  |  | 
**R5** |  |  | | X |  |  | 
**R4** |  |  |  | X | X  | O | 
**R3** |  |  |  | O | O | X | 
**R2** |  |  |  | O | X | O | 
**R1** |  |  | X | O | O | X |

El registro o fila que representa su estado en formato `CSV` es:

`0, 0, 1, -1, -1, 1, 0, 0, 0, 0, -1, 1, -1, 0, 0, 0, 0, -1, -1, 1, 0, 0, 0, 0, 1, 1, -1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0`

## Entrenamiento

Entrenaremos de manera supervisada a la RNA.

Al registro del estado del tablero le añadimos una columna que representa la jugada a realizar (en que columna colocar la ficha) según el estado dado.

Siguiendo el ejemplo anterior, si el experto determina que la mejor jugada es la columna 3, el registro queda:

`0, 0, 1, -1, -1, 1, 0, 0, 0, 0, -1, 1, -1, 0, 0, 0, 0, -1, -1, 1, 0, 0, 0, 0, 1, 1, -1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3`

### Referencias

* [4 en Línea](https://es.wikipedia.org/wiki/Conecta_4)
* [CSV](https://tools.ietf.org/html/rfc4180)
