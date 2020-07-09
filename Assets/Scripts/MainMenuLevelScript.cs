using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuLevelScript : LevelScript {
    public override void LevelScriptEnd(Scene scene)
    {
    }

    public override void LevelScriptStart()
    {

    }

    public override void LevelScriptUpdate()
    {
     
    }

    //The UI button callback called by the Singleplayer button.
    public void SinglePlayerButton()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    //Invoked by the Quit button.
    public void QuitGame()
    {
        Application.Quit();
    }
}
