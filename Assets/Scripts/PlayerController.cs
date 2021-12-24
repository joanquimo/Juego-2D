using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1f;
    private float jumpForce = 150f;
    
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        
        Debug.DrawRay(transform.position, Vector3.down * 0.16f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.16f))
        {
            Grounded = true;
        }else
        {
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W)  && Grounded)
        {
            Jump();
        }
        
    }
    private void Jump()
    {
        //Hace Saltar al ojeto 
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
    
    
    private void FixedUpdate()
    {
        //movimiento horizontal del objeto
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y * speed);
    }
}
