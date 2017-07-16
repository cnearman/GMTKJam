using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamSelection : MonoBehaviour {

    public Text alertText;

    public Image[] playerOneChars = new Image[6];
    public Image[] playerTwoChars = new Image[6];

    public int p1CurrentSelection;
    public int p2CurrentSelection;

    public Image p1Selector;
    public Image p2Selector;

    public Image p1Selection1;
    public Image p1Selection2;
    public Image p1Selection3;

    public Image p2Selection1;
    public Image p2Selection2;
    public Image p2Selection3;

    public List<int> p1Selections = new List<int>();
    public List<int> p2Selections = new List<int>();

    bool weReady = false;
    public GameObject teamInfo;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(p1Selections.Count == 3 && p2Selections.Count == 3)
        {
            alertText.text = "Press 'Start' to fight it out!";
            weReady = true;
        }
	}

    void OnEnable()
    {
        EventManager.StartListening("CursorRight_" + 1, RightMove1);
        EventManager.StartListening("CursorLeft_" + 1, LeftMove1);

        EventManager.StartListening("Select_" + 1, Select1);

        EventManager.StartListening("CursorRight_" + 2, RightMove2);
        EventManager.StartListening("CursorLeft_" + 2, LeftMove2);

        EventManager.StartListening("Select_" + 2, Select2);

        EventManager.StartListening("Start_Pressed", BeginTheKilling);
    }

    void OnDisable()
    {
        EventManager.StopListening("CursorRight_" + 1, RightMove1);
        EventManager.StopListening("CursorLeft_" + 1, LeftMove1);

        EventManager.StopListening("Select_" + 1, Select1);

        EventManager.StopListening("CursorRight_" + 2, RightMove2);
        EventManager.StopListening("CursorLeft_" + 2, LeftMove2);

        EventManager.StopListening("Select_" + 2, Select2);

        EventManager.StopListening("Start_Pressed", BeginTheKilling);
    }

    void RightMove1(EventBody eb)
    {
        if(p1CurrentSelection < playerOneChars.Length - 1)
        {
            p1CurrentSelection += 1;
            p1Selector.rectTransform.localPosition = playerOneChars[p1CurrentSelection].rectTransform.localPosition;
        }
    }

    void RightMove2(EventBody eb)
    {
        if (p2CurrentSelection < playerTwoChars.Length - 1)
        {
            p2CurrentSelection += 1;
            p2Selector.rectTransform.localPosition = playerTwoChars[p2CurrentSelection].rectTransform.localPosition;
        }
    }

    void LeftMove1(EventBody eb)
    {
        if (p1CurrentSelection > 0)
        {
            p1CurrentSelection -= 1;
            p1Selector.rectTransform.localPosition = playerOneChars[p1CurrentSelection].rectTransform.localPosition;
        }
    }

    void LeftMove2(EventBody eb)
    {
        if (p2CurrentSelection > 0)
        {
            p2CurrentSelection -= 1;
            p2Selector.rectTransform.localPosition = playerTwoChars[p2CurrentSelection].rectTransform.localPosition;
        }
    }

    void Select1(EventBody eb)
    {
        if(!p1Selections.Contains(p1CurrentSelection) && p1Selections.Count < 3)
        {
            p1Selections.Add(p1CurrentSelection);

            if (p1Selections.Count == 1)
            {
                p1Selection1.rectTransform.localPosition = playerOneChars[p1CurrentSelection].rectTransform.localPosition;
            } else if (p1Selections.Count == 2)
            {
                p1Selection2.rectTransform.localPosition = playerOneChars[p1CurrentSelection].rectTransform.localPosition;
            } else if (p1Selections.Count == 3)
            {
                p1Selection3.rectTransform.localPosition = playerOneChars[p1CurrentSelection].rectTransform.localPosition;
            }
        }
    }

    void Select2(EventBody eb)
    {
        if (!p2Selections.Contains(p1CurrentSelection) && p2Selections.Count < 3)
        {
            p2Selections.Add(p2CurrentSelection);

            if (p2Selections.Count == 1)
            {
                p2Selection1.rectTransform.localPosition = playerTwoChars[p2CurrentSelection].rectTransform.localPosition;
            }
            else if (p2Selections.Count == 2)
            {
                p2Selection2.rectTransform.localPosition = playerTwoChars[p2CurrentSelection].rectTransform.localPosition;
            }
            else if (p2Selections.Count == 3)
            {
                p2Selection3.rectTransform.localPosition = playerTwoChars[p2CurrentSelection].rectTransform.localPosition;
            }
        }
    }

    void BeginTheKilling(EventBody eb)
    {
        if(weReady)
        {
            teamInfo.GetComponent<TeamInformation>().p1Selections = p1Selections;
            teamInfo.GetComponent<TeamInformation>().p2Selections = p2Selections;
            //lets begin...

            SceneManager.LoadScene("BackupLevelUI");
        }
    }
}
