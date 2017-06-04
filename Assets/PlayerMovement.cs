using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0F;

    public CameraMovement Camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    CharacterController controller = this.GetComponent<CharacterController>();
	    switch (this.Camera.CameraOrientation)
	    {
	        case CameraMovement.CameraOrientationEnum.North:
	            this.moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	            break;
            case CameraMovement.CameraOrientationEnum.West:
	            this.moveDirection = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
	            break;
	        case CameraMovement.CameraOrientationEnum.South:
	            this.moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
	            break;
	        case CameraMovement.CameraOrientationEnum.East:
	            this.moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
	            break;
	    }
	    this.moveDirection = this.transform.TransformDirection(this.moveDirection);
	    this.moveDirection *= this.speed;
	    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
	        this.moveDirection *= 2F;
	    controller.Move(this.moveDirection * Time.deltaTime);
    }
}
