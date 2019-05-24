using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartDirector : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject Ground;
    public GameObject PirateGhost;
    public GameObject GhostMaster;
    public GameObject Box;
    public GameObject Point;
    public Button GoButton;

    public float radius;
    public int maxNum;

    public void ButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiateObstacle", 0.5f);
    }

    private void InstantiateObstacle()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
