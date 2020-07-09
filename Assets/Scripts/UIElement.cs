using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Attach this script to a GameObject that is a parent of PlayerUI.
public class UIElement : MonoBehaviour {

    //Show the UIElement
    public void Show()
    {
        Graphic[] graphics = gameObject.GetComponentsInChildren<Graphic>();

        foreach (Graphic r in graphics)
        {
            r.enabled = true;
        }
    }

    //Hide the UIElement
    public void Hide()
    {
        Graphic[] graphics = gameObject.GetComponentsInChildren<Graphic>();

        foreach(Graphic r in graphics)
        {
            r.enabled = false;
        }
    }
}
