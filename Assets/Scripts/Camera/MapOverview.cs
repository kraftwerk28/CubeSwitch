using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOverview : MonoBehaviour
{
    public float zoomSpeed = 1f;
    public float overviewSize = 10f;

    private bool isOvervieew = false;
    private float currentOrthoSize;
    private float defOrthoSize;
    private Camera _camera;

    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
        defOrthoSize = _camera.orthographicSize;
        currentOrthoSize = _camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, currentOrthoSize, zoomSpeed);
    }

    public void ToggleOverview()
    {
        isOvervieew = !isOvervieew;
        if (isOvervieew)
        {
            GetComponent<MarkerControl>().enabled = false;
            GetComponent<MouseDrag>().enabled = true;
            currentOrthoSize = overviewSize;
        }
        else
        {
            GetComponent<MarkerControl>().enabled = true;
            GetComponent<MouseDrag>().enabled = false;
            currentOrthoSize = defOrthoSize;
        }

    }
}
