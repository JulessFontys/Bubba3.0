using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour {

    public float Speed = 5f;
    public float JumpHeight = 0;
    //public float maxJumpHeight = 3f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private Rigidbody2D _body;
    private Vector2 _inputs = Vector2.zero;
    private bool spaceKeyDown = false;
    private bool isGrounded = false;



    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
            
        }
    }

    void Update()
    {
        Debug.Log(isGrounded);
        Debug.Log(JumpHeight);
        _inputs.x = 0;
        _inputs.y = 0;


       if (Input.GetButtonDown("Jump")) {
             spaceKeyDown = true;
            
        }
        
        if (Input.GetAxis("Horizontal") > 0f)
        {
            _inputs.x = Speed;

        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            _inputs.x = -Speed;
 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Fire();
        }
        JumpData();
    }

    void JumpData()
    {
        if (isGrounded == true)
        {
            if (spaceKeyDown == true)
            {
                spaceKeyDown = false;
                JumpHeight = 1500f;
             

            }
              else { JumpHeight = 0; }
        }
        else
        {
            JumpHeight = 0;
            spaceKeyDown = false;
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        if (Input.GetAxis("Horizontal") > 0f)
        {
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 200;

        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -200;

        }
        else
        {
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 200;
        }
        
        Destroy(bullet, 100f);
    }


    void FixedUpdate()
    {
        _body.velocity = _inputs;
        transform.Translate(Vector2.up * JumpHeight * Time.smoothDeltaTime); 
    }
}
