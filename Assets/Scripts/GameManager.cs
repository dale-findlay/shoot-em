using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedCoin
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager gameManager = null;

        // Use this for initialization
        void Awake()
        {

            if (gameManager != null)
            {
                Destroy(gameManager);
            }
            else
            {
                DontDestroyOnLoad(this);
                gameManager = this;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
