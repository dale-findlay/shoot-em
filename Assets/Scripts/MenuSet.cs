using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedCoin
{
    public delegate void MenuSetFunction();

    public abstract class MenuSet : MonoBehaviour
    {
        protected event MenuSetFunction showMenuSet;
        protected event MenuSetFunction hideMenuSet;

        public void Show()
        {
            if (showMenuSet != null)
            {
                showMenuSet.Invoke();
            }
        }
        public void Hide()
        {
            if (hideMenuSet != null)
            {
                hideMenuSet.Invoke();
            }
        }

        public void Start()
        {
            showMenuSet += OnShowMenuSet;
            hideMenuSet += OnHideMenuSet;
        }

        public abstract void OnShowMenuSet();
        public abstract void OnHideMenuSet();
    }

}