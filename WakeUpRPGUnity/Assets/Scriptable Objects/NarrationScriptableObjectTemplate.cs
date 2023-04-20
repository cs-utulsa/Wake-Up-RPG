using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEditor;
using static UnityEditor.PlayerSettings;
using JetBrains.Annotations;

[CreateAssetMenu(fileName = "Narration" , menuName = "ScriptableObjects/NarrationScriptableObjectTemplate", order = 1)]
public class NarrationScriptableObjectTemplate : ScriptableObject
{
    [SerializeField]
    public struct NarrLine {
        public string text;
        public string narrator;
        public Sprite narrImg;
        public Sprite backImg;

        public NarrLine(string txt, string narr, string narrImg, string backImg)
        {
            Debug.Log("pop!");
            this.text = txt;
            this.narrator = narr;
            this.narrImg = Resources.Load<Sprite>("NarrImgs/portait-"+narr+"-"+narrImg);
            this.backImg = Resources.Load<Sprite>("NarrImgs/" +backImg);
            if(this.backImg != null)
            {
                Debug.Log("bubble");
            }
        }
    }
    public struct NarrImg
    {
        Texture2D img;
        string name;

        public NarrImg(string assetPath, int type)
        { if (type == 0)
            {
                img = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/NarrImgs/" + assetPath, typeof(Texture2D));
                name = assetPath;
            }
            else
            {
                img = (Texture2D)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture2D));
                name = assetPath.Substring(assetPath.LastIndexOf('/') + 1);
            }
        }
    }

    public NarrLine[] Day1Narr;
    public NarrLine[] Day1PostGame;
    public void OnEnable()
        {



        Day1Narr = new NarrLine[] {
            new NarrLine("Over the past 5 days, the world has been frozen in time...", "NULL", "", "Birds-EnviromentalAsset-Narration"),
            new NarrLine("the beloved arcade, not a lot of activity after it was closed for repairs", "NULL", "", "Arcade-EnvironmentalAsset-Narration"),
            new NarrLine("Basically a junkyard with how littered it is with mechanical parts", " NULL ", "", "Field-EnvironmentalAsset-Narration"),
            new NarrLine("Spooky and unknown but always could find something interesting there", " NULL ", "", ""),
            new NarrLine("A hub for architectural designs", " NULL ", "", ""),
            new NarrLine("even animals are frozen in this new world", " NULL ", "", "Forest-EnvironmentalAsset-Narration"),
            new NarrLine("Seems like a living nightmare", " NULL ", "", ""),
            new NarrLine("The world has seen magical items and technology integrated into the background of a typical human experience, but now all that technology is frozen. So we have to go on foot now, have fun walking!", " NULL ", "", "Car-EnvironmentalAsset-Narration"),
            new NarrLine("When my professor introduced us to the art of Pompeii, I couldn’t get it out of my head what those people must have felt. I imagine screaming, praying, crying before the world as they knew it was engulfed.", "MC", "", "WindowDesk-Environmental-Narration"),
            new NarrLine("I’ve never been much of a history person. Couldn’t get the dates and names in my head straight for the life of me. Mostly that story is what could keep me awake enough at 8 am to pass that class.", "MC", " ", ""),
            new NarrLine("Ironic that the ash that doomed them also kept their art and houses pristine enough for us to study. At least in my normal engineering classes I can mash numbers together instead of grappling with that stuff before I eat breakfast.", "MC", "", "Neighborhood-EnvironmentalAsset-Narration"),
            new NarrLine("But now that I’m in it, what do I do?", "MC", "", ""),
            new NarrLine("Five days in and honestly, it’s a little embarrassing how little I know. I definitely panicked the first few days. Plus, its hard to keep track of how long it’s even been besides when I start to feel tired.", "MC", "", ""),
            new NarrLine("The sun at least moves while I’m awake so at least what’s going on is contained to earth. At first it almost felt like some weird time loop.", "MC", "", " Crack-Environmental-Narration "),
            new NarrLine("Not my finest moment when I threw the vase at the wall to test that but at least it killed that idea when I woke up to the shards still there. Gotta apologize to my roommate for that one when this all gets fixed. If it gets fixed. Hah", "MC", "", "Birds-EnvironmentalAsset-Narration"),
            new NarrLine("No one seems like they are immune to the time freeze except me, not even the animals outside. The only thing that’s still ticking, funny enough, is my project. Pulling an all-nighter trying to get this pocket watch fixed and emerging from my room to find the world pretty much ended was a lot. What the hell is my life? I’m not even done with this stupid watch.", "MC", "", "Books-EnvironmentalAsset-Narration"),
            new NarrLine("I know about magic a decent amount. After all, I’ve been grinding away at a degree in magical engineering for four years but something like this would stop even my toughest professors in their tracks", "MC", "", ""),
            new NarrLine("So pretty much magic is a pretty common force in this world. Its more of a feature that is integrated into some technologies. It used to be a whole lot rarer but people in my field have really been trying to revive it.", "MC", "", "Flyer-EnviromentalAsset-Narration"),
            new NarrLine("Building a self-refilling water bottle seems like small potatoes compared to... whatever this is. Props to the person who caused all this, it sounds like they don’t need detailed blueprints for all their projects.", "MC", "", ""),
            new NarrLine("Would I have even known that the world froze if my internet didn’t go out?", "MC", "", " Calendar-Environmental-Narration"),
            new NarrLine("Not to sell myself short but I think I’ve been doing okay with handling things.", "MC", "", ""),
            new NarrLine("They always said that when you’re in big trouble, stay where you are so people can find and help you. I don’t think that applies here.", " MC ", "", "Library-EnvironmentalAsset-Narration_1"),
            new NarrLine("I need to live in the present as if there is any other option now and try to figure things out.", " MC ", "", ""),
            new NarrLine("If I don’t leave now, I never will.", " MC ", "", "")
        };



    Day1PostGame = new NarrLine[] {
        new NarrLine("Looks like I got everything!", " MC ", "", ""),
        new NarrLine("Welp, now or never I guess.", " MC ", "", ""),
        new NarrLine("Okay, I can feel myself losing my nerve already.", " MC ", "", ""),
        new NarrLine("It would’ve been nice to have [missing items] but I think it’s time.", " MC ", "", ""),
        new NarrLine("I need to see what's outside my apartment.", " MC ", "", "")
    };

    }

    
}
