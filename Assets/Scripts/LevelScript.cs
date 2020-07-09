using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This is an abstract class that is essentially to compartmentalize a scene's logic elements.
public abstract class LevelScript : MonoBehaviour {

    public void Start()
    {
        LevelScriptStart();
        SceneManager.sceneUnloaded += LevelScriptEnd;
    }

    public abstract void LevelScriptEnd(Scene scene);
    public abstract void LevelScriptStart();
    public abstract void LevelScriptUpdate();

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        LevelScriptUpdate();
    }
}
