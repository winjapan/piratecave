using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChenge : MonoBehaviour
{
    GameObject[] PirateGhostObjects;
    private AudioSource audioSource;
    public AudioClip PirateCaveBGM;
    public GameObject PirateGhost;
    public AudioClip GhostMasterBGM;
    bool aaa;

    int GhostCount;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = PirateCaveBGM;
        audioSource.Play();
    }

    //ノーマルゴーストが全滅して、マスターゴーストを呼び出すとき
    void Update()
    {
        PirateGhostObjects = GameObject.FindGameObjectsWithTag("PirateGhost");
        

        if (PirateGhostObjects.Length == 0 && !aaa)
        {
            audioSource.Stop();
            audioSource.clip = GhostMasterBGM;
            audioSource.Play();
            aaa = true;
           
        }
    }
}
