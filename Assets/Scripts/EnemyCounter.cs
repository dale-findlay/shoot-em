using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A counter that counts how many enemies that.
/// </summary>
public class EnemyCounter : MonoBehaviour
{
    private static EnemyCounter m_instance;
    public static EnemyCounter Instance
    {
        get
        {
            return m_instance;
        }
    }

    public Text enemyCountText;
    public int m_enemyCount = 0;

    private void Awake()
    {
        if (m_instance)
        {
            Debug.LogError("More than one instance of EnemyCounter Found!!!");
        }
        else
        {
            m_instance = this;
        }
    }

    //Callback called by enemy hit by bullet.
    public void HeadCollected()
    {
        m_enemyCount++;
    }

    void Update()
    {
        enemyCountText.text = m_enemyCount.ToString();
    }

}
