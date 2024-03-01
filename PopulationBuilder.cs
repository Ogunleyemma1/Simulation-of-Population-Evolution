using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using oompe.lib;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PopulationBuilder
{
    // Definition of Variables
    private int [,] populationArray;
    private int[,] resultedPopulationArray;
    private RectangleArrayBuilder rectangles;

    private int generation;

    //Initializing a constructor to initialize a 2D array of Zeros
   public PopulationBuilder(int row, int column){

    this.populationArray = new int[row, column];

    for(int i = 0; i < row; i++){
        
        for (int j = 0; j < column; j++){

            this.populationArray[i, j] = 0;


        }
    }
   }

    // Creating a method to set live cells to number 1
   public void Live(int row, int column){
    
        this.populationArray[row, column] = 1;
  
   }


    //Creating a method from the object of rectangle array class to display resulting rectangle.
   public void Display(){

    //creating an instance of the rectangle array class
    this.rectangles = new RectangleArrayBuilder(this.populationArray.GetLength(0), this.populationArray.GetLength(1));

    this.rectangles.SetRectangleColor(this.populationArray);

    rectangles.Draw();

    //For Visuals and displaying on console
                var text = this.rectangles.GetGameObject().AddComponent<TextMeshPro>();
                text.text ="The Resulting Pattern for Generation " + (Math.Max(1,generation))  + " is shown ";
                text.fontSize = 20;
                text.color = Color.red;
                text.transform.position = new Vector3(-30, -30, 0);
    
   }



   // Implementing a helper function to count the numbers of live neighbours in the cell.
     private int NeighbourCount(int row, int column, int[,] populationArray){

        //Defining a variable to store the value of the live neighbour
        int neighbourCount = 0;
        
        //Implementing a for loop to run check each cell in the population array
        for (int i = row - 1; i < row + 2; i++){

            for (int j = column - 1; j < column + 2; j++){

                //checking for neigbouring cells and not including the cell itself
                if (i >= 0 && i < populationArray.GetLength(0) && j >= 0 && j < populationArray.GetLength(1) && (i != row || j != column)){

                    if (populationArray[i, j] == 1){

                        neighbourCount++;
                    }
                }
            }
        }
       
       //returning the count of the neighbour
        return neighbourCount;
    }
    
    //Implementing a  helper method to update pattern in cells based on the given set of rules
    private int[,] UpdatePopulation(){

        //creating a variable to store the updated population array
        this.resultedPopulationArray =  new int[this.populationArray.GetLength(0), this.populationArray.GetLength(1)];

        //creating a nested for loops to count the numbers of live neighbours
        for (int i = 0; i < populationArray.GetLength(0); i++){

            for (int j = 0; j < populationArray.GetLength(1); j++){

                //Counting the live neighbour for each cell
                int  liveNeighbours = NeighbourCount(i, j, this.populationArray);

                //Applying the rules to check if a cell is dead or live
                if (this.populationArray[i, j] == 0){

                    if(liveNeighbours == 3){

                        // Cell reincarnates if it has exactly 3 living neighbors
                        this.resultedPopulationArray[i, j] = 1;
                    }

                    else{

                        //Else it stays dead
                        this.resultedPopulationArray[i, j] = 0;
                    }

                } 
                else {

                    if(liveNeighbours < 2 || liveNeighbours > 3){

                        //Cell dies if it has got less than 2 living neighbors or if it has got more than 3 living neighbors
                        this.resultedPopulationArray[i, j] = 0;
                    }
                    else{

                        //Cell stays alive if it has got 2 or 3 living neighbors
                        this.resultedPopulationArray[i, j] = 1;
                    }
                }
            
                
            }
        }

        return resultedPopulationArray;
    }

    //Implementing a method to calculate the numbers of generations
    public void CalculateGenerations(int numGenerations)
    {
        //Introducing a conditional statement to return initial pattern when number of generations is 1 and updated for number of generations
       if(numGenerations<= 1) {

        Display();
       }
       else{
            for ( generation = 1; generation < numGenerations; generation++){

           
            this.populationArray = UpdatePopulation();
            }

            Display();
       }
              
    }

    //Helper function just to print the result of the population array to confirm array is updating as required
    private string Print(int [,] array){

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine( "[");

        for(int i = 0; i < array.GetLength(0); i++){

            for(int j = 0; j<array.GetLength(1); j++){

                stringBuilder.Append(array[i, j].ToString()+ "\t"); // \t is used for tabs

            }

            //separate the rows
            stringBuilder.AppendLine("");

        }

        stringBuilder.Append("]");

        return stringBuilder.ToString();
   }

   

    
}



