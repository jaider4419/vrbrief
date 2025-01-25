using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame()

    {
        Application.Quit();
        Debug.Log("Exited the experience.");
    }
}
