using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The red and yellow skull.
public class SkullEnemy : Enemy {

    public float speed = 3.0f;
    private bool killed = false;

    public ParticleSystem killExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 2;

            if(health <= 0)
            {
                GetComponent<Collider>().enabled = false;
                EnemyCounter.Instance.HeadCollected();
                killExplosion.gameObject.SetActive(true);
                Destroy(gameObject, killExplosion.main.duration);
            }
        }
    }
}
