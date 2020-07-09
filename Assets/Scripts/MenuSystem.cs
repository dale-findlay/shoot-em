using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedCoin
{
    public class MenuSystem : MonoBehaviour
    {
        public Dictionary<string, MenuSet> menuSets = new Dictionary<string, MenuSet>();

        /// <summary>
        /// Shows a menu set.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hideOthers">Hides all other menusets in the scene.</param>
        void ShowMenuSet(string name, bool hideOthers = false)
        {
            if (!menuSets.ContainsKey(name))
            {
                throw new Exception("Failed to show menuset :" + name + " it doesnt exist!!!");
            }

            MenuSet menuSet = menuSets[name];
            menuSet.Show();

            if (hideOthers)
            {
                foreach (KeyValuePair<string, MenuSet> menuSetEntry in menuSets)
                {
                    menuSetEntry.Value.Hide();
                }
            }
        }

        /// <summary>
        /// Hides a menuset.
        /// </summary>
        /// <param name="name"></param>
        public void HideMenuSet(string name)
        {
            if (!menuSets.ContainsKey(name))
            {
                throw new Exception("Failed to hide menuset :" + name + " it doesnt exist!!!");
            }

            MenuSet menuSet = menuSets[name];
            menuSet.Hide();
        }
    } 
}
