using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class closePopup : MonoBehaviour
{
    public TextMesh selectedtext;
    public string animaltype; // i changed this
    public TextMesh animalselection;
    
    public Text output;
     public static string selectedAnimalType;
    public GameObject popup;
    public GameObject animal;

      public Animal chosenpet;
               
        public Animal selected;
    // Start is called before the first frame update


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


        if (selected.animalType == "Cat") { // if the animal that was selected's type is cat
             chosenpet.animalType = "Cat";   //set the chosen pet object to that 
             chosenpet.health = 20;
             selectedAnimalType = "Cat";
             chosenpet.animalName = "Poopy";
            output.text = "You chose: " + chosenpet.animalType;
             Debug.Log("animaltype of chosen = " + chosenpet.animalType);
        }else 
          if (selected.animalType == "blackCat") { // if the animal that was selected's type is cat
          Debug.Log(selected.animalType);
          
          chosenpet.animalType = selected.animalType;
             chosenpet.animaltype = selected.animaltype;   //set the chosen pet object to that 
             Debug.Log(chosenpet.animaltype);
             chosenpet.health = selected.health;
             selectedAnimalType = "blackCat";
             chosenpet.animalName = selected.animalName;
             output.text = "You chose: " + chosenpet.animalType;

             Debug.Log("animaltype of chosen = " + chosenpet.animalType);
        }

        // Text txt = transform.Find("Text").GetComponent<Text>();
        // if (selectedtext.enabled) {
        //     print("pressed");
        //     popup.SetActive(false);
        // }
        
    }

}
 
 
