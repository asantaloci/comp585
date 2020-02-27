using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    
    public class Animal : MonoBehaviour
    {
        
        public TextMesh animaltype;
        public string animalName;
        public string animalType; //to assign correct image

        public int health;


    public void getType() {
        if (animalType.ToString() =="Cat") {
            Debug.Log("This is a cat");
            // animalType = "Cat";
            Debug.Log(animalName);
            Debug.Log(animalType);

            // return "Cat";

        } 
        else if (animalType.ToString() =="blackCat") {
            Debug.Log("This is a black cat");
            // animalType = "Cat";
            Debug.Log(animalName);
            Debug.Log(animalType);
            
            // return "Cat";

        } else {
            Debug.Log("not a cat");
            // return "Not";
        }
    }
     

     void Update() {
        //  getType();
        //  Debug.Log(""+getType());
     }
        
    }


