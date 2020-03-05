using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using static Firebase.Extensions.TaskExtension;


public class Authentication : MonoBehaviour
{
    //[SerializeField] private Button _registrationButton;
    //private Coroutine _registrationCoroutine;
    //public UserRegisteredEvent OnUserRegistered = new UserRegisteredEvent();
    //public UserRegistrationFailedEvent OnUserRegistrationFailed = new UserRegistrationFailedEvent();

    public InputField username;
    public InputField password;

    public void authenticate()
    {
        var auth = FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync(this.username.text, this.password.text).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

           /* switchScene(task);*/

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            SceneManager.LoadScene("room");


        });

        /*SceneManager.LoadScene("room");*/

    }

/*    private void switchScene(task res)
    {

    }*/

    public void createNewUser()
    {
        
        var auth = FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(this.username.text, this.password.text).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            SceneManager.LoadScene("adoption-interview");

           /* GameObject global = GameObject.Find("Global");
            GlobalVars globalVars = global.GetComponent<GlobalVars>();
            globalVars.playerEmail = this.username.text;
            Debug.Log(globalVars.playerEmail);*/
        });
        //Debug.Log("ran and maybe finished registration");
        
    }
}
