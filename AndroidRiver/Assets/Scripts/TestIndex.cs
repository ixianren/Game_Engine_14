using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
public class TestIndex : MonoBehaviour
{
    ObiSolver Solver;
    ObiEmitter Emitter;

    int _particleNum;

    private void Awake()
    {
        Solver = GetComponent<ObiSolver>();
        Emitter = GetComponentInChildren<ObiEmitter>();
        _particleNum = Emitter.particleCount;
    }
    private void Start()
    {
        StartCoroutine(Value());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Emitter.KillParticle(999);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Solver.positions[999]);
        }
    }
    IEnumerator Value()
    {
        yield return new WaitForSeconds(3f);
        //Solver.userData[49] = new Vector4(1, 0, 0, 0);
    }
}
