using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Effect;
    public AudioClip bombSE;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("SmallExplosionEffect"))
        {
            AudioSource.PlayClipAtPoint(bombSE, transform.position);
            Destroy(gameObject,0.5f);

           

        }
    }

}
