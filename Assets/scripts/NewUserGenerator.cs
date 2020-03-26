using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUserGenerator
{
    public string name;
    public string wish;
    public string email;

    public string[] currentPets;
    public string[] formerPets;

    public string activePet;


    public NewUserGenerator() {

        this.name = "";
        this.wish = "";
        this.email = "";

    }

    // public UserGenerator(string petType, string wish, string petName, string[] actions, string[] obstacles)
    public NewUserGenerator(string name, string wish, string email)
    {

        this.name = name;
        this.wish = wish;
        this.email = email;

        this.currentPets = new string[1];
        this.formerPets = new string[1];

    }

}
