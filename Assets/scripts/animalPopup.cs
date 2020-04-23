using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using static Firebase.Extensions.TaskExtension;

public class animalPopup : MonoBehaviour
{


    public GameObject popup;
    private static FirebaseDatabase _database;
    string playerId; 

    // Start is called before the first frame update
    void Start()
    {
        _database = FirebaseDatabase.DefaultInstance;
        playerId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    }

    public void OpenPopup()
    {
        if (popup != null)
        {
            popup.SetActive(true);
        }

        getHabits(playerId);


    }

    public void getHabits(string playerID) //, Dictionary<string, string> actions)
    {
        string petUpdate = "";
        Dictionary<string, object> habits = null;
        _database.GetReference(playerID).Child("activePet").GetValueAsync().ContinueWithOnMainThread(task =>
        {
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
                _database.GetReference(playerID).Child("currentPets").Child(petUpdate).Child("habits").Child("actions").GetValueAsync().ContinueWithOnMainThread(res =>
                {

                    if (res.IsFaulted)
                    {
                        Debug.Log("Could Not Retrieve Active Pet");
                    }
                    else if (res.IsCompleted)
                    {
                        DataSnapshot snap = res.Result;
                        habits = (Dictionary<string, object>) snap.Value;
                        int numberOfHabits = habits.Count;
                        Debug.Log(numberOfHabits);
                        switch(numberOfHabits){
                            case 0:
                                break;
                            case 1:
                                GameObject.Find("room-feed").SetActive(false);
                                GameObject.Find("room-walk").SetActive(false);
                                GameObject.Find("room-play").SetActive(false);
                                GameObject.Find("room-groom").SetActive(false);
                                GameObject.Find("room-bath").SetActive(false);
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 2:
                                GameObject.Find("room-walk").SetActive(false);
                                GameObject.Find("room-play").SetActive(false);
                                GameObject.Find("room-groom").SetActive(false);
                                GameObject.Find("room-bath").SetActive(false);
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 3:
                                GameObject.Find("room-play").SetActive(false);
                                GameObject.Find("room-groom").SetActive(false);
                                GameObject.Find("room-bath").SetActive(false);
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 4:
                                GameObject.Find("room-groom").SetActive(false);
                                GameObject.Find("room-bath").SetActive(false);
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 5:
                                GameObject.Find("room-bath").SetActive(false);
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 6:
                                GameObject.Find("room-six").SetActive(false);
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 7:
                                GameObject.Find("room-seven").SetActive(false);
                                break;
                            case 8:
                                break;
                        }
                            
                    }
                });
                // _database.GetReference(playerID).Child("currentPets").Child(petUpdate).Child("habits").SetRawJsonValueAsync(json);
                // Debug.Log(json);
            }
        });

        //_database.ref("users").Child(playerName).SetRawJsonValueAsync(json);

    }


    //pray to god



}
