using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDrop : MonoBehaviour
{
    public int damage = 2;
    public float rotationSpeed;
    float spawnTimer;
    Vector3 moveToPos;
    public float lerpTime;
    // Use this for initialization
    void Start()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit);
        moveToPos = hit.point;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, moveToPos, lerpTime * Time.deltaTime);
        transform.Rotate(rotationSpeed, 0, rotationSpeed / 3);
        spawnTimer += Time.deltaTime;
        if (spawnTimer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerController = other.GetComponent<BallControler>();
            if (playerController != null)
            {
                playerController.HitPoints -= damage;
                Destroy(gameObject);
            }
        }
    }
}
