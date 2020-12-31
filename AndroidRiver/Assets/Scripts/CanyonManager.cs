using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CanyonManager : MonoBehaviour
{
    ObiSolver solver;

    ObiCollider windzone1;
    ObiCollider windzone2;
    ObiCollider windzone3;
    ObiCollider windzone4;

    public GameObject[] winds;

    ObiCollider group1;
    ObiCollider group2;
    ObiCollider group3;
    ObiCollider group4;

    public AnimPlay[] group1Anim;
    public AnimPlay[] group2Anim;
    public AnimPlay[] group3Anim;
    public AnimPlay[] group4Anim;

    bool windOpen1 = true;
    bool windOpen2 = true;
    bool windOpen3 = true;
    bool windOpen4 = true;
    private static int remainTrees;
    public static int RemainTrees { get; set; }

    HashSet<int> group1Particles = new HashSet<int>();
    HashSet<int> group2Particles = new HashSet<int>();
    HashSet<int> group3Particles = new HashSet<int>();
    HashSet<int> group4Particles = new HashSet<int>();
    // Start is called before the first frame update
    void Start()
    {
        solver = GameObject.Find("Obi Solver").GetComponent<ObiSolver>();
        windzone1 = GameObject.Find("Windzone1").GetComponent<ObiCollider>();
        windzone2 = GameObject.Find("Windzone2").GetComponent<ObiCollider>();
        windzone3 = GameObject.Find("Windzone3").GetComponent<ObiCollider>();
        windzone4 = GameObject.Find("Windzone4").GetComponent<ObiCollider>();
        group1 = GameObject.Find("group1").GetComponent<ObiCollider>();
        group2 = GameObject.Find("group2").GetComponent<ObiCollider>();
        group3 = GameObject.Find("group3").GetComponent<ObiCollider>();
        group4 = GameObject.Find("group4").GetComponent<ObiCollider>();
        solver.OnCollision += Solver_OnCollision;

        RemainTrees = 4;
    }

    private void Solver_OnCollision(ObiSolver solver, ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach(Oni.Contact contact in e.contacts)
        {
            if (contact.distance < 0.01)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (col == windzone1)
                {
                    if(windOpen1)
                    AddForce.Accelerate(solver, contact.particle, 20, new Vector4(-1, 0, 0, 0));
                    //else AddForce.Accelerate(solver, contact.particle, 5, new Vector4(-1, 0, 0, 0));
                }
                if (col == windzone2)
                {
                    if(windOpen2)
                    AddForce.Accelerate(solver, contact.particle, 50, new Vector4(-1, 0, 10, 0));
                    //else AddForce.Accelerate(solver, contact.particle, 10, new Vector4(-1, 0, 10, 0));
                }
                if (col == windzone3)
                {
                    if(windOpen3)
                    AddForce.Accelerate(solver, contact.particle, 20, new Vector4(-1, 0, 0, 0));
                    //else AddForce.Accelerate(solver, contact.particle, 5, new Vector4(-1, 0, 0, 0));
                }
                if (col == windzone4)
                {
                    if (windOpen4)
                        AddForce.Accelerate(solver, contact.particle, 20, new Vector4(-5, 0, -1, 0));
                    //else AddForce.Accelerate(solver, contact.particle, 5, new Vector4(-5, 0, -1, 0));
                }
                if (col==group1 && group1Particles.Add(contact.particle))
                {
                    for (int i = 0; i < group1Anim.Length; i++)
                    {
                        group1Anim[i].HP--;
                    }
                    if (group1Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        windOpen1 = false;
                    }
                }
                if (col == group2 && group2Particles.Add(contact.particle))
                {
                    for (int i = 0; i < group2Anim.Length; i++)
                    {
                        group2Anim[i].HP--;
                    }
                    if (group2Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        windOpen2 = false;
                    }
                }
                if (col == group3 && group3Particles.Add(contact.particle))
                {
                    for (int i = 0; i < group3Anim.Length; i++)
                    {
                        group3Anim[i].HP--;
                    }
                    if (group3Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        windOpen3 = false;
                    }
                }
                if (col == group4 && group4Particles.Add(contact.particle))
                {
                    for (int i = 0; i < group4Anim.Length; i++)
                    {
                        group4Anim[i].HP--;
                    }
                    if (group4Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        windOpen4 = false;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!windOpen1)
        {
            Destroy(winds[0]);
        }
        if (!windOpen2)
        {
            Destroy(winds[1]);
        }
        if (!windOpen3)
        {
            Destroy(winds[2]);
        }
        if (!windOpen4)
        {
            Destroy(winds[3]);
        }
    }
}
