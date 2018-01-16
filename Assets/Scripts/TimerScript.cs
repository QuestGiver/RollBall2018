using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    public Text timerLabel;

    public Rigidbody player;

    public float duration;

    public bool isRunning = true;

    void Update()
    {
        duration -= Time.deltaTime;

        int temp = (int)duration;

        int hours =     (temp/60/60);
        int minuntes =  (temp/60);
        int seconds =   (temp % 60);
        int speed = (int)player.velocity.magnitude;

        timerLabel.text = hours.ToString() + ":" + minuntes.ToString() + ":" + seconds.ToString() + "\n \t\t Speed:" + speed + " Mps";
    }

    public void ToggleTimer()
    {
        enabled = !enabled;
    }

}
