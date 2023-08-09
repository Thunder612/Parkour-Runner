using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float cameraSensitivity;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //Get X position of mouse and rotate the target
        target.Rotate(0, Input.GetAxis("Mouse X") * cameraSensitivity, 0);


        //Get Y position of mouse and rotate pivot
        pivot.Rotate(Input.GetAxis("Mouse Y") * cameraSensitivity, 0, 0);


        //Limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > 60f && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(60f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 320f)
        {
            pivot.rotation = Quaternion.Euler(320f, 0, 0);
        }

        //Move camera based on the rotation of the target
        Quaternion rotation = Quaternion.Euler(-pivot.eulerAngles.x, target.eulerAngles.y, 0);
        transform.position = target.position - (rotation * offset);


        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .4f, transform.position.z);
        }
        
        transform.LookAt(target.transform);
    }
}
