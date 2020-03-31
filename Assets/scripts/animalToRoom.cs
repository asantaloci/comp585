using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Firebase.Auth;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;

public class animalToRoom : MonoBehaviour
    {
// if it is a certain animal, change the selected animal to that animal!!!!

        public Animal chosenpet;
        public GameObject blackcat;
        public GameObject cat;
        public string userID;

        // void Start() {if (FirebaseAuth.DefaultInstance.CurrentUser == null)
        // {
        //     this.userID = "default";
          
        //     // this.userEmail = "";
        // }

        // else
        // {
        //     this.userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        //     Debug.Log("please work" + FireSaver.GetPetType(userID));
        // }
        //     Debug.Log(FireSaver.GetPetType(userID)+ "god help me");
        //     Debug.Log(chosenpet.animalType);

        //       Debug.Log("please work" + FireSaver.GetPetType(userID));
        //       Debug.Log(FireSaver.GetPetType(userID)+ "god help me");
        //     Debug.Log(chosenpet.animalType);
        // }
         public void selectToRoom() {
Debug.Log(FireSaver.GetPetType(userID)+ "god help me");
             Debug.Log(chosenpet.animalType);


     if (chosenpet.animalType == "Cat") {
Debug.Log("animal type is cat");
blackcat.SetActive(false);
cat.SetActive(true);


     } else {
         Debug.Log("black cat");
         cat.SetActive(false);
         blackcat.SetActive(true);
     }
     
     
     }
//      void Start() {
//               if (selectedAnimalType == "Cat") {
// Debug.Log("animal type is cat");
// blackcat.SetActive(false);
// cat.SetActive(true);


//      } else {
//          Debug.Log("black cat");
//          cat.SetActive(false);
//          blackcat.SetActive(true);
//      }
//      }
    }
