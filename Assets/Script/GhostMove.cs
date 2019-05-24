using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhostMove : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;
    public AudioClip sound;
    public AudioClip bombSE;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        animator.SetBool("walk", true);
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;

        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Destroy(this.gameObject);
          
        }
        else if (hit.gameObject.tag == "SmallExplosionEffect")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            AudioSource.PlayClipAtPoint(bombSE, transform.position);
            Destroy(gameObject, 1.0f);
        }


    }

}
