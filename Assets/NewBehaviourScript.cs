using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AddlogIn()
    {
        Application.LoadLevel("logIn");
    }
    public void AddRoom()
    {
        Application.LoadLevel("room");
        
    }
    public void ADDSetting()
    {
        Application.LoadLevel("setting");
    }
    public void AddStore()
    {
        
              Application.LoadLevel("store");
    }
    public void adoptionselection()
    {
        Application.LoadLevel("adoptionselection"); 
    }
    public void ADDadoptioniInterview()
    {
        Application.LoadLevel("adoption-interview");
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
