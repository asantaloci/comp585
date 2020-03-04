using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.Events;

public class FireBase: MonoBehaviour {

  public UnityEvent onFirebaseInitialized = new UnityEvent();
  
  private void Start() {
    Debug.Log("Ran Firebase");
    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
      if (task.Exception != null) {
        Debug.Log("Failed to initialize Firebase with " + task.Exception);
        return;
      }

      onFirebaseInitialized.Invoke();

    });
  }



}
