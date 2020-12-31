using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class ColorWater : MonoBehaviour
{
    public float minRadius;
    public float mediumRadius;
    public float maxRadius;
    public bool ifcolor=true;
    public bool ifsplit = true;
    ObiSolver solver;
    ObiEmitter emitter;

    Vector4 center;
    Vector4 centerPlain;

    int _solverindex;

    private void Awake()
    {
        solver = GetComponent<ObiSolver>();
        emitter = GameObject.Find("Obi Emitter").GetComponent<ObiEmitter>();
    }

    private void FixedUpdate()
    {
        center = Center.ActiveCenter(solver, emitter);
        centerPlain = new Vector4(center.x, 3.6f, center.z, 0);
        if (ifcolor)
        {   
            //center = Center.CenterCalculateObi(solver.positions);
            for (int i = 0; i < emitter.activeParticleCount; i++)
            {
                _solverindex = emitter.solverIndices[i];
                if (Vector4.Distance(solver.positions[_solverindex], centerPlain) > minRadius)
                {
                    solver.colors[_solverindex] = Color.black;
                }
                else
                {
                    solver.colors[_solverindex] = Color.white;

                }
            }
        }//*/
        if (ifsplit)
        {
            //center = Center.CenterCalculateObi(solver.positions);
            for (int i = 0; i < emitter.activeParticleCount; i++)
            {
                _solverindex = emitter.solverIndices[i];
                if (_solverindex<solver.positions.count/2)
                {
                    solver.colors[_solverindex] = Color.black;
                }
                else
                {
                    solver.colors[_solverindex] = Color.white;

                }
            }
        }//*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(centerPlain, minRadius);
        Gizmos.DrawWireSphere(centerPlain, mediumRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centerPlain, maxRadius);
    }//*/
}
