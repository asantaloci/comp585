using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewProcess : MonoBehaviour
{
    public InputField playerInputField;
    public Text playerInputText;
    public Text test;
    public Text dialogueText;

    private string playerName;

    private string wish;

    private string petName;

    private string action1;
    private string action2;
    private string action3;
    private string action4;
    private string action5;
    private string action6;
    private string action7;
    private string action8;
    private string action9;
    private string action10;
    private string action11;
    private string action12;
    private string action13;
    private string action14;
    private string action15;
    private string action16;

    private string obstacle1;
    private string obstacle2;
    private string obstacle3;
    private string obstacle4;
    private string obstacle5;
    private string obstacle6;
    private string obstacle7;
    private string obstacle8;

    private int actionstep = 0;
    private int obstaclestep = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nameInput()
    {

        if (!playerInputField.text.Equals(""))
        {
            playerName = playerInputField.text;
            //test.text = playerName;
            playerInputField.text = string.Empty;
        }


    }

    public void wishInput()
    {
        if (!playerInputField.text.Equals(""))
        {
            wish = playerInputField.text;
            //test.text = wish;
            playerInputField.text = string.Empty;
        }
    }

    public void petNameInput()
    {
        if (!playerInputField.text.Equals(""))
        {
            petName = playerInputField.text;
            //test.text = petName;
            playerInputField.text = string.Empty;
        }
    }

    public void actionInput()
    {

        switch(actionstep)
        {
            case 0:
                if (!playerInputField.text.Equals(""))
                {
                    action1 = playerInputField.text;
                    //test.text = action1;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 1:
                if (!playerInputField.text.Equals(""))
                {
                    action2 = playerInputField.text;
                    //test.text = action2;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 2:
                if (!playerInputField.text.Equals(""))
                {
                    action3 = playerInputField.text;
                    //test.text = action3;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 3:
                if (!playerInputField.text.Equals(""))
                {
                    action4 = playerInputField.text;
                    //test.text = action4;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 4:
                if (!playerInputField.text.Equals(""))
                {
                    action5 = playerInputField.text;
                    //test.text = action5;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 5:
                if (!playerInputField.text.Equals(""))
                {
                    action6 = playerInputField.text;
                    //test.text = action6;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 6:
                if (!playerInputField.text.Equals(""))
                {
                    action7 = playerInputField.text;
                    //test.text = action7;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 7:
                if (!playerInputField.text.Equals(""))
                {
                    action8 = playerInputField.text;
                    //test.text = action8;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 8:
                if (!playerInputField.text.Equals(""))
                {
                    action9 = playerInputField.text;
                    //test.text = action9;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 9:
                if (!playerInputField.text.Equals(""))
                {
                    action10 = playerInputField.text;
                    //test.text = action10;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 10:
                if (!playerInputField.text.Equals(""))
                {
                    action11 = playerInputField.text;
                    //test.text = action11;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 11:
                if (!playerInputField.text.Equals(""))
                {
                    action12 = playerInputField.text;
                    //test.text = action12;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 12:
                if (!playerInputField.text.Equals(""))
                {
                    action13 = playerInputField.text;
                    //test.text = action13;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 13:
                if (!playerInputField.text.Equals(""))
                {
                    action14 = playerInputField.text;
                    //test.text = action14;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 14:
                if (!playerInputField.text.Equals(""))
                {
                    action15 = playerInputField.text;
                    //test.text = action15;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 15:
                if (!playerInputField.text.Equals(""))
                {
                    action16 = playerInputField.text;
                    //test.text = action16;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

        }

    }

    public void obstacleInput()
    {
        switch (obstaclestep)
        {
            case 0:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle1 = playerInputField.text;
                    //test.text = obstacle1;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 1:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle2 = playerInputField.text;
                    //test.text = obstacle2;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 2:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle3 = playerInputField.text;
                    //test.text = obstacle3;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 3:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle4 = playerInputField.text;
                    //test.text = obstacle4;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 4:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle5 = playerInputField.text;
                    //test.text = obstacle5;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 5:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle6 = playerInputField.text;
                    //test.text = obstacle6;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 6:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle7 = playerInputField.text;
                    //test.text = obstacle7;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 7:
                if (!playerInputField.text.Equals(""))
                {
                    obstacle8 = playerInputField.text;
                    //test.text = obstacle8;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

        }
    }

    public void completeAdoption()
    {
        var user = new UserGenerator(wish, petName);
        string json = JsonUtility.ToJson(user);
        FireSaver.SavePlayer(playerName, json);


    }

}
