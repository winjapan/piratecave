using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rgbody;
    public float speed;
    private Vector3 Player_Pos;
    Animator animator;
    public GameObject BombPrefab;
    public GameObject PirateGhost;
    public AudioClip sword;
    public AudioClip death;
    public GameObject GhostMaster;
    public GameObject MagicalRubyItem;
    public GameObject MagicalSapphireItem;
    public GameObject SmallExplosionEffect;
    public GameObject Treasure;
    Bomb bomb; 

    RaycastHit hit;

    public int MaxBomb;

    int ExplodeRadius = 1;

    bool Ground;

    //Start is called before the first frame update
    void Start()
    {

        rgbody = GetComponent<Rigidbody>();
        Player_Pos = GetComponent<Transform>().position;
        animator = GetComponent<Animator>();
        animator.SetBool("death", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropBombs();


        }
    }

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
            AudioSource.PlayClipAtPoint(sword, transform.position);
            animator.SetBool("attack2", true);
        }
        else
        {
            animator.SetBool("attack2", false);
        }
    }

    private void DropBombs()
    {

        int BombCount = GameObject.FindGameObjectsWithTag("BombPrefab").Length;

        if (BombCount < MaxBomb)
        {



            if (BombPrefab)
            {
                float x = Mathf.RoundToInt(transform.position.x);
                float z = Mathf.RoundToInt(transform.position.z);
                transform.position = new Vector3(x, 0, z);

                Instantiate(BombPrefab, transform.position, BombPrefab.transform.rotation);


            }


        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GhostMaster"))
        {

            Invoke("DelayMethod", 0.7f);


        }

    }
    public void DelayMethod()
    {
        animator.SetBool("death", true);
        SceneManager.LoadScene("GameOverScene");

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MagicalSapphireItem"))
        {
            MaxBomb += 1;
        }

        if (other.gameObject.CompareTag("MagicalRubyItem"))
        {
            AddExplode();

            
        }

    }
    public void AddExplode()
    {
        
        Vector3 direction = transform.position;
        for (int ExplodeRadius = 1; ExplodeRadius < 5 + 5; ExplodeRadius++)
        {

            //Debug.Log("ボムスクリプトとつながってますか？");

        }

    }
}

  
   



    



