using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class DesertManager : MonoBehaviour
{
    ObiSolver solver;

    ObiCollider group1;
    ObiCollider group2;
    ObiCollider group3;
    ObiCollider group4;

    public AnimPlay[] group1Anim;
    public AnimPlay[] group2Anim;
    public AnimPlay[] group3Anim;
    public AnimPlay[] group4Anim;

    bool stormOpen1 = true;
    bool stormOpen2 = true;
    GameObject StormGroup1;
    GameObject StormGroup2;

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
        StormGroup1 = GameObject.Find("StormGroup1");
        StormGroup2 = GameObject.Find("StormGroup2");
        group1= group1 = GameObject.Find("group1").GetComponent<ObiCollider>();
        group2 = group2 = GameObject.Find("group2").GetComponent<ObiCollider>();
        group3 = group3 = GameObject.Find("group3").GetComponent<ObiCollider>();
        solver.OnCollision += Solver_OnCollision;
    }
    private void Solver_OnCollision(ObiSolver solver,ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach(Oni.Contact contact in e.contacts)
        {
            if (contact.distance < 0.01)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (col == group1 && group1Particles.Add(contact.particle))
                {
                    for(int i = 0; i < group1Anim.Length; i++)
                    {
                        group1Anim[i].HP--;
                    }
                    if (group1Anim[0].HP == 1)
                    {
                        RemainTrees--;
                      
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

                    }
                }
                if (col == group3 && group3Particles.Add(contact.particle))
                {
                    for (int i = 0; i < group1Anim.Length; i++)
                    {
                        group3Anim[i].HP--;
                    }
                    if (group3Anim[0].HP == 1)
                    {
                        RemainTrees--;

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

                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
