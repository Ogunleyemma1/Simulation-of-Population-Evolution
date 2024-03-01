using System;
using System.Collections;
using System.Collections.Generic;
using oompe.lib;
using TMPro;
using UnityEngine;

//Initializing a rectangular Array class to draw an array of 2D rectangles
public class RectangleArrayBuilder
{
    // Definition of Variables
    private Rectangle [,] rectangleArray;

    private Rectangle rectangle;
    private float x, y, w, h;
    private Color color;

    public GameObject gameObject; 
    //Creating the constructor for building the rectangle array
    public RectangleArrayBuilder(int row, int column){

        //Defining initial parameters for the rectangle
        this.x = 0;
        this.y = 0;
        this.w = 1f;
        this.h = 1f;

        float spacer = 0.2f;

        this.gameObject = new GameObject();
        this.rectangleArray = new Rectangle[row, column];

        for(int i = 0; i<row; i++){

            for(int j = 0; j<column; j++){
                
                //creating an instance of the rectangle class
                 this.rectangle = new Rectangle(this.gameObject, this.x, this.y, this.w, this.h);

                 //storing  the rectangle created into the arrays of rectangles
                this.rectangleArray[i, j] = this.rectangle;

                 //computing the new position of x
                this.x += this.w + spacer;
                
            }

            //Update for the value of the new row
            this.x = 0;

            //Compute the new value of y
            this.y += this.h + spacer;
        }
        
    }


    //Creating a method to set the colour for rectangle based on population array
    public void SetRectangleColor(int [,] populationArray){

        for(int i = 0; i < populationArray.GetLength(0); i++){

            for (int j = 0; j < populationArray.GetLength(1); j++){

                //Introducing a conditional statement to say if population array is 0, colour should be black and if 1 should be white
                if(populationArray[i, j] == 0){

                    rectangleArray[i, j].SetColor(Color.black);
                }

                else{

                    rectangleArray[i, j].SetColor(Color.yellow);
                }
            }
        }
    }

    //Creating a method to draw the array of rectangles in unity.
    public void Draw(){

        for(int i = 0; i<rectangleArray.GetLength(0); i++){

            for(int j = 0; j<rectangleArray.GetLength(1); j++){


                this.rectangleArray[i, j].Draw();
            }
        }
    }


    //Creating a Method to return Game Object
    public GameObject GetGameObject(){

        return this.gameObject;
    }



}