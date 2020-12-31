using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Center : MonoBehaviour
{
    public static Vector4 CenterCalculate(List<Vector4> list)
    {
        int length = list.Count;
        float xAccumu = 0;
        float yAccumu = 0;
        float zAccumy = 0;
        for(int i = 0; i < length; i++)
        {
            xAccumu += list[i].x;
            yAccumu += list[i].y;
            zAccumy += list[i].z;
        }
        return new Vector4(xAccumu / length, yAccumu / length, zAccumy / length,0);
    }
    public static Vector4 CenterCalculateObi(ObiNativeVector4List list)
    {
        int length = list.count;
        float xAccumu = 0;
        float yAccumu = 0;
        float zAccumy = 0;
        for (int i = 0; i < length; i++)
        {
            xAccumu += list[i].x;
            yAccumu += list[i].y;
            zAccumy += list[i].z;
        }
        return new Vector4(xAccumu / length, yAccumu / length, zAccumy / length, 0);
    }
    public static Vector4 ActiveCenter(ObiSolver solver,ObiEmitter emitter)
    {
        ObiNativeVector4List list = solver.positions;
        int count = 0;
        int length = list.count;
        float xAccumu = 0;
        float yAccumu = 0;
        float zAccumy = 0;
        for (int i = 0; i < length; i++)
        {
            if (emitter.IsParticleActive(solver.particleToActor[i].indexInActor))
            {
                xAccumu += list[i].x;
                yAccumu += list[i].y;
                zAccumy += list[i].z;
                count++;
            }
        }
        return new Vector4(xAccumu / count, yAccumu / count, zAccumy / count, 0);
    }
    public static Vector4 ActiveCenterFormer(ObiSolver solver, ObiEmitter emitter)
    {
        ObiNativeVector4List list = solver.positions;
        int count = 0;
        int length = list.count;
        float xAccumu = 0;
        float yAccumu = 0;
        float zAccumy = 0;
        for (int i = 0; i < length/2; i++)
        {
            if (emitter.IsParticleActive(solver.particleToActor[i].indexInActor))
            {
                xAccumu += list[i].x;
                yAccumu += list[i].y;
                zAccumy += list[i].z;
                count++;
            }
        }
        return new Vector4(xAccumu / count, yAccumu / count, zAccumy / count, 0);
    }
    public static Vector4 ActiveCenterLatter(ObiSolver solver, ObiEmitter emitter)
    {
        ObiNativeVector4List list = solver.positions;
        int count = 0;
        int length = list.count;
        float xAccumu = 0;
        float yAccumu = 0;
        float zAccumy = 0;
        for (int i = length/2; i < length; i++)
        {
            if (emitter.IsParticleActive(solver.particleToActor[i].indexInActor))
            {
                xAccumu += list[i].x;
                yAccumu += list[i].y;
                zAccumy += list[i].z;
                count++;
            }
        }
        return new Vector4(xAccumu / count, yAccumu / count, zAccumy / count, 0);
    }
    public static Vector4 ActiveVelocity(ObiSolver solver, ObiEmitter emitter)
    {
        ObiNativeVector4List list = solver.velocities;
        Vector4 velocity = new Vector4(0, 0, 0, 0);
        for(int i = 0; i < list.count;i++)
        {
            if (emitter.IsParticleActive(solver.particleToActor[i].indexInActor))
            {
                velocity += list[i];
            }
        }
        return velocity;
    }
}
