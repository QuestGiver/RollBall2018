using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineNumbers : MonoBehaviour
{
    IEnumerator CoroutineCounting(float waitTime)
    {
        int number = 0;
        while (number < 1000)
        {
            Debug.Log(number);
            number++;
            yield return new WaitForSeconds(waitTime);
        }
    }

    void Start()
    {
        StartCoroutine(CoroutineCounting(1));
    }
}
