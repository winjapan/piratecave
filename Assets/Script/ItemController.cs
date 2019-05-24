using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{
   
    public GameObject MagicalRubyItem;
    public GameObject MagicalSapphireItem;
    public GameObject Treasure;
    public GameObject BombPrefab;
    public AudioClip GetItem;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(GetItem, transform.position);
            Destroy(gameObject);
        }

       
    }
}
