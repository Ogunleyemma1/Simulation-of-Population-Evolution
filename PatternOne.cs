using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         // Create a population of cells
       PopulationBuilder cells = new PopulationBuilder(40, 40);

        // Set some cells to be live initially based on pattern 3
        cells.Live(20, 19);
        cells.Live(20, 20);
        cells.Live(19, 20);
        cells.Live(19, 19);
        

    
        
    
        // Calculate generations per frame
        //cells.CalculateGenerations(1);
        //cells.CalculateGenerations(5);
        //cells.CalculateGenerations(10);
        //cells.CalculateGenerations(20);
        cells.CalculateGenerations(50); 
    }

    
}
