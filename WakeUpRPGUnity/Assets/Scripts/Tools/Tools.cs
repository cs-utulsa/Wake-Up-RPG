using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools {
    
    public static T[] Shuffle<T>(T[] array, System.Random rg) {
        for(int i = 0; i < array.Length - 1; i++) {
            int randomIndex = rg.Next(i, array.Length);

            T tempItem = array[randomIndex];

            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }

}