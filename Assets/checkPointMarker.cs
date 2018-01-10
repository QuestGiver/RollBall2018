using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointMarker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallControler player = other.GetComponent<BallControler>();

        if (player != null)
        {
            player.checkPontLoc = transform.position;
            Debug.Log("CHECKPOINT");
        }
    }




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
