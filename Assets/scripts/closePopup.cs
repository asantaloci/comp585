using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class closePopup : MonoBehaviour
{
    public TextMesh selectedtext;
    public TextMesh animaltype;
    public TextMesh animalselection;
    public TextMesh output;
    public GameObject popup;
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
        animalselection.text = "You chose"+animaltype+"";
        print("You chose"+animaltype+"");

        // Text txt = transform.Find("Text").GetComponent<Text>();
        // if (selectedtext.enabled) {
        //     print("pressed");
        //     popup.SetActive(false);
        // }
    }

}
 
