using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RockMove : MonoBehaviour
{
    ObiSolver solver;

    Vector4 velocity;

    new Rigidbody rigidbody;
    new ObiCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        solver = GameObject.Find("Obi Solver").GetComponent<ObiSolver>();
        collider = GetComponent<ObiCollider>();
        rigidbody = GetComponent<Rigidbody>();
        solver.OnCollision += Solver_OnCollision;
    }

    // Update is called once per frame
    private void Solver_OnCollision(ObiSolver s, ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach (Oni.Contact contact in e.contacts)
        {
            if (contact.distance < 0.01f)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (col == collider)
                {
                    velocity += solver.velocities[contact.particle];
                    solver.velocities[contact.particle] = -solver.velocities[contact.particle];
                    rigidbody.velocity = velocity/100;
                }
            }
        }

    }
}