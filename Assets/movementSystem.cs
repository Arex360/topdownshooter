﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class movementSystem : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector2 inputs;
    private Vector2 mouseInputs;

    private Ray ray;
    private RaycastHit hit;
    public float speed;
    public LayerMask mask;
    public GameObject Cam;
    public Joystick rotationJoystick;
    public Joystick movementJoystick;
    public float horizontalAxis;
    public float verticalAxis;
    public float y;
    public bool UIControl;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        y =0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity,mask)){
          //  Quaternion targetRotation = Quaternion.LookRotation(hit.point - this.transform.position);
            //targetRotation.x = targetRotation.z = 0f;
            //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
        movment();
        rotation();
    }
    private void movment(){
        inputs =  !UIControl? new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")): new Vector2(movementJoystick.Horizontal,movementJoystick.Vertical);
        rigidbody.velocity = new Vector3(inputs.x * speed * Time.fixedDeltaTime, 0 , inputs.y * speed * Time.fixedDeltaTime);
    }
    private void rotation(){
        horizontalAxis = rotationJoystick.Horizontal;
        verticalAxis = rotationJoystick.Vertical;
    }
}
