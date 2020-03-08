using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    protected UserInput input;
    [SerializeField] private Image fadeScreen;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float loadDelay = 5f;
    [SerializeField] private bool fadeInOnLoad = false;
    [SerializeField] private Text mainText = null;
    [SerializeField] private string victoryString = "YOU DIED";

    void Start()
    {
        if (fadeInOnLoad)
        {
            PlayerController.instance.OnFinalDeath.AddListener(GameEnd);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 1);
            StartCoroutine(UIExtensions.ImageFadeOutRoutine(fadeScreen, fadeDuration));
        }
    }

    void GameEnd(PlayerController player)
    {
        StartCoroutine(EndRoutine(loadDelay));
        StartCoroutine(UIExtensions.TypeTextRoutine(victoryString, mainText, 0.2f));
        StartCoroutine(UIExtensions.ImageFadeInRoutine(fadeScreen, fadeDuration));
    }

    IEnumerator EndRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

