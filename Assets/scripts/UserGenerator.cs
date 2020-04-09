using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UserGenerator
{


    // public string petType;
    
    //public string name;
    //public string wish;

    //public string[] currentPets;
    //public string[] formerPets;

    public string[] actions;
    // public Dictionary<string, object> actions;
    public string[] obstacles; 

    //public string email;

    // public string action1;
    // public string action2;
    // public string action3;
    // public string action4;
    // public string action5;
    // public string action6;
    // public string action7;
    // public string action8;
    // public string action9;
    // public string action10;
    // public string action11;
    // public string action12;
    // public string action13;
    // public string action14;
    // public string action15;
    // public string action16;

    // public string obstacle1;
    // public string obstacle2;
    // public string obstacle3;
    // public string obstacle4;
    // public string obstacle5;
    // public string obstacle6;
    // public string obstacle7;
    // public string obstacle8;

    public UserGenerator() {

        //this.name = "";
         // this.petType = petType;
        //this.wish = "";
        // this.petName = petName;

        Dictionary<string, object> act = new Dictionary<string, object>();

        this.actions = new string[1]; //act
        this.obstacles = new string[1];

        //this.currentPets = new string[1];
        //this.formerPets = new string[1];
    }

    // public UserGenerator(string petType, string wish, string petName, string[] actions, string[] obstacles)
    public UserGenerator(string[] actions, string[] obstacles)
    {

        //this.name = name;
        // this.petType = petType;
        //this.wish = wish;
        // this.petName = petName;

        string[] petActs = new string[] { "water", "feed", "walk", "pet", "groom", "bath", "six", "seven", "eight", "nine", "ten", "eleven", "thirteen", "fourteen", "fifteen", "sixteen" };

        Dictionary<string, object> act = new Dictionary<string, object>();
        // string timeStamp = GetTimestamp(new DateTime());
        DateTime now = DateTime.Now;
        string timeStamp = now.ToString();


        // final: ' "actions": ["water": ["habit": "jogging", "healvalue": "1", "hurtvalue": "1", "lastcared": "timestamp", "timeframe": "6" ], "feed": ["habit": "eating healthy", "healvalue": "1", "hurtvalue": "1", "lastcared": "timestamp", "timeframe": "6" ]], "obstacles":["laziness", "money"] '
        for (int i = 0; i < actions.Length; i++) {
            HabitObject habitObj = new HabitObject(actions[i], 1, 1, timeStamp, 6);
            // string temp = JsonUtility.ToJson(habitObj);
            // temp["habit"] = actions[i];
            // temp["healValue"] = 1;
            // temp["hurtValue"] = 1;
            // temp["lastCared"] = timeStamp;
            // temp["timeFrame"] = 6;
            
            act[petActs[i]] = habitObj;
        }

        
        this.actions = actions;
        this.obstacles = obstacles;

        //this.currentPets = new string[0];
        //this.formerPets = new string[0];

       // this.email = email;

    }

    public Dictionary<string, object> getDictionary(){
        
        string[] petActs = new string[] { "water", "feed", "walk", "pet", "groom", "bath", "six", "seven", "eight", "nine", "ten", "eleven", "thirteen", "fourteen", "fifteen", "sixteen" };
        
        DateTime now = DateTime.Now;
        string timeStamp = now.ToString();
        
        Dictionary<string, object> mainJson = new Dictionary<string, object>();
        Dictionary<string, object> acts = new Dictionary<string, object>();

        for(int i = 0; i < this.actions.Length; i++) {
            Dictionary<string, object> temp = new Dictionary<string, object>() {
                {"habit", actions[i]},
                {"healvalue", 1},
                {"hurtvalue", 1},
                {"lastcared", timeStamp},
                {"timeframe", 6}
            };

            acts[petActs[i]] = temp;
        }

        mainJson["actions"] = acts;
        mainJson["obstacles"] = this.obstacles;

        return mainJson;


    }

    //public void addAction(string action)
    //{

    //}

    //public void addObstacle(string obstacle)
    //{

    //}

}
