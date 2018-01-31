using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarkerControl : MonoBehaviour
{

    public GameObject TransmitSwitch;
    public GameObject[] Cubes;
    private int index = 0;

    public EventSystem es;
    public GameObject marker;
    private Camera _camera;
    private RaycastHit RayHit;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        GetComponent<CameraNavigation>().ChangeTarget(Cubes[0].transform);
        Cubes[0].GetComponent<CubeInterface>().Selection(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TransmitSwitch.SetActive(false);
            Cubes[index].GetComponent<CubeInterface>().Selection(false);
            if (index > Cubes.Length - 2) index = 0;
            else index++;
            Cubes[index].GetComponent<CubeInterface>().Selection(true);
            if (index == 2)
            {
                TransmitSwitch.SetActive(true);
            }
            GetComponent<CameraNavigation>().ChangeTarget(Cubes[index].transform);
        }
        if (!es.IsPointerOverGameObject() && Input.GetMouseButtonDown(0) && Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RayHit))
        {
            Instantiate(marker, RayHit.point, Quaternion.identity);
            Cubes[index].GetComponent<CubeInterface>().SetTarget(RayHit);
        }

    }
}
