﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    CharacterController controller = GetComponent<CharacterController>();
	    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	    moveDirection = transform.TransformDirection(moveDirection);
	    moveDirection *= speed;
	    controller.Move(moveDirection * Time.deltaTime);
    }
}
