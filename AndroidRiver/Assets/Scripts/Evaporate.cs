using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Evaporate : MonoBehaviour
{
    ObiSolver solver;
    ObiEmitter emitter;
    Vector4 center;
    Vector4 centerPlain;
    int _solverindex;

    public float radius = 3;
    public bool automate = true;
    // Start is called before the first frame update
    void Start()
    {
        solver = GetComponent<ObiSolver>();
        emitter = GameObject.Find("Obi Emitter").GetComponent<ObiEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            emitter.KillParticle(0);
        }
    }
    private void FixedUpdate()
    {
        if (automate)
        {
            //center = Center.CenterCalculateObi(solver.positions);
            center = Center.ActiveCenter(solver, emitter);
            centerPlain = new Vector4(center.x, 3.6f, center.z, 0);
            for (int i = 0; i < emitter.activeParticleCount; i++)
            {
                _solverindex = emitter.solverIndices[i];
                if (Vector4.Distance(solver.positions[_solverindex], centerPlain) > radius)
                {
                    emitter.KillParticle(i);
                }
            }
        }//*/
    }
}
