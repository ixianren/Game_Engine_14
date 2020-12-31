using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class AddForce : MonoBehaviour
{
    public static void Accelerate(ObiSolver solver,int solverindex,float acceler,Vector4 orientation)
    {
        solver.velocities[solverindex] += orientation.normalized*acceler*Time.fixedDeltaTime;
    }
    public static void Constant(ObiSolver solver, int solverindex, float acceler, Vector4 orientation)
    {
        solver.positions[solverindex] += orientation.normalized * acceler * Time.fixedDeltaTime;
    }
}
