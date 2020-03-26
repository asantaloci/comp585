using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actions : MonoBehaviour
{
    float timer = 20;
    public GameObject walk;
    public GameObject play;
    public GameObject water;
    public GameObject feed;
    public Text selectedtext;


// void Update(){
//     Debug.Log(Time.deltaTime);
//  timer -= Time.deltaTime;
//  if(timer < 0)
//  {
//        Debug.Log("timer in!");
    
// //  actionItem();
//  timer = 20;
//    Debug.Log("out of action!");
        
//  }
//  }

    
   public void actionItem() {
Debug.Log(selectedtext.text.ToString()); // THIS IS IT!!
       if (selectedtext.text.ToString() == "Walk") {
           Debug.Log("walk!");
        walk.SetActive(true);
    }
    else if (selectedtext.text.ToString() == "Play") {
           Debug.Log("play!");
        play.SetActive(true);
    }
    else if (selectedtext.text.ToString() == "Water") {
           Debug.Log("water!");
        water.SetActive(true);
    }
    else if (selectedtext.text.ToString() == "Feed") {
           Debug.Log("feed!");
        feed.SetActive(true);
    }
    
   }


}
