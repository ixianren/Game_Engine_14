using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Dinimish : MonoBehaviour
{
    public ObiSolver solver;
    public ObiEmitter emitter;
    public ObiCollider sandCollider;
    public float maxTime=3f;
    public ObiFluidEmitterBlueprint blueprint;
    float[] _particleTime;
    uint _particleNum;
    new public Camera camera;
    Vector3 center;
    float _xposition;
    float _zposition;
    public Color color;

    HashSet<int> finishedParticles = new HashSet<int>();

    // Start is called before the first frame update
    void Awake()
    {
        solver.OnCollision += Solver_OnCollision;
        _particleNum = blueprint.capacity;
        _particleTime = new float[_particleNum];
        sandCollider = GetComponent<ObiCollider>();
        for(int i = 0; i < _particleNum; i++)
        {
            _particleTime[i] = 0f;
        }
    }

    private void Start()
    {
        center = new Vector3(0, 0, 0);
    }
    void Solver_OnCollision (object sender,ObiSolver.ObiCollisionEventArgs e)
    {
        var colliderWorld = ObiColliderWorld.GetInstance();

        for(int i = 0; i < e.contacts.Count; ++i)
        {
            if (e.contacts.Data[i].distance < 0.01f)
            {
                var col = colliderWorld.colliderHandles[e.contacts.Data[i].other].owner;
                if (col !=null)
                {
                    int solverindex = e.contacts.Data[i].particle;
                    int emitterindex = solver.particleToActor[e.contacts.Data[i].particle].indexInActor;
                    if (col == sandCollider)
                    {
                        _particleTime[solverindex] += Time.fixedDeltaTime;
                        if (_particleTime[solverindex] >= 3f && solverindex<_particleNum-1)
                        {
                            emitter.KillParticle(emitterindex);
                        }
                    }
                    else
                    {
                        _particleTime[solverindex] = 0f;
                    }
                }
            }
        }
    }
    private void OnDestroy()
    {
        solver.OnCollision -=Solver_OnCollision;
    }


    // Update is called once per frame
    void Update()
    {
        float x_total=0;
        float z_total=0;

        for(int i = 0; i< _particleNum; i++)
        {
            if (emitter.IsParticleActive(solver.particleToActor[i].indexInActor))
            {
                x_total += solver.positions[i].x;
                z_total += solver.positions[i].z;
            }
        }
        _xposition = x_total / emitter.activeParticleCount;
        _zposition = z_total / emitter.activeParticleCount;
    }
    private void LateUpdate()
    {
        camera.transform.position = new Vector3(_xposition, camera.transform.position.y, _zposition);
    }
}

