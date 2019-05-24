using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{
  
    GameObject[] PirateGhostObjects;
    public GameObject GhostMaster;
    public GameObject PiraeGhost;
    public GameObject PirateGhost2;
    public GameObject Treasure;
    public GameObject Box;
    public Text BMTimer;
    public float countTime;
    public Text TreasureCount;
    int treasureCount = 1;

    int seconds;

    int GhostCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        PirateGhostObjects = GameObject.FindGameObjectsWithTag("PirateGhost");


        if (PirateGhostObjects.Length == 0)
        {
            GhostMaster.gameObject.SetActive(true);

        }

        countTime -= Time.deltaTime;
        seconds = (int)countTime;
        BMTimer.text = seconds.ToString();

        if (countTime < 0)
        {
            BMTimer.gameObject.SetActive(false);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");



           
        
        }

        

        int count = GameObject.FindGameObjectsWithTag("Treasure").Length;
        TreasureCount.text = treasureCount.ToString();

       

        if (count == 0)
        {
            SceneManager.LoadScene("ClearScene");
        }

        
       
    }
   

    }

