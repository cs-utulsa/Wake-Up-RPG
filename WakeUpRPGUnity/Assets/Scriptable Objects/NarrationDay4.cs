using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NarrationD4", menuName = "ScriptableObjects/NarrationDay4", order = 1)]
public class NarrationDay4 : NarrationScriptableObjectTemplate
{
    // Start is called before the first frame update
    new void OnEnable()
    {
        Day1Narr = new NarrLine[] {
        new NarrLine("Finally can use this toolkit I’ve been lugging around at least. These new models can be expansive but so heavy! Then again, I did take my roommates’ instead of my crappy one so I guess beggers can’t be choosers...", "MC", "", "background_day4_Field-01"),
new NarrLine("Okay, we need these 5 pieces.", "Roy", "Neutral", ""),
new NarrLine("What is that you got there? It looks like some kind of journal", "Roy", "", ""),
new NarrLine("Oh, haven’t noticed this…", "MC", "", ""),
new NarrLine("What are you waiting for? Read it! If you humans are good for anything, you have some funny drama. Every break at work I would tune in for some of those reality tv catfights", "Roy", "Smug", ""),
new NarrLine("I can’t just read it… It looks like their personal notes about the internship.", "MC", "", ""),
new NarrLine("Humans really act stupid with all this respect stuff. What if there is something useful? We don’t know this professor Canul that well.", "Roy", "Annoyed", ""),
new NarrLine("Yeah… maybe there’s something about him here.", "MC", "", ""),
new NarrLine("Initially my internship was all about magical artifacts, I was so excited!! But something changed in professors Canul objectives and now he’s focused on its medical implementation. I think it’s still interesting but it’s not what I signed up for… I can’t say anything, Professor Canul is too of a good person.", "NULL", "", "background_day4_Field-02"),
new NarrLine("Now we’re getting somewhere!", "Roy", "Pleased", ""),
new NarrLine("Why did he stop with his life work for another area of studies? He dedicated years to it and decided to change it?", "MC", "", ""),
new NarrLine("Well, don’t stop then, I need more.", "Roy", "Annoyed", ""),
new NarrLine("It’s getting late… We don’t want to look for the parts for the motorcycle and build it in the dark.", "MC", "", ""),
new NarrLine("You can’t leave me hanging like this.", "Roy", "", ""),
new NarrLine("Help me build it then and we’ll continue later. The quicker we build this, the more time we can spend on invading my friend’s privacy.", "MC", "", "")

        };
    }


}
