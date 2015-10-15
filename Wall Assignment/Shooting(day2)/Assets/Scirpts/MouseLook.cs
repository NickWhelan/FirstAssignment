using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
    float sensitivity;
    float angle;
    void Start() {
        sensitivity = 10;
    }
    // Update is called once per frame
    void Update () {
        float rotateSpeedY = -1*(Input.GetAxis("Mouse Y") * sensitivity);
        angle = transform.eulerAngles.x;
        if (angle > 270)
            angle = transform.eulerAngles.x - 360;
        if (angle < 30 && angle > -60)
            transform.Rotate(rotateSpeedY, 0, 0);

        else if(angle >= 30 && rotateSpeedY < 0)
            transform.Rotate(rotateSpeedY, 0, 0);
        else if (angle <= -60 && rotateSpeedY > 0)
            transform.Rotate(rotateSpeedY, 0, 0);

    }
}
