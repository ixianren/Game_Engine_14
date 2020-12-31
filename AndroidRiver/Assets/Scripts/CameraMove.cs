using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject water;
    Vector3 _currentPosition;
    Vector3 _originPosition;
    Vector3 _waterCurrentPosition;
    Vector3 _waterOriginPosition;
    Vector3 _currentEuler;
    Vector3 _originEuler;
    
    // Start is called before the first frame update
    void Start()
    {
        water = GameObject.Find("water");
        _waterOriginPosition = water.transform.position;
        _originPosition = this.transform.position;
        _originEuler = this.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        _waterCurrentPosition = water.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        _currentPosition = new Vector3(_originPosition.x-_waterOriginPosition.x+_waterCurrentPosition.x, _originPosition.y, _originPosition.z - _waterOriginPosition.z + _waterCurrentPosition.z);
        this.transform.position = _currentPosition;
    }
}
