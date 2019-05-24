using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    Button button;
    Text text;
    public Button UnderStand;
    public Text Title;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    

    public void ButtonClicked()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
