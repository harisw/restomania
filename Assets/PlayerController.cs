using System;
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
        InteractWithMovement();
        InteractWithObject();
        UpdateAnimator();
    }

    private void InteractWithObject()
    {
        if (Input.GetKeyDown("space"))
        {
            // Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
            Vector3 source = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            // Debug.DrawRay(source, forward, Color.white);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(source, transform.forward, 100.0f);
            print("spacing");
            for (int i = 0; i < hits.Length; i++)
            {
                // RaycastHit hit = hits[i];
                ItemsBox hitBox = hits[i].transform.GetComponent<ItemsBox>();
                print("hits "+ hits[i]);
                
                if (hitBox != null) {
                    print("Hitting item");
                    if (hitBox.hasStock()) {
                        Vector3 playerPos = transform.position;
                        Vector3 playerDirection = transform.forward;
                        Quaternion playerRotation = transform.rotation;

                        float spawnDist = 0.5f;
                        Vector3 spawnPos = playerPos + playerDirection * spawnDist;

                        GameObject takenItem = Instantiate(hitBox.getItem(), spawnPos, Quaternion.identity, transform);
                        // Vector3 itemTransform = new Vector3(takenItem.transform.position.x - 0.04f, takenItem.transform.position.y + 0.8f, takenItem.transform.position.z + 0.5f);

                        // 33 47 34
                        takenItem.transform.position = new Vector3(takenItem.transform.position.x, takenItem.transform.position.y + 0.8f, takenItem.transform.position.z);
                        // takenItem.transform.localScale = new Vector3(33, 47, 34);
                    }
                    return;
                }
                // Renderer rend = hit.transform.GetComponent<Renderer>();

                // if (rend)
                // {
                //     // Change the material of all hit colliders
                //     // to use a transparent shader.
                //     rend.material.shader = Shader.Find("Transparent/Diffuse");
                //     Color tempColor = rend.material.color;
                //     tempColor.a = 0.3F;
                //     rend.material.color = tempColor;
                // }
            }
        }
    }

    void UpdateAnimator()
    {
        float speed = RB3D.velocity.magnitude;
        GetComponent<Animator>().SetFloat("velocity", speed);
    }
    // // Update is called once per frame
    // void FixedUpdate()
    // {
    // }

    private void InteractWithMovement()
    {
        float moveX = 0;
        float moveZ = 0;
        if (Input.GetKey("w"))
            moveZ = 1;
        else if (Input.GetKey("s"))
            moveZ = -1;

        if (Input.GetKey("a"))
            moveX = -1;
        else if (Input.GetKey("d"))
            moveX = 1;

        if (moveX != 0 || moveZ != 0)
        {
            Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
            Vector3 lookDirection = moveDirection + transform.position;
            transform.LookAt(lookDirection);
        }
        RB3D.AddForce(moveX * moveSpeed, 0, moveZ * moveSpeed);
    }
}