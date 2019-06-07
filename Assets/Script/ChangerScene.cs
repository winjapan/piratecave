using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChangerScene : MonoBehaviour
{
    public GameObject Cylinder;
    public Text Induction;

    public float speed = 1.0f;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayMethod" , 1.0f);
        
    }

    void DelayMethod()
    {

        var text = Induction.GetComponent<Text>();


        var message = "プレイヤーを動かして死の洞窟に入ろう！";
        text.DOText
          (
           message,
           message.Length * 0.3f
            );

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision other)
    {
      

        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene("GameScene");
        }
    }
}
