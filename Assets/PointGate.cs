using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGate : MonoBehaviour
{
    public int pointsNeeded = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BallControler.score >= pointsNeeded)
        {
            Destroy(gameObject);
        }
    }
}
