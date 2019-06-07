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
    public GameObject TreasureBox;
    public GameObject Box;
    public Text BMTimer;
    public float countTime;
    public Text TreasureCount;
    int treasureCount = 1;
    public Text GhostInduction;

    int seconds;
    int GhostCount;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
      
        countTime -= Time.deltaTime;
        seconds = (int)countTime;
        BMTimer.text = seconds.ToString();

        PirateGhostObjects = GameObject.FindGameObjectsWithTag("PirateGhost");

        if (PirateGhostObjects.Length == 0)
        {
            GhostInduction.gameObject.SetActive(true);
            countTime -= 0.1f;
            Invoke("DelayActive",0.5f);
        }
        

        int count = GameObject.FindGameObjectsWithTag("TreasureBox").Length;
        TreasureCount.text = treasureCount.ToString();

        if (count ==30)
        {
           
        }
       

        if (count == 0)
        {
            SceneManager.LoadScene("ClearScene");
        }

        
       
    }
   public void DelayActive(){

        GhostInduction.gameObject.SetActive(false);
    }

    }

