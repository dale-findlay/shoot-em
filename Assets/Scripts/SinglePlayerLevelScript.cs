using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerLevelScript : LevelScript
{
    public EnemySpawner enemySpawner;
    public PlayerCamera playerCamera;
    public GameObject headsParent;

    public Transform playerHeadTarget;

    private int m_finalScore = -1;

    public bool shouldShowPauseMenu = true;

    public override void LevelScriptStart()
    {
        Debug.Log("Level Script Start");

        if (enemySpawner == null)
        {
            throw new System.Exception("enemySpawner was not linked");
        }

        PlayerUI.Instance.HideAllElements();
        PlayerUI.Instance.GetUIElement("StartMessage").Show();

        if(Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.WindowsPlayer)
        {
            PlayerUI.Instance.GetUIElement("PauseButton").Show();
        }

    }
    
    //Begin the 'round' or 'game' called when you press the 'do your worst button thing'
    public void StartScene()
    {
        Debug.Log("Start Scene");

        PlayerUI.Instance.GetUIElement("StartMessage").Hide();
        PlayerUI.Instance.GetUIElement("EnemyCount").Show();

        Timer.Instance.StartTimer();

        enemySpawner.StartSpawning();
        playerCamera.enableCameraMove = true;
    }

    //Called when the timer ends.
    public void GameOver()
    {
        Debug.Log("Game Over");
        shouldShowPauseMenu = false;

        TogglePauseMenu();

        PlayerUI.Instance.HideAllElements();

        if(m_finalScore == -1)
        {
            m_finalScore = EnemyCounter.Instance.m_enemyCount; 
        }

        PlayerUI.Instance.GetUIElement("PointsCountText").GetComponent<UnityEngine.UI.Text>().text = m_finalScore.ToString();

        PlayerUI.Instance.GetUIElement("FinishMessage").Show();

        enemySpawner.CancelInvoke(); // cancel the invoke repeating spawning the heads.

        Enemy[] enemies = headsParent.GetComponentsInChildren<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.currentWanderTarget = playerHeadTarget.transform.position;
        }
    }

    //Called by the restart level button on gameover.
    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SinglePlayer");
    }

    //Called by the quit to main menu button.
    public void QuitToMainMenu()
    {
        LoadMainMenu();
    }

    // Shows or hides the pause menu.
    public void TogglePauseMenu()
    {
        PlayerUI.Instance.GetUIElement("PauseMenuPointsText").GetComponent<UnityEngine.UI.Text>().text = EnemyCounter.Instance.m_enemyCount.ToString();
        PlayerUI.Instance.GetUIElement("PauseMenuTimerText").GetComponent<UnityEngine.UI.Text>().text = Timer.Instance.timerSecondsText.text + " secs";

        if (Time.timeScale == 0)
        {
            PlayerUI.Instance.GetUIElement("PauseMenu").Hide();
            Time.timeScale = 1;
        }
        else if(shouldShowPauseMenu == true)
        {
            PlayerUI.Instance.GetUIElement("PauseMenu").Show();
            Time.timeScale = 0;
        }
    }

    public override void LevelScriptUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public override void LevelScriptEnd(Scene scene)
    {
        //Make sure the time scale is reset if the player quits the game in a pause menu.
        Time.timeScale = 1;
    }
}

