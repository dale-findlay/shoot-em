using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic Enemy class that controls some wander logic.
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    public BoxCollider spawnerCollider;

    public Transform playerTarget;
    public float health = 5;
    public float lifeTime = 10;

    private float currentTime = 0.0f;
    public float wanderTime = 10.0f;

    public float wanderLerpRate = 2.0f;

    public bool wander = true;

    public Vector3 currentWanderTarget;

    // Use this for initialization
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        Destroy(gameObject, lifeTime);

        currentWanderTarget = GetRandomBoxPoint();

        currentTime = wanderTime;
    }
    Vector3 GetRandomBoxPoint()
    {
        Vector3 max = spawnerCollider.bounds.max;
        Vector3 min = spawnerCollider.bounds.min;

        Random.InitState(System.DateTime.Now.Millisecond);

        return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (wander)
        {
            if (spawnerCollider != null)
            {
                if ((transform.position - currentWanderTarget).magnitude <= 0.1)
                {
                   currentWanderTarget = GetRandomBoxPoint();
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWanderTarget, wanderLerpRate * Time.deltaTime);
            transform.LookAt(currentWanderTarget);

        }
    }
}
