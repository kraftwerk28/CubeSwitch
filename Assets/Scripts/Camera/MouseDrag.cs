using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour
{
    public Slider MouseSensitivitySlider;
    public Slider KeySensitivitySlider;


    private float dragSensitivity = 1f;

    private float Deltakoef = 0.005f;
    private float Delta = 1;
    private float MoveSpeed = 10;

    private Camera cam;
    public Vector3 Target;
    // private Vector3 Rtl, Rtr, Rdl, Rdr;
    private RaycastHit rh;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();

        // Rdl = new Vector3(0, 0);
        // Rtl = new Vector3(0, cam.pixelHeight);
        // Rdr = new Vector3(cam.pixelWidth, 0);
        // Rtr = new Vector3(cam.pixelWidth, cam.pixelHeight);

        Target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // dragSensitivity = MouseSensitivitySlider.value;

        transform.position = Vector3.Lerp(transform.position, Target, MoveSpeed);

        //KeyNav
        // Target -= Delta * KeySensitivitySlider.value * (Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical"));

        //zoom
        // if (cam.orthographic)
        // {
        // 	cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 100 * Delta;
        // 	cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1, 60);
        // 	Target.y = 100;
        // }
        // else
        // 	Target += transform.forward * Input.GetAxis("Mouse ScrollWheel") * 100;

        //if (Physics.Raycast(cam.ScreenPointToRay(new Vector3(cam.pixelWidth, cam.pixelHeight)), out rh))
        //{
        //	Delta = rh.distance * Deltakoef;
        //}
        // Delta = transform.position.y * Deltakoef;

        // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 5, Mathf.Infinity), transform.position.z);

        //MouseNav
        if (Input.GetMouseButton(0))
        {
            Target += dragSensitivity * ((Vector3.forward + Vector3.right) * -Input.GetAxis("Mouse Y") + (Vector3.forward - Vector3.right) * Input.GetAxis("Mouse X"));
        }

    }
    void OnEnable()
    {
        Target = transform.position;
    }
}
