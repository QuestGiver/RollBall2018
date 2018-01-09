using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public BallControler ballPrefab;


    public float HitPoints;
    public float Stamina;
    public bool grounded = true;
    public bool clone = false;
    Rigidbody rb;
    public float speed;
    public int score;

    bool spawned = false;

    float timer = 0;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        HitPoints = 10;
        Stamina = 5;
        grounded = true;
	}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float verticle = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, verticle);
        Vector3 vel = move * speed * Time.deltaTime;


        if (Input.GetMouseButtonDown(1) && Stamina > 0)
        {
            //rb.MovePosition((new Vector3(horizontal, 0, verticle)) * (speed * 2) * Time.deltaTime);
            rb.velocity = vel * (speed*2) * Time.deltaTime;
            Stamina -= Time.deltaTime;
        }
        else
        {
            //rb.MovePosition((new Vector3(horizontal,0,verticle)) * speed * Time.deltaTime);
            rb.velocity = vel * speed * Time.deltaTime;
            if (Stamina < 5)
            {
                Stamina += Time.deltaTime;
            }
        }

        if (grounded == false)
        {
            rb.MovePosition((new Vector3(0, -8, 0)) * speed * Time.deltaTime);
        }
        

        //if (rb.velocity.magnitude > 500)
        //{
        //    speed = 0;
        //    Debug.Log("OIIII");
        //}

        //for (int i = 0; i < 1; i++)
        //{
        //    Instantiate(this, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        //}

        //timer += Time.deltaTime;
        //if ((timer > 1 && !clone) || (timer > 1 && clone && !spawned))
        //{
        //    BallControler dude = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //    dude.clone = true;
        //    timer = 0;
        //    spawned = true;
        //}

        if (Input.GetMouseButtonDown(0) && !clone)
        {
            for (int i = 0; i < 10; i++)
            {
                BallControler dude = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
                dude.clone = true;
                timer = 1.5f;
                spawned = true;
            }

        }

        if (timer > 2 && clone == true)
        {
            Destroy(gameObject);
        }

    }
}
