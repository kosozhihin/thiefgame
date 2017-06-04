using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;//the target object
    private float speedMod = 10.0f;//a speed modifier

    private float desiredRot;
    public float rotSpeed = 0.0000025F;

    public CameraOrientationEnum CameraOrientation = CameraOrientationEnum.North;

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
            if (Input.GetKey(KeyCode.E))
                this.desiredRot = 90;
            if (Input.GetKey(KeyCode.Q))
                this.desiredRot = -90;

        }

        if (Math.Abs(this.desiredRot) > 0.0000000001)
        {
            var rotationDelta = Time.deltaTime * this.rotSpeed;
            if (rotationDelta > Math.Abs(this.desiredRot))
                rotationDelta = Math.Abs(this.desiredRot);
            bool rotateClockwise = this.desiredRot > 0;
            if (!rotateClockwise)
                rotationDelta *= -1;
            this.desiredRot -= rotationDelta;
            if (Math.Abs(this.desiredRot) < 0.0000000001)
            {
                var orientationValues = (CameraOrientationEnum[]) Enum.GetValues(typeof(CameraOrientationEnum));
                var currentIndex = Array.FindIndex(orientationValues, value => value == this.CameraOrientation);
                if (rotateClockwise)
                {
                    currentIndex--;
                    if (currentIndex < 0)
                        currentIndex = orientationValues.Length - 1;
                }
                else
                {
                    currentIndex++;
                    if (currentIndex > orientationValues.Length - 1)
                        currentIndex = 0;
                }
                this.CameraOrientation = orientationValues[currentIndex];
                Debug.Log(this.CameraOrientation);
            }
            
            this.transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), rotationDelta);
        }
    }

    public enum CameraOrientationEnum
    {
        North,
        West,
        South,
        East
    }
}
