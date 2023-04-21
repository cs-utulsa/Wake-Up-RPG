using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NarrationD2", menuName = "ScriptableObjects/NarrationDay2", order = 1)]
public class NarrationDay2 : NarrationScriptableObjectTemplate
{
    // Start is called before the first frame update
    new void OnEnable()
    {
        Day1Narr = new NarrLine[] {
        new NarrLine( "Okay, maybe my mom was right and I shouldn’t have depended on GPS all the time, where am I?","NULL", "", "03-CrossRoads-Module2"),

        new NarrLine( "The arcade should be open 24/7 which will prevent me needing to commit breaking and entering thankfully. A classmate did their final project on refurbishing an arcade games and robot attendants. Smart jerk, definitely cooler than me and my roommate charming a busted pocket watch. Maybe they left some other tools I don’t have.", "NULL", "", ""),

        new NarrLine( "If I were a worse person, I would steal that giant stuffed panda. Me and my roommate could never get enough tickets for it in all our years of coming here.", "NULL", "", "02-Arcade-Module2"),

        new NarrLine( "Okay, focus! Not like I know exactly what I’m looking for but hopefully something will help", "NULL", "", ""),

        new NarrLine( "Hello", "Roy", "Neutral", ""),

        new NarrLine( "GAHHHHHH!!!", "MC", "",""),

        new NarrLine( "Disappointed? Expecting a super model to be making change?" , "Roy", "Annoyed", "01-Arcade-Module2"),

        new NarrLine( "Even after all my years of university, it still amazed me the feats that technology and magic can accomplish. Imagine a robot sentient enough to look this bored.", "NULL", "",""),

        new NarrLine( "Are you just going to look at me or you want to say something?", "Roy", "Annoyed", ""),

        new NarrLine( "Oh, I’m sorry, where are my manners", "MC", ""," "),

        new NarrLine( "No need to be rude to the little guy. Would using please and thank you be appropriate in this situation?", "NULL", "", ""),

        new NarrLine( "Not here obviously, what happened here?", "Roy", "Neutral", ""),

        new NarrLine( "He’s confused? I’m freaking confused", "NULL", "",""),

        new NarrLine( "I don’t really know, everyone is just…", "MC", "", ""),

        new NarrLine( "Frozen, I can feel their heart bits but they are so slow… Yours is just annoying", "Roy", "Pleased", ""),

        new NarrLine( "Um, thanks", "MC", "", ""),

        new NarrLine( "This robot is getting on my nerves", "NULL", "", ""),

        new NarrLine( "Why are you awake?", "Roy", "Annoyed", ""),

        new NarrLine( "The kind of magic used for this… phenomenon only affects living creatures and static objects. Some magical technology, like me and some of the newer games we have, are still functional", "MC", "", "02-Arcade-Module2-with-stuff-png"),

        new NarrLine( "I sense another type of technology functioning inside this room, I think it comes from inside of the claw machine", "Roy", "Alert","" ),

        new NarrLine( "It shouldn’t be that hard to get one, after all, I have done it a million times.", "NULL", "","IMG_1517"),
        };
    }


}
