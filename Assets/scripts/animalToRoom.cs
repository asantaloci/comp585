


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Firebase.Auth;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;

public class animalToRoom : MonoBehaviour
    {
// if it is a certain animal, change the selected animal to that animal!!!!

        public string chosenpet;
        public bool wee = false;
        
        public GameObject blackcat;
        public GameObject cat;
        public GameObject shiba;
        public string userID;
              private static FirebaseDatabase _database;


    void Start()
    {
    
        _database = FirebaseDatabase.DefaultInstance;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        if (FirebaseAuth.DefaultInstance.CurrentUser == null)
        {
            this.userID = "default";
            
            // this.userEmail = "";
        }
        else
        {
            this.userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        }

         FirebaseDatabase.DefaultInstance.GetReference(userID).GetValueAsync().ContinueWith(task => {
             Debug.Log("comeone");
        if (task.IsFaulted) {
          Debug.Log("shit");
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          string update = snapshot.Value.ToString();
          Debug.Log("yay" + snapshot);
          FirebaseDatabase.DefaultInstance.GetReference(userID).Child("activePet").ValueChanged += HandleValueChanged;

        }
      });


    void HandleValueChanged(object sender, ValueChangedEventArgs args) {
      if (args.DatabaseError != null) {
        Debug.LogError(args.DatabaseError.Message);
        return;
      }
      Debug.Log("non handlevaluechange error " + args.Snapshot.Value.ToString());
      chosenpet = args.Snapshot.Value.ToString();
      Debug.Log(chosenpet);
       
    }
    
// while(chosenpet != "") {
//         // GetUsers();
//  Debug.Log("“animal in room function”");
//  Debug.Log(chosenpet);
//         //  Debug.Log("please work" + GetPetType(userID));
//         if (chosenpet == "Poopy") {
// Debug.Log("“orangecat”");
//             blackcat.SetActive(false);
//             cat.SetActive(true);
//         } else {
//          Debug.Log("“black cat”");
//          cat.SetActive(false);
//          blackcat.SetActive(true);
//      }
//     }
    }
    
    void Update() {
         
        // Debug.Log(chosenpet);
        if((chosenpet == "Cat" || chosenpet == "blackCat"  || chosenpet == "shiba"  || chosenpet == "Poopy" || chosenpet == "Poopy2")) {
        // GetUsers();
//  Debug.Log("“animal in room function”");
 Debug.Log(chosenpet);
 
        //  Debug.Log("please work" + GetPetType(userID));
        if (chosenpet == "Cat" || chosenpet == "Poopy") {
// Debug.Log("“orangecat”");
            blackcat.SetActive(false);
            cat.SetActive(true);
            wee = true;
        } 
        else if (chosenpet == "blackCat" || chosenpet == "Poopy2") {
// Debug.Log("“orangecat”");
            blackcat.SetActive(true);
            cat.SetActive(false);
            shiba.SetActive(false);
            wee = true;
        } else 
//shiba
             if (chosenpet == "shiba") {
Debug.Log("shiba");

            blackcat.SetActive(false);
            cat.SetActive(false);
            shiba.SetActive(true);
            wee = true;
        } else {
         Debug.Log("“shiba”");

        //  Debug.Log("“black cat”");
         cat.SetActive(false);
         blackcat.SetActive(false);
         shiba.SetActive(false);
         wee = true;
     } 
    }
    }
//  public void GetUsers(){
//           Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
//           _database.GetReference(userID).GetValueAsync().ContinueWith(task => {
//                     if (task.IsFaulted) {
//                         // Handle the error...
//                     }
//                     else if (task.IsCompleted) {
//                       DataSnapshot snapshot = task.Result;
//                       foreach ( DataSnapshot user in snapshot.Children){
//                         IDictionary dictUser = (IDictionary)user.Value;
//                         Debug.Log ("bro please" + dictUser["activePet"]);
//                       }
//                     }
//           });
//  }

// public void SaveAndRetrieveData() //from the database (server)...
// {
//     //store the data to the server...
//     reference.Child("My Car Collections").Child("Sports Car").SetValueAsync("Ferrari");
//     print("data saved");
//     //Retrieve the data and convert it to string...
//     FirebaseDatabase.DefaultInstance.GetReference("My Car Collections").GetValueAsync().ContinueWith(task => 
//     {  
//         DataSnapshot snapshot = task.Result;
//         string ss = snapshot.Child("Sports Car").Value.ToString();
//         print(ss);
//         print("data retrieved");
//     });        
// }

 public static string GetPetType(string playerID)
    {
        
        string petUpdate = "";
        // while(petUpdate == "Poopy") {
        _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            
            if (task.IsCanceled)
            {
                Debug.Log("Could Not Retrieve Active Pet");
                return "";
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Could Not Retrieve Active Pet: " + task.Exception);
                return "";
            }

            DataSnapshot snapshot = task.Result;
            petUpdate = snapshot.Value.ToString();
            Debug.Log("snapshot" + petUpdate);
            string updatedPet = PetTypeValue(playerID, petUpdate); // this doesn't work
            Debug.Log(playerID);
            Debug.Log("COME ONE" + petUpdate);
            // return updatedPet;
            
            return petUpdate;
            
        });
        // return petUpdate;
        // }
        return petUpdate;
    }

  private static string PetTypeValue(string playerID, string petName)
    {

        string petUpdate = "";

        _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Could Not Retrieve Active Pet Type");
                return "";
            }
            if (task.IsFaulted)
            {
                Debug.LogError("Could Not Retrieve Active Pet Type: " + task.Exception);
                return "";
            }
            
            DataSnapshot snapshot = task.Result;
            // Debug.Log("petupdate in pettylevalue" + snapshot);
            petUpdate = snapshot.Value.ToString();
            // Debug.Log("petupdate in pettylevalue " + petUpdate);
            return petUpdate;


        });
        return petUpdate;
    }







    
// // original
//     private static string PetTypeValue(string playerID, string petName)
//     {

//         string petUpdate = "";

//         _database.GetReference(playerID).Child(petName).Child("petType").GetValueAsync().ContinueWithOnMainThread(task =>
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
//             Debug.Log("petupdate in pettylevalue" + snapshot);
//             petUpdate = snapshot.Value.ToString();
//             Debug.Log("petupdate in pettylevalue" + petUpdate);
//             return petUpdate;


//         });
//         return "";
//     }
    }
