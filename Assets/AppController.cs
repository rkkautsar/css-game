using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour {

    public Transform canvas;
    public Transform player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exitOnClick()
	{
		Application.Quit();
	}

	public void loadMainScene() {
		SceneManager.LoadScene ("MainScene");
	}

    public void loadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

	public void loadHighscoreScene()
	{
		SceneManager.LoadScene("HighScoreScene");
	}

	public void loadTutorialScene()
	{
		SceneManager.LoadScene("TutorialScene");
	}

    public void resumeOnClick()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<Animator>().enabled = false;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<Animator>().enabled = true;
        }
    }
}
