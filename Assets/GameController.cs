using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI TimerText;
    static public float gameTimer = 30;
    GameObject[] Moles;
    float popupTimer = 1;
    static public int score = 0;
    internal static bool RightHandInUse;


    // Start is called before the first frame update
    void Start()
    {
        Moles = GameObject.FindGameObjectsWithTag("Mole");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        if (gameTimer < 0)
        {
            gameTimer = 0;
            
            TimerText.text = "game over!";
        }


            

        int minutes = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);

        TimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);


        if (gameTimer == 0) 
        {
            TimerText.text = "GAME OVER!";
            
        }

        updateMoles(); 
    }

    void updateMoles()
    {

        popupTimer -= Time.deltaTime;

        if (popupTimer < 0)
        {
            int rnd = Random.Range(0, Moles.Length);
            var script = Moles[rnd].GetComponent<MoleJump>();
            script.pop();

            popupTimer = Random.Range(1, 3);
           
        }
    }
  
}
