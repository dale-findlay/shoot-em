using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script just replaces a string depending on what platform the game is executing on.
[RequireComponent(typeof(UnityEngine.UI.Text))]
public class PlatformActionReplace : MonoBehaviour
{
    public string replacementText = "{Action}";

    public string clickEquivalent = "Click";
    public string touchEquivalent = "Tap";

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.Replace(replacementText, clickEquivalent);
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = GetComponent<UnityEngine.UI.Text>().text.Replace(replacementText, touchEquivalent);
        }
    }
}

