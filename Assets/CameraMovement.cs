using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;//the target object
    private float speedMod = 10.0f;//a speed modifier

    private float desiredRot;
    public float rotSpeed = 0.0000025F;

    void Start()
    {

    }

    void Update()
    {
        var point = this.target.position;//get target's coords
        this.transform.LookAt(point);//makes the camera look to it
                                //makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        if (Math.Abs(this.desiredRot) < 0.0000000001)
        {
            if (Input.GetKey(KeyCode.Q))
                this.desiredRot = 90;
            if (Input.GetKey(KeyCode.E))
                this.desiredRot = -90;

        }

        if (Math.Abs(this.desiredRot) > 0.0000000001)
        {
            print(Time.deltaTime);
            var rotationDelta = Time.deltaTime * this.rotSpeed;
            if (rotationDelta > Math.Abs(this.desiredRot))
                rotationDelta = Math.Abs(this.desiredRot);
            if (this.desiredRot < 0)
                rotationDelta *= -1;
            this.desiredRot -= rotationDelta;
            print(string.Format("Rotation left: {0}, rotation now: {1}", this.desiredRot, rotationDelta));

            this.transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), rotationDelta);
        }

    }
}
