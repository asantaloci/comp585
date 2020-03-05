using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static string playerEmail = "THIS IS INCORRECT";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
