	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Transform canvas;
    public Transform player;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                player.GetComponent<Animator>().enabled = false;
            } else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
                player.GetComponent<Animator>().enabled = true;
            }
        }
	}
}
