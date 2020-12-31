using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManament : MonoBehaviour
{
    ObiSolver solver;
    ObiEmitter emitter;

    ObiCollider group1;
    ObiCollider group2;
    ObiCollider group3;
    ObiCollider group4;
    ObiCollider group5;
    ObiCollider rock;

    Rigidbody _rigidbody;

    public AnimPlay[] group1Anim;
    public AnimPlay[] group2Anim;
    public AnimPlay[] group3Anim;
    public AnimPlay[] group4Anim;
    public AnimPlay[] group5Anim;

    public ParticleSystem[] particles;

    public AudioSource audioSource;
    public AudioSource audioSource_loop;
    public AudioSource audioSource_bgm;
    public AudioClip[] audioClips;

    public Text text;

    HashSet<int> group1Particles = new HashSet<int>();
    HashSet<int> group2Particles = new HashSet<int>();
    HashSet<int> group3Particles = new HashSet<int>();
    HashSet<int> group4Particles = new HashSet<int>();
    HashSet<int> group5Particles = new HashSet<int>();

    Vector4 velocity;
    // Start is called before the first frame update

    private static int remainTrees;
    public static int RemainTrees
    {
        get { return remainTrees; }
        set { remainTrees = value; }
    }
    private void Awake()
    {
        text.enabled = false;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Start()
    {
        solver = GameObject.Find("Obi Solver").GetComponent<ObiSolver>();
        emitter = GameObject.Find("Obi Emitter").GetComponent<ObiEmitter>();
        solver.OnCollision += Solver_OnCollision;
        group1 = GameObject.Find("group1").GetComponent<ObiCollider>();
        group2 = GameObject.Find("group2").GetComponent<ObiCollider>();
        group3 = GameObject.Find("group3").GetComponent<ObiCollider>();
        group4 = GameObject.Find("group4").GetComponent<ObiCollider>();
        group5 = GameObject.Find("group5").GetComponent<ObiCollider>();
        //rock = GameObject.Find("Rock_002").GetComponent<ObiCollider>();
        // _rigidbody = GameObject.Find("Rock_002").GetComponent<Rigidbody>();
        StartCoroutine(LateAudio(1));
        audioSource.clip = audioClips[0];
        audioSource.Play();
        RemainTrees = 5;
        for(int i = 0; i < 5; i++)
        {
            particles[i].Stop();
        }
    }
    private IEnumerator LateAudio(float delay)
    {
        audioSource.clip = audioClips[0];
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
    private void Solver_OnCollision(ObiSolver solver, ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach (Oni.Contact contact in e.contacts)
        {
            if (contact.distance < 0.01)
            {
                var col = world.colliderHandles[contact.other].owner;
                if (col == group1 && group1Particles.Add(contact.particle))
                {
                    //emitter.KillParticle(solver.particleToActor[contact.particle].indexInActor);
                    for (int i = 0; i < group1Anim.Length; i++)
                    {
                        group1Anim[i].HP--;
                    }
                    if (group1Anim[0].HP == 49)
                    {
                        particles[0].Play();
                        audioSource_loop.clip = audioClips[2];
                        audioSource_loop.Play();
                    }
                    if (group1Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        particles[0].Stop();
                        audioSource_loop.Stop();
                        audioSource.clip = audioClips[1];
                        audioSource.Play();
                    }
                }
                /*if (col == rock)
                {
                    velocity += solver.velocities[contact.particle];
                    solver.velocities[contact.particle] = -solver.velocities[contact.particle];
                    _rigidbody.velocity = velocity / 1000;
                }//*/
                if (col == group2 && group2Particles.Add(contact.particle))
                {
                    //emitter.KillParticle(solver.particleToActor[contact.particle].indexInActor);
                    for (int i = 0; i < group2Anim.Length; i++)
                    {
                        group2Anim[i].HP--;
                    }
                    if (group2Anim[0].HP == 49)
                    {
                        particles[0].Play();
                        audioSource_loop.clip = audioClips[2];
                        audioSource_loop.Play();
                    }
                    if (group2Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        particles[0].Stop();
                        audioSource_loop.Stop();
                        audioSource.clip = audioClips[1];
                        audioSource.Play();
                    }
                }
                if (col == group3 && (group3Particles.Count - group4Particles.Count) <= 0)
                {
                    //emitter.KillParticle(solver.particleToActor[contact.particle].indexInActor);
                    if (group3Particles.Add(contact.particle))
                    {
                        for (int i = 0; i < group3Anim.Length; i++)
                        {
                            group3Anim[i].HP--;
                        }
                        if (group3Anim[0].HP == 49)
                        {
                            particles[0].Play();
                            audioSource_loop.clip = audioClips[2];
                            audioSource_loop.Play();
                        }
                        if (group3Anim[0].HP == 1)
                        {
                            RemainTrees--;
                            particles[0].Stop();
                            audioSource_loop.Stop();
                            audioSource.clip = audioClips[1];
                            audioSource.Play();
                        }
                    }
                }
                if (col == group4 && (group4Particles.Count - group3Particles.Count) <= 0)
                {
                    //emitter.KillParticle(solver.particleToActor[contact.particle].indexInActor);
                    if (group4Particles.Add(contact.particle))
                    {
                        for (int i = 0; i < group4Anim.Length; i++)
                        {
                            group4Anim[i].HP--;
                        }
                        if (group4Anim[0].HP == 49)
                        {
                            particles[0].Play();
                            audioSource_loop.clip = audioClips[2];
                            audioSource_loop.Play();
                        }
                        if (group4Anim[0].HP == 1)
                        {
                            RemainTrees--;
                            particles[0].Stop();
                            audioSource_loop.Stop();
                            audioSource.clip = audioClips[1];
                            audioSource.Play();
                        }
                    }
                }
                if (col == group5 && group5Particles.Add(contact.particle))
                {
                    //emitter.KillParticle(solver.particleToActor[contact.particle].indexInActor);
                    for (int i = 0; i < group5Anim.Length; i++)
                    {
                        group5Anim[i].HP--;
                    }
                    if (group5Anim[0].HP == 49)
                    {
                        particles[0].Play();
                        audioSource_loop.clip = audioClips[2];
                        audioSource_loop.Play();
                    }
                    if (group5Anim[0].HP == 1)
                    {
                        RemainTrees--;
                        particles[0].Stop();
                        audioSource_loop.Stop();
                        audioSource.clip = audioClips[1];
                        audioSource.Play();
                    }
                }
            }
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        Debug.Log(RemainTrees);
        if (RemainTrees == 0) StartCoroutine(Quit(3));
    }
    private IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync("Canyon");
    }
    private IEnumerator Quit(float delay)
    {
        text.enabled = true;
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
