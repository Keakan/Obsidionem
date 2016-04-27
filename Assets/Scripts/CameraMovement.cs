using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 zoom = Vector3.zero;
    public GameObject crystal;
    public int zoomNum;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //input types
        zoom = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
        zoom = transform.TransformDirection(zoom);
        //Zooming code
        if ((!(zoomNum > 2)))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                controller.Move(zoom * speed);
                zoomNum++;
            }
        }
        if ((!(zoomNum < -4)))
        { 
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                controller.Move(zoom * speed);
                zoomNum--;
            }
        }
        //Vertical Rotate code
        //if (Input.GetButton("Vertical"))
        //{
        //    if (Input.GetAxis("Vertical") > 0)
        //    {
        //        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * 45);
        //    }
        //    if (Input.GetAxis("Vertical") < 0)
        //    {
        //        transform.RotateAround(Vector3.zero, Vector3.left, Time.deltaTime * 45);
        //    }
        //}
        //Horizontal Rotate code
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * 45);
                //transform.RotateAround(Vector3.zero, Vector3.back, Time.deltaTime * 45);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.RotateAround(Vector3.zero, Vector3.down, Time.deltaTime * 45);
                //transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 45);
            }
        }
    }
    public void CenterPosition()
    {
        transform.position = new Vector3(0, 20, -1);
        transform.eulerAngles = new Vector3(90, 0, 0);
        crystal.SetActive(false);
        zoomNum = 0;
    }
    public void WhitePosition()
    {
        transform.position = new Vector3(0, 15, -14);
        transform.eulerAngles = new Vector3(55, 0, 0);
        crystal.SetActive(true);
        zoomNum = 0;
    }
    public void BlackPosition()
    {
        transform.position = new Vector3(0, 15, 14);
        transform.eulerAngles = new Vector3(55, 180, 0);
        crystal.SetActive(true);
        zoomNum = 0;
    }
}