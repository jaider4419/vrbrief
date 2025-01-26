using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI TimerText;
    [SerializeField] float gameTimer;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    
}
