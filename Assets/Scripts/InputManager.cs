using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedCoin
{
    public static class TouchInput
    {
        private static int touchIndex = -1;

        /// <summary>
        /// Returns whether the screen has been touched or not.
        /// </summary>
        /// <returns></returns>
        public static bool GetTouchDown()
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    touchIndex = i;
                    return true;
                }
            }

            touchIndex = -1;

            //if not touches or no touches have 'begun' then we didnt touch the screen.
            return false;
        }

        public static Vector2 TouchPosition
        {
            get
            {
                if (touchIndex == -1)
                {
                    return new Vector2(0, 0);
                }
                else
                {
                    return Input.GetTouch(touchIndex).position;
                }
            }
        }
    } 
}
