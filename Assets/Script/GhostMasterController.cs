using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class GhostMasterController : MonoBehaviour
{
    private GameObject[] PirateGhostObjects;
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    public Transform[] points;
  

    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
     
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
    public void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        animator.SetBool("walk",true);

     
    }
    public void OnTriggerEnter(Collider other)
    {
   if (other.gameObject.CompareTag("Player"))
        {

            Invoke("DelayMethod", 0.7f);


}
        else
        {
            animator.SetBool("death", true);

        }
    }

        public void DelayMethod()
{

    SceneManager.LoadScene("GameOverScene");

}
}

