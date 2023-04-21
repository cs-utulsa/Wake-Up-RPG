using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NarrationScriptableObjectTemplate;

[CreateAssetMenu(fileName = "NarrationD2", menuName = "ScriptableObjects/NarrationDay3", order = 1)]
public class NarrationDay3 : NarrationScriptableObjectTemplate
{
    // Start is called before the first frame update
new void OnEnable()
    {
        Day1Narr = new NarrLine[]
        {
            new NarrLine("Are you sure about this?", "Roy", "Annoyed", "Birds-EnvironmentalAsset-Narration"),
new NarrLine("It’s just a library Roy, don’t stress so much", "MC", "", ""),
new NarrLine("I don’t get out much! My motors aren’t made for this amount of travel in one go. Since it was your idea to go, I feel like it’s only fair you carry me some of the way!", "Roy", "Tired", ""),
new NarrLine("Y’know we don’t have to talk during the entire walk, Roy", "MC", "", ""),
new NarrLine("How are we going to find the blueprints? I don’t have any recognition of them in my data base", "Roy", "Neutral", "background_day3_LibraryLobby"),
new NarrLine("The blueprints are in an exclusive part of the library, not everyone has access to them", "MC", "", ""),
new NarrLine("Am I gonna have to watch you fumble around this place for hours then?", "Roy", "Annoyed", ""),
new NarrLine("I had access to them before but the librarians would always just ask for the call number and bring them to the front when we needed them, so I never physically saw where they place them.", "MC", "", ""),
new NarrLine("Oh nice, I guess we’ll just call up someone to help us. While we’re at it we can just invite a whole party of your friends, oh wait.", "Roy", "Annoyed", "background_day3_Library"),
new NarrLine("I remember at least that it should be in the most secure room in this building, they keep plans from some of the most valuable and historic machines in the whole state in there to preserve them", "MC", "", ""),
new NarrLine("Lucky for you, you have a state of the art robot gracing you with his expertise. I can find the directions to the most guarded room in this building with my scanning", "Roy", "Neutral", ""),
new NarrLine("Lead the way, meatbag", "Roy", "Annoyed", "")
        };
    }
}
