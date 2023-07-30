
/*****************************************************************************************
* Food
*  Script for the food prefab objects. When the snake consumes a food object, then the 
*  player's score increments based on the assigned value of the food object. 
*  
*****************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //********************************************************************************
    // Editor Accessible Fields
    //********************************************************************************

    [SerializeField] private int value = 10;

    //********************************************************************************
    // Getters
    //********************************************************************************

    public int GetValue() { return value; }

}

