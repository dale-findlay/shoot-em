using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a tool that allows you to get UIElements from the PlayerUI gameobject in the scene. This is allows you to only target specific elements (by assigning the UIElement script) on to a UI element.
/// It works by the name of the object with the UIElement script attached.
/// </summary>
public class PlayerUI : MonoBehaviour
{
    private static PlayerUI m_instance;

    public static PlayerUI Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        if (m_instance)
        {
            Debug.LogError("More than one instance of PlayerUI Found!!!");
        }
        else
        {
            m_instance = this;
        }
    }

    /// <summary>
    /// Hides all elements.
    /// </summary>
    public void HideAllElements()
    {
        UIElement[] uiElements = GetComponentsInChildren<UIElement>(true);

        foreach (UIElement element in uiElements)
        {
            element.Hide();
        }
    }

    /// <summary>
    /// Returns the UI element based on the name. From the PlayerUI gameObject.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public UIElement GetUIElement(string name)
    {
        UIElement[] uiElements = GetComponentsInChildren<UIElement>(true);

        foreach (UIElement element in uiElements)
        {
            if (element.gameObject.name == name)
            {
                return element;
            }
        }

        return null;
    }
}
