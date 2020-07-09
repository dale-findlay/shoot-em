using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//A singleton timer constructed on a 
public class Timer : MonoBehaviour
{
    private static Timer m_instance;

    public static Timer Instance
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
            Debug.LogError("More than one instance of Timer Found!!!");
        }
        else
        {
            m_instance = this;
        }
    }

    public float initialTimerValueSecs = 60;
    public float currentTimerValue;
    public bool started;
    public Text timerSecondsText;

    public UnityEvent timerFinish;

    // Use this for initialization
    void Start()
    {
        currentTimerValue = initialTimerValueSecs;
        if(timerSecondsText == null)
        {
            throw new System.Exception("timerSecondsText was null");
        }
    }

    public void StartTimer()
    {
        PlayerUI.Instance.GetUIElement("Timer").Show();
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            currentTimerValue -= Time.deltaTime;
            if (currentTimerValue <= 0)
            {
                currentTimerValue = 0;
                timerFinish.Invoke();
                started = false;
            }

            timerSecondsText.text = ((int)currentTimerValue).ToString();
        }
    }
}
