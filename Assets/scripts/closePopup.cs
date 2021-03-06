﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Firebase.Auth;


public class closePopup : MonoBehaviour
{
    public TextMesh selectedtext;
    public string animalType; // i changed this
    public TextMesh animalselection;

    public Text output;
    public static string selectedAnimalType;
    public GameObject popup;
    public GameObject animal;

    public Animal chosenpet;

    public Animal selected;
    // Start is called before the first frame update

    public string userID;

    void Start()
    {
        if (FirebaseAuth.DefaultInstance.CurrentUser == null)
        {
            this.userID = "default";
            // this.userEmail = "";
        }
        else
        {
            this.userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
            // this.userEmail = FirebaseAuth.DefaultInstance.CurrentUser.Email;
        }
        
    }
    public void close()
    {
        popup.SetActive(false);

        // Text txt = transform.Find("Text").GetComponent<Text>();
        // if (selectedtext.enabled) {
        //     print("pressed");
        //     popup.SetActive(false);
        // }
    }
    public void selectanimal()
    {
        popup.SetActive(false);
        // animalselection.text = "You chose"+animaltype+"";
        // print("You chose"+animaltype+"");
        // print(animalselection.text);


        if (selected.animalType == "Cat")
        { // if the animal that was selected's type is cat
            chosenpet.animalType = "Cat";   //set the chosen pet object to that 
            chosenpet.health = 100;
            selectedAnimalType = "Cat";
            chosenpet.animalName = "Cat";
            output.text = "You chose: " + chosenpet.animalType;
            string json = JsonUtility.ToJson(chosenpet);
            FireSaver.AddPet(userID, chosenpet.animalName, json);
            
            //  Debug.Log("animaltype of chosen = " + chosenpet.animalType);
        }
        else
          if (selected.animalType == "blackCat")
        { // if the animal that was selected's type is cat
          //   Debug.Log(selected.animalType);
            chosenpet.animalType = selected.animalType;   //set the chosen pet object to that 
                                                          //  Debug.Log(chosenpet.animalType);
            chosenpet.health = 100;
            selectedAnimalType = "blackCat";
            chosenpet.animalName = selected.animalName;
            output.text = "You chose: " + chosenpet.animalType;
            string json = JsonUtility.ToJson(chosenpet);
            FireSaver.AddPet(userID, chosenpet.animalName, json);

            //  Debug.Log("animaltype of chosen = " + chosenpet.animalType);
        }
          else
          if (selected.animalType == "shiba")
        { // if the animal that was selected's type is cat
          //   Debug.Log(selected.animalType);
            chosenpet.animalType = selected.animalType;   //set the chosen pet object to that 
                                                          //  Debug.Log(chosenpet.animalType);
            chosenpet.health = 100;
            selectedAnimalType = "shiba";
            chosenpet.animalName = selected.animalName;
            output.text = "You chose: " + chosenpet.animalType;
            string json = JsonUtility.ToJson(chosenpet);
            FireSaver.AddPet(userID, chosenpet.animalName, json);

            //  Debug.Log("animaltype of chosen = " + chosenpet.animalType);
        }

        // Text txt = transform.Find("Text").GetComponent<Text>();
        // if (selectedtext.enabled) {
        //     print("pressed");
        //     popup.SetActive(false);
        // }

    }

}


