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

    private string petType = "Cat";

    private string wish;

    private string petName;

    private string[] actions = new string[16];

    private string[] obstacles = new string[8];

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
                    actions[0] = playerInputField.text;
                    //test.text = action1;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 1:
                if (!playerInputField.text.Equals(""))
                {
                    actions[1] = playerInputField.text;
                    //test.text = action2;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 2:
                if (!playerInputField.text.Equals(""))
                {
                    actions[2] = playerInputField.text;
                    //test.text = action3;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 3:
                if (!playerInputField.text.Equals(""))
                {
                    actions[3] = playerInputField.text;
                    //test.text = action4;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 4:
                if (!playerInputField.text.Equals(""))
                {
                    actions[4] = playerInputField.text;
                    //test.text = action5;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 5:
                if (!playerInputField.text.Equals(""))
                {
                    actions[5] = playerInputField.text;
                    //test.text = action6;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 6:
                if (!playerInputField.text.Equals(""))
                {
                    actions[6] = playerInputField.text;
                    //test.text = action7;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 7:
                if (!playerInputField.text.Equals(""))
                {
                    actions[7] = playerInputField.text;
                    //test.text = action8;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 8:
                if (!playerInputField.text.Equals(""))
                {
                    actions[8] = playerInputField.text;
                    //test.text = action9;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 9:
                if (!playerInputField.text.Equals(""))
                {
                    actions[9] = playerInputField.text;
                    //test.text = action10;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 10:
                if (!playerInputField.text.Equals(""))
                {
                    actions[10] = playerInputField.text;
                    //test.text = action11;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 11:
                if (!playerInputField.text.Equals(""))
                {
                    actions[11] = playerInputField.text;
                    //test.text = action12;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 12:
                if (!playerInputField.text.Equals(""))
                {
                    actions[12] = playerInputField.text;
                    //test.text = action13;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 13:
                if (!playerInputField.text.Equals(""))
                {
                    actions[13] = playerInputField.text;
                    //test.text = action14;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 14:
                if (!playerInputField.text.Equals(""))
                {
                    actions[14] = playerInputField.text;
                    //test.text = action15;
                    playerInputField.text = string.Empty;
                    actionstep += 1;
                }
                break;

            case 15:
                if (!playerInputField.text.Equals(""))
                {
                    actions[15] = playerInputField.text;
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
                    obstacles[0] = playerInputField.text;
                    //test.text = obstacle1;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 1:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[1] = playerInputField.text;
                    //test.text = obstacle2;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 2:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[2] = playerInputField.text;
                    //test.text = obstacle3;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 3:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[3] = playerInputField.text;
                    //test.text = obstacle4;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 4:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[4] = playerInputField.text;
                    //test.text = obstacle5;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 5:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[5] = playerInputField.text;
                    //test.text = obstacle6;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 6:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[6] = playerInputField.text;
                    //test.text = obstacle7;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

            case 7:
                if (!playerInputField.text.Equals(""))
                {
                    obstacles[7] = playerInputField.text;
                    //test.text = obstacle8;
                    playerInputField.text = string.Empty;
                    obstaclestep++;
                }
                break;

        }
    }

    public void completeAdoption()
    {

        for (int i = 0; i < 16; i++)
        {
            if (string.IsNullOrEmpty(actions[i]))
            {
                actions[i] = "Unassigned";
            }
        }

        for (int j = 0; j < 8; j++)
        {
            if (string.IsNullOrEmpty(obstacles[j]))
            {
                obstacles[j] = "Unassigned";
            }
        }

/*        GameObject global = GameObject.Find("Global");
        GlobalVars globalVars = global.GetComponent<GlobalVars>();
        Debug.Log(globalVars.playerEmail);*/
        
        var user = new UserGenerator(petType, wish, petName, actions, obstacles);
        string json = JsonUtility.ToJson(user);
        FireSaver.SavePlayer(playerName, json);

    }

}
