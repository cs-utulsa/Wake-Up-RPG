using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NarrationD5", menuName = "ScriptableObjects/NarrationDay5", order = 1)]
public class NarrationDay5 : NarrationScriptableObjectTemplate
{
    // Start is called before the first frame update
    new void OnEnable()
    {
        Day1Narr = new NarrLine[] {
        new NarrLine("We should get going", "MC", "", "background_day4_Field-03"),
new NarrLine("You are the one that had to sleep to recover. What was I supposed to do to occupy myself while you snored for hours?", "Roy", "Annoyed", ""),
new NarrLine("You’re telling me you didn’t have more grating days at your job at the arcade?", "MC", "", ""),
new NarrLine("...point taken.", "Roy", "Tired", ""),
new NarrLine("What way to the university?", "MC", "", ""),
new NarrLine("According to the map I found in the library…", "Roy", "Neutral", ""),
new NarrLine("What? You found a map??", "MC", "", ""),
new NarrLine("While you were admiring the hologram in a weird way...", "Roy", "Smug", ""),
new NarrLine("Okay, just tell me where to go with the motorcycle.", "MC", "", ""),
new NarrLine("We have to go through the forest.", "Roy", "Neutral", "background_day5_OpeningToForest"),
new NarrLine("Through the forest? I don’t remember ever going through it to go to class.", "MC", "", ""),
new NarrLine("Yeah, cause you didn’t have thousands of cars frozen in the middle of the road.", "Roy", "", ""),
new NarrLine("Okay, through the forest it is", "MC", "", "background_day5_DenseForest"),
new NarrLine("But I don’t know how to navigate in it, that’s on you human.", "Roy", "Pleased", ""),
new NarrLine("So you can take me to it and after it but not through it!!??", "MC", "", ""),
new NarrLine("It’s a forest, how hard can it be.", "Roy", "Annoyed", ""),
new NarrLine("It’s a forest without any directions, it’s going to take us a while.", "MC", "", "")

        };
    }


}
