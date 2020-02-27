using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class animalToRoom : MonoBehaviour
    {
// if it is a certain animal, change the selected animal to that animal!!!!

        public Animal chosenpet;
        public GameObject blackcat;
        public GameObject cat;
        

        
         public void selectToRoom() {

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
    }
