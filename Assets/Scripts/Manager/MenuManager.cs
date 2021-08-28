using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using Coffee.UIEffects;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Button[] gameButtons;
    [SerializeField] Image fadeImage;

    [Header("Effects")]
    [SerializeField] float fadeInDuration;
    [SerializeField] float fadeOutDuration;

    UIShiny hoverButtonVFX;

    private void Awake()
    {
        foreach (Button b in gameButtons)
        {
            b.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        }

        fadeImage.DOFade(1, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        EnterScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    #region buttons
    public void PlayGame()
    {
        ExitScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HoverButton(int index)
    {
        hoverButtonVFX = gameButtons[index].gameObject.GetComponent<UIShiny>();
        hoverButtonVFX.Play();
    }

    public void UnhoverButton()
    {
        if (hoverButtonVFX != null)
            hoverButtonVFX.Stop();
    }
    #endregion

    void EnterScene()
    {
        DOTween.Kill(gameObject);

        fadeImage.DOFade(0, fadeInDuration);
    }

    public void ExitScene(int sceneIndex)
    {
        StartCoroutine(FadeOutTransition(sceneIndex));
    }

    IEnumerator FadeOutTransition(int sceneIndex)
    {
        DOTween.Kill(gameObject);

        fadeImage.DOFade(1, fadeOutDuration);

        yield return new WaitForSeconds(fadeOutDuration * 2f);

        SceneManager.LoadScene(sceneIndex);
    }
}
