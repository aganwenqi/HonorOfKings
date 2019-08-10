using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Rotate1 : MonoBehaviour {

    public float xSpeed;
    public float ySpeed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -xSpeed * Time.deltaTime,Space.World);
                    transform.Rotate(Vector3.forward * Input.GetAxis("Mouse Y") * -ySpeed * Time.deltaTime, Space.World);
                }
            }
        }
    }
}
