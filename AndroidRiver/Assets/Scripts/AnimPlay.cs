using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class AnimPlay : MonoBehaviour
{
    Animator anim;
    public string clip;
    private float hp;
    public float HP
    {
        get { return hp; }
        set {
            if (value < 0) hp = 0;
            else hp = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
        HP = 50f;
    }
    private void Update()
    {
        anim.Play(clip, 0, (50 - HP)/50);
    }
}
