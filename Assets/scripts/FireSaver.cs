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

    public static void SavePlayer(string playerName, string json) {
        _database.GetReference(PLAYER_KEY).SetRawJsonValueAsync(json);

        //_database.ref("users").Child(playerName).SetRawJsonValueAsync(json);
        Debug.Log("save ran");
    }

    public async Task<bool> SaveExists() {
        var dataSnapshot = await _database.GetReference(PLAYER_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }
}