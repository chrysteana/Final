using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class NewBehaviourScript : MonoBehaviour
{ string String = "Hello "; 
    int okay = 2;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public int speed = 10;
    public string nextLevel = "Level_2";
    [SerializeField] private Animator animator;
    bool facingRight = true;
    


    void Start()
    {
        rb = (GetComponent<Rigidbody2D>());
        sr = (GetComponent<SpriteRenderer>());
        //Debug.Log("Hello World");
        //string String2 = "World";
        //Debug.Log(String+String2);
        /* HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE 
         * assaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa */

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(okay);
        okay++;

        //rb.velocity = new Vector2(-1, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           sr.color = Color.magenta;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sr.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
            //transform.position += new Vector3(0, 1, 0);
        }
        

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-4, rb.velocity.y);
        
        }
        /*
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
        //Debug.Log(xInput);

        /* float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, yInput);
        Debug.Log(yInput); */

        
        if (xInput != 0){
            animator.SetBool("Walking", true);
        }
        else{
            animator.SetBool("Walking", false);
        }

        if (xInput > 0 && !facingRight){
            Flip();
        }

        if (xInput < 0 && facingRight){
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    Debug.Log("Player Dead");
                    break;
                }

            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
        }
    }

    void Flip()
    { 
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}

