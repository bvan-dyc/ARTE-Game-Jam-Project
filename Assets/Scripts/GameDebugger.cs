using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDebugger : MonoBehaviour
{
    [SerializeField] private bool playerDebugger = true;
    [SerializeField] private bool die = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
			Reload();
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (playerDebugger && die)
        {
            PlayerController.instance.OnDie();
            die = false;
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
