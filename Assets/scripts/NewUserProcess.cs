using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class NewUserProcess : MonoBehaviour
{
    public InputField playerInputField;
    public Text playerInputText;
    public Text test;
    public Text dialogueText;

    private string playerName;

    private string wish;

    private string userID;

    private string userEmail;

    // Start is called before the first frame update
    void Start()
    {
        // FirebaseAuth.DefaultInstance.StateChanged += HandleAuthStateChanged;
        // Debug.Log(FirebaseAuth.DefaultInstance.CurrentUser.Email);
        if (FirebaseAuth.DefaultInstance.CurrentUser == null) {
            this.userID = "default";
            this.userEmail = "";
        } else {
            this.userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
            this.userEmail = FirebaseAuth.DefaultInstance.CurrentUser.Email;
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nameInput()
    {

        if (!playerInputField.text.Equals(""))
        {
            playerName = playerInputField.text;
            //test.text = playerName;
            playerInputField.text = string.Empty;
        }


    }

    public void wishInput()
    {
        if (!playerInputField.text.Equals(""))
        {
            wish = playerInputField.text;
            //test.text = wish;
            playerInputField.text = string.Empty;
        }
    }

    public void createNewUser()
    {
        var user = new NewUserGenerator(playerName, wish, userEmail);
        string json = JsonUtility.ToJson(user);

        FireSaver.SavePlayer(userID, json);

        SceneManager.LoadScene("first-adoption");

    }

    public void currencyPosting() {
        FireSaver.getCurrency(userID);
    }

}
