using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Gather : MonoBehaviour
{
    public float radius;
    public float force=1f;

    ObiSolver solver;
    ObiEmitter emitter;

    Vector4 center;
    bool _split = false;

    //bool[] _killingParticles;
    int _solverindex;

    private void Awake()
    {
        solver = GetComponent<ObiSolver>();
        emitter = GameObject.Find("Obi Emitter").GetComponent<ObiEmitter>();
    }
    private void FixedUpdate()
    {
        if (!_split) GatherOne(solver, emitter);
        else
            GatherTwo(solver, emitter);
    }
    void GatherOne(ObiSolver solver, ObiEmitter emitter)
    {
        center = Center.ActiveCenter(solver, emitter);
        for (int i = 0; i < emitter.activeParticleCount; i++)
        {
            _solverindex = emitter.solverIndices[i];
            if (Vector4.Distance(solver.positions[_solverindex], center) > radius)
            {
                AddForce.Accelerate(solver, _solverindex, force, (center - solver.positions[_solverindex]));
            }
        }//*/
    }
    void GatherTwo(ObiSolver solver,ObiEmitter emitter)
    {
        Vector4 center1 = Center.ActiveCenterFormer(solver, emitter);
        Vector4 center2 = Center.ActiveCenterLatter(solver, emitter);
        //Debug.Log("1:" + center1 + "2:" + center2);
        if (Vector4.Distance(center1, center2) < 5)
        {
            Vector4 center = Center.ActiveCenter(solver, emitter);

            for (int i = 0; i < solver.positions.count / 2; i++) 
            { AddForce.Accelerate(solver, i, 3*force, new Vector4(1, 0, 0, 0)); }
            for (int i = solver.positions.count/2; i < solver.positions.count; i++) AddForce.Accelerate(solver, i,3*force, new Vector4(-1,0,0,0));
        }
        for (int i = 0; i < emitter.activeParticleCount; i++)
        {
            _solverindex = emitter.solverIndices[i];
            if (_solverindex<solver.positions.count/2 && Vector4.Distance(solver.positions[_solverindex], center1) > radius)
            {
                AddForce.Accelerate(solver, _solverindex, force, (center1 - solver.positions[_solverindex]));
            }
            if(_solverindex < solver.positions.count / 2 && Vector4.Distance(solver.positions[_solverindex], center2) < radius)
            {
                AddForce.Accelerate(solver, _solverindex, 2*force, (solver.positions[_solverindex]-center2));
            }
            if (_solverindex >= solver.positions.count / 2 && Vector4.Distance(solver.positions[_solverindex], center2) > radius)
            {
                AddForce.Accelerate(solver, _solverindex, force, (center2 - solver.positions[_solverindex]));
            }
            if (_solverindex >= solver.positions.count / 2 && Vector4.Distance(solver.positions[_solverindex], center1) < radius)
            {
                AddForce.Accelerate(solver, _solverindex, force, (solver.positions[_solverindex])-center1);
            }
        }//*/
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _split = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            _split = false;
        }
    }
}
