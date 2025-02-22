using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NewBehaviourScript : MonoBehaviour
{ string String = "Hello ";
    int okay = 2;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public int speed = 10;

    void Start()
    {
        rb = (GetComponent<Rigidbody2D>());
        Debug.Log("Hello World");
        string String2 = "World";
        Debug.Log(String+String2);
        /* HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE 
         * assaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa */
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(okay);
        okay++;

        //rb.velocity = new Vector2(-1, rb.velocity.y);



        /* if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1);
            //transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
            //transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -1);
            //transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(1, rb.velocity.y);
            //transform.position += new Vector3(1, 0, 0);
        }*/
        //transform.position += new Vector3 (0.005f, 0, 0);

        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput*speed, rb.velocity.y);
        Debug.Log(xInput);

        /* float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, yInput);
        Debug.Log(yInput); */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }

}
