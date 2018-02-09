using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigation : MonoBehaviour
{
    [HideInInspector]
    public GameObject _canvas;

    private Camera _camera;
    public float moveSpeed = 1f;
    [HideInInspector]
    public Transform Target;
    private Vector3 offset;

    void Start()
    {
        _canvas = GameObject.Find("Canvas");
        _camera = GetComponent<Camera>();
        RaycastHit RayHit;
        _canvas.SetActive(false);
        if (Physics.Raycast(_camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2)), out RayHit))
        {
            offset = transform.position - RayHit.point;
            Target = RayHit.transform;
        }
        _canvas.SetActive(true);
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Target.position + offset, moveSpeed);
        transform.position = Vector3.Lerp(transform.position, Target.position + offset, moveSpeed * Time.deltaTime);
    }

    public void ChangeTarget(Transform newTarget)
    {
        Target = newTarget;
    }
}
