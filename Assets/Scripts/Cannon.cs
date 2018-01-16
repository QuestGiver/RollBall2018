using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    public float ProjSpeed;
    public float time;
    public float fireTime;
    // Use this for initialization
    void Start()
    {
        //ProjSpeed = 500;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (time >= fireTime)
            {
                GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
                newProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, ProjSpeed));
                time = 0;
            }


        }
    }
}
