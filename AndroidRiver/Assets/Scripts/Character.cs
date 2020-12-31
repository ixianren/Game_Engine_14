using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class Character: MonoBehaviour
{
    public ObiSolver solver;

    ObiEmitter emitter;

    Vector4 _center;
    Vector3 _gravity;
    Vector2 _gravityPlain;
    float _gravityMagnitude;
    float _currentPitch=-30f;
    float _currentYaw;
    float _cos;
    float _acos;
    Vector3 _currentEulerAngles;
    Vector3 _originEulerAngles;
    Quaternion _currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        solver = GameObject.Find("Obi Solver").GetComponent<ObiSolver>();
        emitter = GameObject.Find("Obi Emitter").GetComponent<ObiEmitter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _gravity = solver.parameters.gravity;
        _gravityPlain = new Vector2(_gravity.x, _gravity.z);
        _gravityMagnitude = _gravityPlain.magnitude;
        if (_gravityMagnitude <= 1) _currentPitch = 30f * _gravityMagnitude - 60f;
        else _currentPitch = 3.07f * _gravityMagnitude - 29.9768f;
        _gravityPlain = _gravityPlain.normalized;
        _cos = _gravityPlain.y;
        _acos = 180f * Mathf.Acos(_cos) / Mathf.PI;
        if (emitter.activeParticleCount > 0)
        {
            _center = Center.ActiveCenter(solver, emitter);
            this.transform.position = new Vector3(_center.x, _center.y, _center.z);
            _originEulerAngles = this.transform.rotation.eulerAngles;
            _currentYaw = _gravityPlain.x >= 0 ? _acos : -_acos;
            _currentEulerAngles = new Vector3(_currentPitch, _currentYaw, _originEulerAngles.z);
            _currentRotation.eulerAngles = _currentEulerAngles;
            this.transform.rotation = _currentRotation;
        }
    }
}
