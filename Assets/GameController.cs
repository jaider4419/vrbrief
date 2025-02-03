using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float gameTimer = 30f;
    GameObject[] Moles;
    float popupTimer = 1;
    internal static bool RightHandInUse;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Moles = GameObject.FindGameObjectsWithTag("Mole");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (gameTimer > 0)
            {
                gameTimer -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(gameTimer / 60);
                int seconds = Mathf.FloorToInt(gameTimer % 60);
                TimerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
            }
            else
            {
                gameOver = true; 
                gameTimer = 0;
                TimerText.text = "GAME OVER!";
            }

            updateMoles();
        }
    }

    void updateMoles()
    {
        if (gameOver) return; 

        popupTimer -= Time.deltaTime;

        if (popupTimer < 0)
        {
            int rnd = Random.Range(0, Moles.Length);
            var script = Moles[rnd].GetComponent<MoleJump>();

            if (script != null)
            {
                script.Rise();
            }

            popupTimer = Random.Range(1, 3);
        }
    }
}
