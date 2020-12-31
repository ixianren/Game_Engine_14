using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using Obi;
using UnityEngine.UI;

public class Accelerator : MonoBehaviour
{
	ObiSolver _obisolver;
	float _xangle=0;
	float _yangle=-90;
	float _zangle=0;
	float _speed = 5f;
	float _xAngle;
	float _yAngle;
	float _zAngle;

	Vector3 dir = Vector3.zero;
	Vector3 _dir = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
		_obisolver = GetComponent<ObiSolver>();
	}
    // Update is called once per frame
    void Update()
    {
		dir.z = Input.acceleration.y;
		dir.x = Input.acceleration.x;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			//向上转
			if (_xangle <= 90)
			{
				_xangle += Time.deltaTime * 30;
			}
			else _xangle = 90;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//向下转
			if (_xangle >= -90)
			{
				_xangle -= Time.deltaTime * 30;
			}
			else _xangle = -90;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//向左转
			if (_zangle <= 90)
			{
				_zangle += Time.deltaTime * 30;
			}
			else _zangle = 90;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			//向右转
			if (_zangle >= -90)
			{
				_zangle -= Time.deltaTime * 30;
			}
			else _zangle = -90;
		}//*/
		if (Input.GetKey(KeyCode.Space))
        {
			_xangle = 0;
			_yangle = -90;
			_zangle = 0;
        }
		_xAngle = _speed * (float)Math.Sin(_xangle * Math.PI / 180);
		_yAngle = _speed * (float)Math.Sin(_yangle * Math.PI / 180);
		_zAngle = _speed * (float)Math.Sin(_zangle * Math.PI / 180);
		_dir = _speed * dir;
		_obisolver.parameters = new Oni.SolverParameters(Oni.SolverParameters.Interpolation.None, new Vector4(_xAngle,_yAngle, _zAngle, 0));
		//_obisolver.parameters = new Oni.SolverParameters(Oni.SolverParameters.Interpolation.None, new Vector4(_dir.x, _dir.y, _dir.z, 0));
		_obisolver.PushSolverParameters();
	}
}
