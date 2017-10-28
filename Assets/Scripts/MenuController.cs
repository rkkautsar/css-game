using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Transform canvas;
    public Transform Player;
    public Button exitButton;

    private void Start()
    {
        exitButton.onClick.AddListener(exitOnClick);
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<Animator>().enabled = false;
            } else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                Player.GetComponent<Animator>().enabled = true;
            }
        }
	}

    void exitOnClick()
    {
        Application.Quit();
    }
}
