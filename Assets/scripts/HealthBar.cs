using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Database;

public class HealthBar : MonoBehaviour
{
    public Slider sliderBlackCat;
    public Slider sliderCat;
    public Slider sliderShiba;

    private string userID;
    private string currentPet;
    private string petType;

    private int neglectdamage;
 //   private int neglectpacer = 0;
 //   private int updatepacer = 995;

    private List<DataSnapshot> chosenCares = new List<DataSnapshot>();

//    private int careCounter = 1;

    public Action<int> callback;
    public Action<string> petnamecallback;
    public Action<string> pettypecallback;
    public Action<DataSnapshot> carecallback;
    public Action<bool> damagecallback;

    private int MaxHealth = 100;

    private int valBlackCat = -1;
    private int valCat = -1;
    private int valShiba = -1;

    public Image FillBlackCat;  // assign in the editor the "Fill"
    public Image FillCat;  // assign in the editor the "Fill"
    public Image FillShiba;
    public Color healthcolor;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;

    private void Awake()
    {
        Debug.Log("Awake");
        callback = SetHealth;
        petnamecallback = SetCurrentPet;
        pettypecallback = SetPetType;
        carecallback = AddChosenCare;
        damagecallback = HandleDamage;
        userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        //FillBlackCat = GameObject.Find("BackgroundBCBar").GetComponent<Image>();
        //FillCat = GameObject.Find("BackgroundCBar").GetComponent<Image>();
        //sliderBlackCat = (Slider) GameObject.FindGameObjectWithTag("blackcathealthbar").GetComponent<Slider>();
        //sliderCat = GameObject.Find("healthBarC").GetComponent<Slider>();
    }

    private void Start()
    {
        Debug.Log("Start");
        RequestPetName();
       //this.sliderBlackCat.value = 100 - 30;
    }

    private void Update()
    {
        if (petType == "blackCat")
        {
            this.sliderBlackCat.value = (float)100 - valBlackCat;
            this.FillBlackCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valBlackCat / MaxHealth);
        }
        if (petType == "Cat")
        {
            this.sliderCat.value = (float)100 - valCat;
            this.FillBlackCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valCat / MaxHealth);
        }
        if (petType == "shiba")
        {
            this.sliderShiba.value = (float)100 - valShiba;
            this.FillShiba.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valShiba / MaxHealth);
        }
        }

    public void UpdateHealthBar()
    {
        Debug.Log("Update");

        if (petType == "Cat")
        {
            //FillCat = GameObject.Find("BackgroundCBar").GetComponent<Image>();
            //sliderCat = GameObject.Find("healthBarC").GetComponent<Slider>();
            //this.FillCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valCat / MaxHealth);
            //this.sliderCat.value = 100 - valCat;

        }

        if (petType == "blackCat")
        {
            //Debug.Log(valBlackCat);
            //this.FillBlackCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valBlackCat / MaxHealth);
            //this.sliderBlackCat.value = (float) 100 - valBlackCat;
            //Debug.Log(this.sliderBlackCat.value);
            //Debug.Log("Rollin");


        }
    }

    public void MeasureNeglectDamage()
    {
        Debug.Log("Measure Neglect");
        chosenCares.ForEach(MeasureTiming);
        if (neglectdamage != 0)
        {
            TakeNeglectDamage(neglectdamage);
            neglectdamage = 0;
        }

    }


// The Following Functions Make Requests from the Firebase Database

    public void RequestPetName()
    {
        Debug.Log("Request Name");
        FireSaver.GetCurrentPet(petnamecallback, userID);
    }

    public void RequestPetType()
    {
        Debug.Log("Request Type");
        FireSaver.GetPetType(pettypecallback, userID, currentPet);
    }

    public void RequestChosenCares()
    {
        Debug.Log("Request Cares");
        FireSaver.GetPetCares(carecallback, userID, currentPet);
    }


// The Following Functions Are Callbacks Along with the Firebase Requests

    public void SetHealth(int healthvalue)
    {
        Debug.Log(healthvalue);
        if (petType == "Cat")
        {
            valCat = healthvalue;
        }
        if (petType == "blackCat")
        {
            valBlackCat = healthvalue;
        }
        if (petType == "shiba")
        {
            valShiba = healthvalue;
        }

        UpdateHealthBar();
    }

    public void SetCurrentPet(string petname)
    {
        Debug.Log("Set Name" + petname);
        currentPet = petname;
        RequestPetType();
    }

    public void SetPetType(string animaltype)
    {
        Debug.Log("Set Type" + animaltype);
        petType = animaltype;
        RequestChosenCares();
    }

    public void AddChosenCare(DataSnapshot care)
    {
        Debug.Log("Add Chosen Care");
        foreach (DataSnapshot element in care.Children)
        {
            chosenCares.Add(element);
        }
        FireSaver.GetPetHealth(callback, currentPet, userID);
        MeasureNeglectDamage();
    }

    public void HandleDamage(bool variable)
    {
        Debug.Log("Death Knell");
        FireSaver.GetPetHealth(callback, currentPet, userID);
    }

    public void MeasureTiming(DataSnapshot care) 
    {
        Debug.Log("Measure Timing");
        DateTime time = DateTime.Parse(care.Child("lastcared").Value.ToString());

            TimeSpan diff = time.Subtract(DateTime.Now);

            int timeframe = int.Parse(care.Child("timeframe").Value.ToString());

        Debug.Log("Time is " + time);
        Debug.Log("Now is " + DateTime.Now);
        Debug.Log("Difference is " + diff.TotalSeconds);

        if (timeframe == 1)
            {
                if (diff.TotalSeconds < (-3600 * 24))
                {

                //TakeNeglectDamage(care);
                neglectdamage += int.Parse(care.Child("hurtvalue").Value.ToString());
                    FireSaver.SetLastCare(userID, currentPet, care);
                }

            }
            else if (timeframe == 2)
            {
                if (diff.Seconds < (-3600 * 12))
                {
//                    TakeNeglectDamage(chosenCares[careCounter]);
                }
            }
            else if (timeframe == 3)
            {
                if (diff.Seconds < (-3600 * 6))
                {
//                    TakeNeglectDamage(chosenCares[careCounter]);
                }
            }
            else
            {
                if (diff.TotalSeconds < (-3600 / 36)) // Test Timeframe
                {
                    neglectdamage += int.Parse(care.Child("hurtvalue").Value.ToString());
                    FireSaver.SetLastCare(userID, currentPet, care);
            }
            }
        
    }

    public void TakeNeglectDamage(int damage) 
    {
        Debug.Log("Take Damage");
        FireSaver.HurtPet(userID, currentPet, damage, damagecallback);
        
    }

    public void CareForPet()
    {
        Debug.Log("Heal");
        FireSaver.HealPet(userID, currentPet, damagecallback);

    }

}
