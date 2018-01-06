﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Ink.Runtime;
using System.Collections.Generic;

public class BasicInkExample : MonoBehaviour {
	[SerializeField]
	private TextAsset inkJSONAsset;
	private Story story;

	[SerializeField]
	private Canvas canvas;

	// UI Prefabs
	[SerializeField]
	private Text textPrefab;
	[SerializeField]
	private Button buttonPrefab;


    //Added Vars
    bool keyDown = false;

    //Camera for testing positions
    Camera cam;

    //Transform
    Transform target;

    private void Start()
    {
        StartStory();
    }
    void Awake () {

       // StartStory();
	}


	void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}

    /**
     * test code for keydown selection
     **/
    void Update()
    {
        if(!Input.anyKey)
        {
            keyDown = false;
        }
        List<Choice> choices = story.currentChoices;
        for(int i = 0; i < story.currentChoices.Count; i++)
        {
            string key = (i+1).ToString();
            if(Input.GetKeyDown(key) && !keyDown)
            {
                OnClickChoiceButton(story.currentChoices[i]);
                keyDown = true;
            }
        }
    }
    /**
     * end of test
     **/
     
        
         
	void RefreshView () {
		RemoveChildren ();

		while (story.canContinue) {
			string text = story.Continue ().Trim();
			CreateContentView(text);
		}

		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				button.onClick.AddListener (delegate {
                    Debug.Log("! button clicked"
                                                );
					OnClickChoiceButton (choice);
				});
			}
		} else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	void CreateContentView (string text) {
        cam = Camera.main;

        if(cam != null)
            Debug.Log("Camera Loaded");

        Text storyText = Instantiate (textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent (canvas.transform, false);
        target = storyText.transform;
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log("Position of text is: " + screenPos.x + ", " + screenPos.y +", " + screenPos.z);
	}

	Button CreateChoiceView (string text) {
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (canvas.transform, false);

		Text choiceText = choice.GetComponentInChildren<Text> ();
		choiceText.text = text;

		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

        cam = Camera.main;

        Vector3 screenPos = cam.WorldToScreenPoint(choiceText.transform.position);
        Debug.Log("Position of button "+ " " + " is: " + screenPos.x + ", " + screenPos.y + ", " + screenPos.z);

        return choice;
	}

	void RemoveChildren () {
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
		}
	}
}
