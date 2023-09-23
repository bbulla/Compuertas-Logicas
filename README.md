# A tener en cuenta:

*Los diagramas de clases están en docs. :eyes:

## Patrones y principios utilizados

Primero ver el código.

### Expert

Usamos el patrón Expert en las cuatro clases de compuertas al asignar la responsabilidad de calcular la salida a cada clase, puesto que cada una conoce sus entradas, por lo tanto, tiene la información necesaria para cumplir con la responsabilidad. Asimismo, aplicamos el patrón al asignar la responsabilidad de remover y agregar entradas a las clases de compuertas básicas (OR, AND, NOT), ya que las mismas conocen las entradas existentes, por lo tanto, evitarán que se agreguen entradas repetidas o se quiten entradas que no están en sus propias entradas.

### SRP

Aplicamos el principio SRP, ya que cada compuerta básica (OR, AND, NOT) tiene una única funcionalidad, es decir, proveer la salida a partir de los datos que conoce (sus entradas) y su comportamiento de compuerta (en la implementación del método de calcular salida). Asimismo, la puerta de garage cumple con el principio porque tiene una única funcionalidad, la cual es simular el circuito de una puerta de garage apretando y soltando botones que la abren o la cierran.

### Polimorfismo

Aplicamos el patrón polimórfico, puesto que asignamos responsabilidades relacionadas (agregar entradas, quitar entradas y calcular salida) a clases diferentes a través de operaciones polimórficas.