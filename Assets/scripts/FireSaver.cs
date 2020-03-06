using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System.Threading.Tasks;

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

    public static void UpdatePlayer(string playerName, string field, string update) {
        _database.GetReference(playerName).Child(field).SetValueAsync(update);

        Debug.Log("updated player");

    }

    // public static void UpdatePlayerPet(string playerName, string update) {
    //     //problem here is that you need to add to a list that's already an existant object in the database
    //     _database.GetReference(playerName).Child("currentPets").RawJsonValueAsync(update);

    //     Debug.Log("updated player pet")

    // }

    public async Task<bool> SaveExists()
    {
        var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }
}