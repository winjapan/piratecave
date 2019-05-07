using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rgbody;
    public float speed;
    private Vector3 Player_Pos;
    Animator animator;
    public GameObject BombPrefab;
  

    bool Ground;

    //Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        Player_Pos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rgbody.velocity = new Vector3(x * speed, 0, z * speed);

        Vector3 diff = transform.position - Player_Pos;

        if (diff.magnitude > 0.01f)
        {

            transform.rotation = Quaternion.LookRotation(diff);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        Player_Pos = transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("attack2", true);
        }
        else
        {
            animator.SetBool("attack2", false);
        }

    }
    void DropBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BombPrefab,transform.position,BombPrefab.transform.rotation);
            
        }

    }
}


