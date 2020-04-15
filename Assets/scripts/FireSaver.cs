using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using System.Threading.Tasks;
using static Firebase.Extensions.TaskExtension;

public class FireSaver : MonoBehaviour
{
    private const string PLAYER_KEY = "PLAYER_KEY";
    private static FirebaseDatabase _database;


    // Start is called before the first frame update
    void Start()
    {
        _database = FirebaseDatabase.DefaultInstance;

    }

    public static void SavePlayer(string playerName, string json)
    {
        _database.GetReference(playerName).SetRawJsonValueAsync(json);

        //_database.ref("users").Child(playerName).SetRawJsonValueAsync(json);
        Debug.Log("save ran");
    }

    public static void UpdatePlayer(string playerID, string field, string update) {
        _database.GetReference(playerID).Child(field).SetValueAsync(update);

        Debug.Log("updated player");

    }

    public static void AddPet(string playerID, string petName, string json) {
        // only changes first array pet for now (theoretically)
        //BUT LATER MAKE IT A DICTIONARY WITH THE "0" REPLACED WITH PET NAME!!!
        _database.GetReference(playerID).Child("currentPets").Child(petName).SetRawJsonValueAsync(json);
        _database.GetReference(playerID).Child("activePet").SetValueAsync(petName);
    }

    public static void AdoptPet(string playerID, Dictionary<string, object> json) //, Dictionary<string, string> actions)
    {
        string petUpdate = "";
        _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Could Not Retrieve Active Pet");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                petUpdate = snapshot.Value.ToString();
                // string sampleJson = " {\"actions\": {\"water\": {\"habit\": \"jogging\", \"healvalue\": \"1\", \"hurtvalue\": \"1\", \"lastcared\": \"timestamp\", \"timeframe\": \"6\" }, {\"feed\": \"habit\": \"eating healthy\", \"healvalue\": \"1\", \"hurtvalue\": \"1\", \"lastcared\": \"timestamp\", \"timeframe\": \"6\" }}, \"obstacles\":[\"laziness\", \"money\"] } ";
                // _database.GetReference(playerID).Child("currentPets").Child(petUpdate).Child("habits").Child("actions").SetValueAsync(actions);
                // Dictionary<string, object> sampleJson = 
                _database.GetReference(playerID).Child("currentPets").Child(petUpdate).Child("habits").SetValueAsync(json);
                // _database.GetReference(playerID).Child("currentPets").Child(petUpdate).Child("habits").SetRawJsonValueAsync(json);
                Debug.Log(json);
            }
        });

        //_database.ref("users").Child(playerName).SetRawJsonValueAsync(json);
        
    }

    public static void SetLastCare(string playerID, string petName, DataSnapshot care)
    {
        _database.GetReference(playerID).Child("currentPets").Child(petName).Child("habits").Child("actions").Child(care.Key.ToString()).Child("lastcared").SetValueAsync(DateTime.Now.ToString());
    }

    public static void HurtPet(string playerID, string activepet, DataSnapshot failedcare, Action<bool> callback)
    {
        int health;
        int hurtvalue;
        int newhealth;

        _database.GetReference(playerID).Child("currentPets").Child(activepet).Child("health").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Could not retrieve Pet Health");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                health = int.Parse(snapshot.Value.ToString());
                hurtvalue = int.Parse(failedcare.Child("hurtvalue").Value.ToString());
                newhealth = health - hurtvalue;
                _database.GetReference(playerID).Child("currentPets").Child(activepet).Child("health").SetValueAsync(newhealth);
                callback(true);
            }
        });
    }

    public async Task<bool> SaveExists()
    {
        var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }

    //Here are all of the Getters that can be accessed by other scripts

    public static void GetPetHealth(Action<int> callback, string petName, string playerID)
    {
        _database.GetReference(playerID).Child("currentPets").Child(petName).Child("health").GetValueAsync().ContinueWith(task => {
      if (task.IsFaulted)
      {
                Debug.Log("Could not retrieve Pet Health");
          }
      else if (task.IsCompleted)
      {
          DataSnapshot snapshot = task.Result;
                callback(int.Parse(snapshot.Value.ToString())); //won't work yet
          }
  });
    }

    public static void GetCurrentPet(Action<string> callback, string playerID)
    {
        _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Could not retrieve active pet");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                callback(snapshot.Value.ToString()); 
            }
        });
    }

    public static void GetPetType(Action<string> callback, string playerID, string petName)
    {
        _database.GetReference(playerID).Child("currentPets").Child(petName).Child("animalType").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Could not retrieve active pet");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                callback(snapshot.Value.ToString()); 
            }
        });
    }

    public static void GetPetCares(Action<DataSnapshot> callback, string playerID, string petName)
    {
        _database.GetReference(playerID).Child("currentPets").Child(petName).Child("habits").Child("actions").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("Could not retrieve active pet cares");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach(DataSnapshot element in snapshot.Children)
                {
                    callback(element);
                }
            }
        });
    }

    // public static void AddActions



    //     public static string GetPetType(string playerID)
    //     {

    //         string petUpdate = "Poopy";
    //         while(petUpdate == "Poopy") {
    //         _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
    //         {

    //             if (task.IsCanceled)
    //             {
    //                 Debug.Log("Could Not Retrieve Active Pet");
    //                 return "";
    //             }
    //             if (task.IsFaulted)
    //             {
    //                 Debug.LogError("Could Not Retrieve Active Pet: " + task.Exception);
    //                 return "";
    //             }

    //             DataSnapshot snapshot = task.Result;
    //             petUpdate = snapshot.Value.ToString();
    //             Debug.Log("snapshot" + petUpdate);
    //             string updatedPet = PetTypeValue(playerID, petUpdate); // this doesn't work
    //             Debug.Log(playerID);
    //             Debug.Log("COME ONE" + petUpdate);
    //             // return updatedPet;

    //             return petUpdate;

    //         });
    //         return petUpdate;
    //         }
    //         return petUpdate;
    //     }

    // // // original
    // //     private static string PetTypeValue(string playerID, string petName)
    // //     {

    // //         string petUpdate = "";

    // //         _database.GetReference(playerID).Child(petName).Child("petType").GetValueAsync().ContinueWithOnMainThread(task =>
    // //         {
    // //             if (task.IsCanceled)
    // //             {
    // //                 Debug.Log("Could Not Retrieve Active Pet Type");
    // //                 return "";
    // //             }
    // //             if (task.IsFaulted)
    // //             {
    // //                 Debug.LogError("Could Not Retrieve Active Pet Type: " + task.Exception);
    // //                 return "";
    // //             }

    // //             DataSnapshot snapshot = task.Result;
    // //             Debug.Log("petupdate in pettylevalue" + snapshot);
    // //             petUpdate = snapshot.Value.ToString();
    // //             Debug.Log("petupdate in pettylevalue" + petUpdate);
    // //             return petUpdate;


    // //         });
    // //         return "";
    // //     }



    //   private static string PetTypeValue(string playerID, string petName)
    //     {

    //         string petUpdate = "";

    //         _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
    //         {
    //             if (task.IsCanceled)
    //             {
    //                 Debug.Log("Could Not Retrieve Active Pet Type");
    //                 return "";
    //             }
    //             if (task.IsFaulted)
    //             {
    //                 Debug.LogError("Could Not Retrieve Active Pet Type: " + task.Exception);
    //                 return "";
    //             }

    //             DataSnapshot snapshot = task.Result;
    //             // Debug.Log("petupdate in pettylevalue" + snapshot);
    //             petUpdate = snapshot.Value.ToString();
    //             // Debug.Log("petupdate in pettylevalue " + petUpdate);
    //             return petUpdate;


    //         });
    //         return petUpdate;
    //     }






    //_database.ref("users").Child(playerName).SetRawJsonValueAsync(json);


    // public static void UpdatePlayerPet(string playerName, string update) {
    //     //problem here is that you need to add to a list that's already an existant object in the database
    //     _database.GetReference(playerName).Child("currentPets").RawJsonValueAsync(update);

    //     Debug.Log("updated player pet")

    // }

    //    public static int getPetHealth(Action callback)
    //    {
    //        string userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    //        string petName;

    //        _database.GetReference(userID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
    //        {

    //                DataSnapshot snapshot = task.Result;
    //                petName = snapshot.Value.ToString();

    //                getPetHealthByName(petName, callback);

    //        });

    //    }

    //    public static void getPetHealthByName(string petName, Action callback)
    //    {
    //        string userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    //        int petHealth;

    //        _database.GetReference(userID).Child("currentPets").Child(petName).Child("health").GetValueAsync().ContinueWithOnMainThread(task =>
    //        {

    //            if (task.IsFaulted)
    //            {
    //                Debug.Log("Could Not Retrieve Pet Health");
    //            }
    //            else 
    //            {

    //                DataSnapshot snapshot = task.Result;
    //                petHealth = int.Parse(snapshot.Value.ToString());
    //                Debug.Log(petHealth);
    //                callback(petHealth);
    //            }
    //        });
    //    }


}