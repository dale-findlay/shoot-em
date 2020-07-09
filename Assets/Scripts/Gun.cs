using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedCoin
{
    //A script that controls the spawning of the bullet.
    //Ideally this should be using a object pool, but I did not implement this.
    public class Gun : MonoBehaviour
    {
        public Transform bulletPrefab;

        public List<Transform> bulletSpawnLocations = new List<Transform>();

        public float bulletSpeed = 6.0f;
        public int bulletLifetime = 4;

        // Use this for initialization
        void Start()
        {

        }

        //Spawns the bullet with a bullet speed.
        void ShootBullet()
        {
            foreach (Transform bulletSpawnLocation in bulletSpawnLocations)
            {
                var bulletObject = Instantiate(bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);

                bulletObject.GetComponent<Rigidbody>().velocity = bulletObject.forward * bulletSpeed;

                Destroy(bulletObject.gameObject, bulletLifetime);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //This time scale check is to make sure that the game isnt paused when a bullet is spawned.
            if ((TouchInput.GetTouchDown() || Input.GetMouseButton(0)) && Time.timeScale == 1)
            {
                ShootBullet();
            }
        }
    }
}
