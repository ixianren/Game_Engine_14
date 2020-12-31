using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Wind : MonoBehaviour
{
    public ObiSolver solver;

    public Vector4 orientation;
    public float acceler;

    new private ObiCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        solver = GameObject.Find("Obi Solver").GetComponent<ObiSolver>();
        solver.OnCollision += Solver_OnCollision;
        collider = GetComponent<ObiCollider>();
    }

    // Update is called once per frame
    void Solver_OnCollision (object sender, ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach(Oni.Contact contact in e.contacts)
        {
            if (contact.distance < 0.01)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (col == collider)
                {
                    AddForce.Accelerate(solver,contact.particle, acceler, orientation);
                }
            }
        }
    }
}
