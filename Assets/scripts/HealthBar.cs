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

    private List<DataSnapshot> chosenCares = new List<DataSnapshot>();

    private int careCounter = 0;

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
                        UpdateHealthBar();
                    }
                    else if (petType == "blackCat" && valBlackCat == -1)
                    {
                        FireSaver.GetPetHealth(callback, currentPet, userID);
                    }
                    if (petType == "Cat" && valCat != -1)
                    {
                        UpdateHealthBar();
                    }
                    else if (petType == "Cat" && valBlackCat == -1)
                    {
                        FireSaver.GetPetHealth(callback, currentPet, userID);
                    }
                }
                else
                {
                    RequestPetType();
                }
            }
            else
            {
                RequestPetName();
            }
        }

        // This block calls the timing system

        MeasureNeglectDamage();

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
                MeasureTiming();
            }
        }

        else
        {
            neglectpacer += 1;
        }

        if (neglectpacer == 10000)
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
        UpdateHealthBar();
        careCounter += 1;
        if (careCounter <= chosenCares.Count)
        {
            MeasureTiming();
        }
    }

    public void MeasureTiming() 
    {
        DateTime time = DateTime.Parse(chosenCares[careCounter].Child("lastcared").Value.ToString());

        TimeSpan diff = time.Subtract(DateTime.Now);

        int timeframe = int.Parse(chosenCares[careCounter].Child("timeframe").Value.ToString());

        if (timeframe == 1)
        {
            if (diff.Seconds < (-3600 * 24))
            {
                TakeNeglectDamage(chosenCares[careCounter]);
                FireSaver.SetLastCare(userID, currentPet, chosenCares[careCounter]);
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
            if (diff.Seconds < (-3600 / 22)) // Test Timeframe
            {
                TakeNeglectDamage(chosenCares[careCounter]); 
            }
        }
    }

    public void TakeNeglectDamage(DataSnapshot care) 
    { 
        if (petType == "Cat")
        {
            FireSaver.HurtPet(userID, currentPet, care, damagecallback);

        }
        if (petType == "blackCat")
        {
            FireSaver.HurtPet(userID, currentPet, care, damagecallback);
        }
    }
}
