We want to simulate a simple population. This population consists of cellular automats, with each cell having two states: alive or dead. Every cell has 8 neighbors (Moore-Neighborhood). The state of the cell depends on its current state and the number of living and dead neighbors. The goal is, to simulate the evolution of an initial population. The subsequent generation is a result of the prior one. Hence, care for not mixing the states between the generations. Develop a software, which models the evolution of the population and visualizes the result as a grid with colored squares.
2. Evolution rules
I. Dead automat
a. Cell reincarnates if it has got exact 3 living neighbors
b. Else it stays dead
II. Living automat
a. Cell dies if it has got less than 2 living neighbors (loneliness)
b. Cell stays alive if it has got 2 or 3 living neighbors
c. Cell dies if it has got more than 3 living neighbors (overpopulation)
