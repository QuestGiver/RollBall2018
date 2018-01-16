using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Rigidbody rb;

    public float distance;
    public float radius;
    public float speed;

    public float wanderTime;
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody>();
    }

    Vector3 doWander()
    {
        //project a point infront
        Vector3 circlePos = transform.position + (transform.forward * distance);


        //genrate random direction based on unitsphere and add to projected point.
        Vector3 wanderTarget = (Random.insideUnitSphere * radius);
        wanderTarget += circlePos;


        //calc direction to wander target and return normalized
        Vector3 dir = transform.position - wanderTarget;
        
        return dir.normalized;
    }

    // Update is called once per frame
    public Vector3 moveDir;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            moveDir = doWander();
            timer = wanderTime;
        }

        rb.AddForce(moveDir * speed);

        
    }
}
