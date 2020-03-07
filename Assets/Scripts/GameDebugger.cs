using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDebugger : MonoBehaviour
{
    [SerializeField] private bool die = false;

    void Update()
    {
        if (die)
        {
            PlayerController.instance.OnDie();
            die = false;
        }
    }
}
