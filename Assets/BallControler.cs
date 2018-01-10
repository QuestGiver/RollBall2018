using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public GameObject ballPrefab;


    public float HitPoints;
    public float Stamina;
    public bool grounded = true;
    public bool clone = false;
    Rigidbody rb;
    public float speed;
    public static int score;
    public float desiredScale;
    public Vector3 checkPontLoc;

    bool spawned = false;

    public float timer = 0;

	// Use this for initialization
	void Start ()
    {

        rb = GetComponent<Rigidbody>();
        checkPontLoc = transform.position;
        HitPoints = 10;
        Stamina = 5;
        grounded = true;
        desiredScale = 9;
        //if(clone == false)
        //{
        //    clone = false;
        //}
        
        timer = 0;
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
        //transform.localScale += new Vector3(0.1F, 0, 0);
        float horizontal = Input.GetAxis("Horizontal");
        float verticle = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, verticle);
        Vector3 vel = move * speed * Time.deltaTime;
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && Stamina > 0)
        {
            //rb.MovePosition((new Vector3(horizontal, 0, verticle)) * (speed * 2) * Time.deltaTime);
            // rb.velocity = vel * (speed*2) * Time.deltaTime;
            rb.velocity = new Vector3(vel.x * 2, rb.velocity.y, vel.z * 2);
            //rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.y) * (speed * 2) * Time.deltaTime;
            Stamina -= Time.deltaTime;
        }
        else
        {
            //rb.MovePosition((new Vector3(horizontal,0,verticle)) * speed * Time.deltaTime);
            rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);
            if (Stamina < 5)
            {
                Stamina += Time.deltaTime;
            }
        }

        //if (Input.GetButtonDown("Return"))
        //{
        //    transform.position = checkPontLoc;
        //}

        //if (grounded == false)
        //{
        //   // rb.MovePosition((new Vector3(0, -500, 0)) * Time.deltaTime);
        //}


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

        //if (Input.GetMouseButtonDown(0) && !clone)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        GameObject Clone = Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //        var dude = Clone.GetComponent<BallControler>();
        //        dude.clone = true;
        //        dude.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                
        //        dude.timer = 1.5f;
        //        spawned = true;
        //    }

        //}



        if (timer > 3 && clone == true)
        {
            Debug.Log("Dude");
            Destroy(gameObject);
        }
        else if(transform.localScale.x < desiredScale && transform.localScale.y < desiredScale && transform.localScale.z < desiredScale && clone)
        {
            Debug.Log("Scale");
            transform.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;
        }

    }
}
