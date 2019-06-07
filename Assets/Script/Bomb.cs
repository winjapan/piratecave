using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject SmallExplosionEffect;
    ParticleSystem particle;
    public GameObject Player;
    public GameObject Box;
    public GameObject MagicalRubyItem;
    public LayerMask layerMask;
    Rigidbody rgbody;
    RaycastHit hit;
    PlayerController pCon;

    public bool exploded = false;
    public float radius = 100.0f;
    public float power = 200.0f;

    public List<GameObject> smalls = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 1.0f);

        rgbody = GetComponent<Rigidbody>();

        Player = GameObject.Find("Player");



    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {

        GameObject small = Instantiate(SmallExplosionEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(small, 1.5f);
        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        StartCoroutine(CleateExplode(Vector3.forward));
        StartCoroutine(CleateExplode(Vector3.right));
        StartCoroutine(CleateExplode(Vector3.back));
        StartCoroutine(CleateExplode(Vector3.left));

        Destroy(this.gameObject, 1.0f);
    }

    




    public IEnumerator CleateExplode(Vector3 direction)
    {


        for (int i = 0; i < 5+ EffectPower; i++)
        {

            RaycastHit hit;

            Physics.Raycast(transform.position + new Vector3(0, 1.0f, 0), direction, out hit, i);

            if (Player.gameObject.layer == LayerMask.NameToLayer("PowerUp"))
            {
                pCon = GetComponent<PlayerController>();

                AddExplode();

            }



            if (!hit.collider)
            {
                GameObject small = Instantiate(SmallExplosionEffect, transform.position + (i * direction), SmallExplosionEffect.transform.rotation) as GameObject;
                Destroy(small, 1.5f);



            }
            else
            {
                break;
            }





            yield return new WaitForSeconds(0.05f);



        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Exploade");

            Explode();
        }

    }

    int EffectPower;

    public void AddExplode()
    {
        EffectPower = 10;
       

        Vector3 direction = transform.position;
        for (int i = 1; i < EffectPower; i++)
        {



            Physics.Raycast(transform.position + new Vector3(0, 1.0f, 0), direction, out hit, i);
           
        }
    }
}

    


    


    
    
    



    


    



  













