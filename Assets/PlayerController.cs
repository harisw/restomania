using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame upRdate

    public Rigidbody RB3D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        float speed = RB3D.velocity.magnitude;
        print("Speed: " + speed);
        GetComponent<Animator>().SetFloat("velocity", speed);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey("w"))
            moveZ = 1;
        else if(Input.GetKey("s"))
            moveZ = -1;

        if (Input.GetKey("a"))
            moveX = -1;
        else if (Input.GetKey("d"))
            moveX = 1;

        // if (Input.GetKey("a"))
        // {
        //     RB3D.AddForce(-moveSpeed, 0, 0);
        // }

        // if (Input.GetKey("d"))
        // {
        //     RB3D.AddForce(moveSpeed, 0, 0);
        // }

        // if (Input.GetKey("s"))
        // {
        //     RB3D.AddForce(0, 0, -moveSpeed);
        // }
        if (moveX != 0 || moveZ != 0)
        {
            Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
            Vector3 lookDirection = moveDirection + transform.position;
            transform.LookAt(lookDirection);
        }
        RB3D.AddForce(moveX*moveSpeed, 0, moveZ*moveSpeed);
    }
}
