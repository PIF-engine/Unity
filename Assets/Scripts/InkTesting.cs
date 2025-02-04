﻿using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkTesting : MonoBehaviour {

    //[SerializeField]
    public TextAsset storyJSON;
    private Story story;

    public GameObject TargetTMPDisplayPrefab;
    private TMPDisplayer targetDisplay;

    private bool waitForChoice;

    // Use this for initialization
    void Start () {

        targetDisplay = TargetTMPDisplayPrefab.GetComponent<TMPDisplayer>();

        waitForChoice = false;

       // m_Text = canvas.GetComponentInChildren<TextMeshProUGUI>(); 
        StartStory();
        
	}
	
	// Update is called once per frame
	void Update () {
        bool clear = false;
        bool advance = false;

        if (Input.GetKeyDown("1"))
        {
            if(story.currentChoices.Count >= 1)
            {
                MakeChoice(0);
                clear = true;
                advance = true;
            }
        } else if (Input.GetKeyDown("2"))
        {
            if (story.currentChoices.Count >= 2)
            {
                MakeChoice(1);
                clear = true;
                advance = true;
            }
        } else if (Input.GetKeyDown("3"))
        {
            if (story.currentChoices.Count >= 3)
            {
                MakeChoice(2);
                clear = true;
                advance = true;
            }
        } else if (Input.GetKeyDown("space"))
        {
            advance = true;
        }

        if(clear)
        {
            targetDisplay.RemoveText();
        }
        if (advance)
        {
            AdvanceStory();
        }


    }


    void StartStory()
    {
        story = new Story(storyJSON.text);
        AdvanceStory();
    }


    void AdvanceStory()
    {
        if (story.canContinue)
        {
            string text = story.Continue().Trim();
            targetDisplay.CreateText(text);
            //Debug.Log(text);
            targetDisplay.NewLine();
            return;
        } else if (story.currentChoices.Count > 0 && !waitForChoice)
        {
            waitForChoice = true;
            targetDisplay.logging = false;
            for(int i = 0; i < story.currentChoices.Count; i++)
            {
                string ct = story.currentChoices[i].text.Trim();
                //Debug.Log(ct);
                targetDisplay.NewLine();
                targetDisplay.CreateText(ct);
            }
            targetDisplay.logging = true;
        }
    
    }

    void MakeChoice(int i)
    {
        story.ChooseChoiceIndex(i);
        targetDisplay.storyChoiceLog += "->" + i;
        waitForChoice = false;
    }


}
