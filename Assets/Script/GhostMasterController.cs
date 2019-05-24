using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhostMasterController : MonoBehaviour
{
    private GameObject[] PirateGhostObjects;
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   public void Update()
    {
        

        animator.SetBool("walk",true);
        agent.destination = target.transform.position;
    }

   
}
