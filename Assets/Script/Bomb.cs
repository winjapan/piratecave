using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject PaticalSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
      

        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(true);
            GetComponent<ParticleSystem>().Play();
            PaticalSystem.SetActive(true);
            PaticalSystem.SetActive(false);

        }

    }
}
