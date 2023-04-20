using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Reference to user interface
using System.IO;
public class NarrSceneV2 : MonoBehaviour
{
    public NarrationScriptableObjectTemplate template;
    public int currLine = 0;
    public Text narrationBox;
    public Text speakerName;
    public Image backgroundImg;
    public Image speakerImg;
    public string MinigameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        narrationBox.text = template.Day1Narr[currLine].text;
        speakerName.text = template.Day1Narr[currLine].narrator;
        if (template.Day1Narr[currLine].narrImg != null)
        {
            speakerImg.sprite = template.Day1Narr[currLine].narrImg;
        }
        if (template.Day1Narr[currLine].backImg != null)
        {
            backgroundImg.sprite = template.Day1Narr[currLine].backImg;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLine()
    {
        if (currLine < template.Day1Narr.Length-1)
        {
            currLine++;
            narrationBox.text = template.Day1Narr[currLine].text;
            speakerName.text = template.Day1Narr[currLine].narrator;
            if (template.Day1Narr[currLine].narrImg != null)
            {
                Debug.Log("testc");
                speakerImg.sprite = template.Day1Narr[currLine].narrImg;
            }
            if (template.Day1Narr[currLine].backImg != null)
            {
                backgroundImg.sprite = template.Day1Narr[currLine].backImg;
            }
        } else
        {
            SceneManager.LoadScene(MinigameSceneName);
        }
    }
}
