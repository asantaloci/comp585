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

    private string userID;
    private string currentPet;
    private string petType;

    private bool neglectMeasured;
    private int neglectpacer = 0;
    private int updatepacer = 995;

    private List<DataSnapshot> chosenCares = new List<DataSnapshot>();

    private int careCounter = 1;

    public Action<int> callback;
    public Action<string> petnamecallback;
    public Action<string> pettypecallback;
    public Action<DataSnapshot> carecallback;
    public Action<bool> damagecallback;

    private int MaxHealth = 100;

    private int valBlackCat = -1;
    private int valCat = -1;

    public Image FillBlackCat;  // assign in the editor the "Fill"
    public Image FillCat;  // assign in the editor the "Fill"
    public Color healthcolor;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;

    private void Awake()
    {
 //       slider = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        callback = SetHealth;
        petnamecallback = SetCurrentPet;
        pettypecallback = SetPetType;
        carecallback = AddChosenCare;
        damagecallback = HandleDamage;
        neglectMeasured = false;
        userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        FillBlackCat = GameObject.Find("BackgroundBCBar").GetComponent<Image>();
        FillCat = GameObject.Find("BackgroundCBar").GetComponent<Image>();
        sliderBlackCat = GameObject.Find("healthBarBC").GetComponent<Slider>();
        sliderCat = GameObject.Find("healthBarC").GetComponent<Slider>();

    }

    private void Update()
    {
        // This block ensures that the current pet and the pet type are known, then calls UpdateHealthBar


        if (userID != null)
        {
            if (currentPet != null)
            {
                if (petType != null)
                {

                    if (petType == "blackCat" && valBlackCat != -1)
                    {
                        if (updatepacer > 1000)
                        {
                            UpdateHealthBar();
                            updatepacer = 0;

                            Debug.Log(chosenCares);
                        }
                        else
                        {
                            updatepacer++;
                            //Debug.Log(updatepacer);
                        }

                    }
                    else if (petType == "blackCat" && valBlackCat == -1)
                    {
                        FireSaver.GetPetHealth(callback, currentPet, userID);
                    }
                    if (petType == "Cat" && valCat != -1)
                    {
                        if (updatepacer > 1000)
                        {
                            UpdateHealthBar();
                            updatepacer = 0;
                        }
                        else
                        {
                            updatepacer++;
                        }
                    }
                    else if (petType == "Cat" && valBlackCat == -1)
                    {
                        FireSaver.GetPetHealth(callback, currentPet, userID);
                    }
                }
                else
                {
                    Debug.Log("Pet Type is Null");
                    RequestPetType();
                }
            }
            else
            {
                Debug.Log("current pet is Null");
                RequestPetName();
            }
        }

        // This block calls the timing system



        if (neglectpacer > 1000)
        {
            neglectpacer = 0;
            chosenCares.ForEach(MeasureTiming);
        }
        else
        {
            neglectpacer++;
        }

    }

    public void UpdateHealthBar()
    {
        FireSaver.GetPetHealth(callback, currentPet, userID);

        if (petType == "Cat")
        {
            FillCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valCat / MaxHealth);
            sliderCat.value = 100 - valCat;

        }

        if (petType == "blackCat")
        {
            
            FillBlackCat.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)valBlackCat / MaxHealth);
            sliderBlackCat.value = 100 - valBlackCat;
        }
    }

    public void MeasureNeglectDamage()
    {
        if (neglectMeasured == false)
        {
            if (chosenCares.Count == 0)
            {
                FireSaver.GetPetCares(carecallback, userID, currentPet);
            }

            else
            {
                neglectMeasured = true;
     //           MeasureTiming();
            }
        }

        else
        {
            neglectpacer += 1;
        }

        if (neglectpacer > 1000)
        {
            neglectpacer = 0;
            neglectMeasured = false;
        }
    }


// The Following Functions Make Requests from the Firebase Database

    public void RequestPetName()
    {
        FireSaver.GetCurrentPet(petnamecallback, userID);
    }

    public void RequestPetType()
    {
        FireSaver.GetPetType(pettypecallback, userID, currentPet);
    }

    public void RequestChosenCares()
    {
        FireSaver.GetPetCares(carecallback, userID, currentPet);
    }


// The Following Functions Are Callbacks Along with the Firebase Requests

    public void SetHealth(int healthvalue)
    {
        if (petType == "Cat")
        {
            valCat = healthvalue;
        }
        if (petType == "blackCat")
        {
            valBlackCat = healthvalue;
        }
    }

    public void SetCurrentPet(string petname)
    {
        currentPet = petname;
    }

    public void SetPetType(string animaltype)
    {
        petType = animaltype;
    }

    public void AddChosenCare(DataSnapshot care)
    {
        chosenCares.Add(care);
    }

    public void HandleDamage(bool variable)
    {
        Debug.Log("Death Knell");
        UpdateHealthBar();
  /*      careCounter += 1;
        if (careCounter <= chosenCares.Count)
        {
            MeasureTiming();
        }
        else
        {
            careCounter = 1;
        }*/
    }

    public void MeasureTiming(DataSnapshot care) 
    {

            DateTime time = DateTime.Parse(care.Child("lastcared").Value.ToString());

            TimeSpan diff = time.Subtract(DateTime.Now);

            int timeframe = int.Parse(care.Child("timeframe").Value.ToString());

            if (timeframe == 1)
            {
                if (diff.Seconds < (-3600 * 24))
                {
                    TakeNeglectDamage(care);
                    FireSaver.SetLastCare(userID, currentPet, care);
                }

            }
            else if (timeframe == 2)
            {
                if (diff.Seconds < (-3600 * 12))
                {
                    TakeNeglectDamage(chosenCares[careCounter]);
                }
            }
            else if (timeframe == 3)
            {
                if (diff.Seconds < (-3600 * 6))
                {
                    TakeNeglectDamage(chosenCares[careCounter]);
                }
            }
            else
            {
                if (diff.Seconds < (-3600 / 36)) // Test Timeframe
                {
                    TakeNeglectDamage(care);
                    FireSaver.SetLastCare(userID, currentPet, care);
                }
            }
        
    }

    public void TakeNeglectDamage(DataSnapshot care) 
    { 

            FireSaver.HurtPet(userID, currentPet, care, damagecallback);
        
    }
}
