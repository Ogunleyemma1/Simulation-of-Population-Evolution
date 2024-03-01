using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTwo : MonoBehaviour
{
    

    void Start()
    {
        // Create a population of cells
       PopulationBuilder cells = new PopulationBuilder(40, 40);

        // Set some cells to be live initially based on pattern 2
        cells.Live(20, 19);
        cells.Live(20, 20);
        cells.Live(20, 21);
        cells.Live(20, 22);
        cells.Live(19, 18);
        cells.Live(19, 22);
        cells.Live(18, 22);
        cells.Live(17, 18);
        cells.Live(17, 21);

    
        
    
        // Calculate generations per frame
        //cells.CalculateGenerations(1);
        //cells.CalculateGenerations(5);
        //cells.CalculateGenerations(10);
        //cells.CalculateGenerations(20);
        cells.CalculateGenerations(50);
        
        
        

       
    }
}

    
    



