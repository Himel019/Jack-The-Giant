using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private Animator fadeAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance() {
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level) {
        StartCoroutine(FadeInOut(level));
    }

    private IEnumerator FadeInOut(string level) {
        fadePanel.SetActive(true);
        fadeAnimator.Play("FadeIn");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));

        SceneManager.LoadScene(level);
        fadeAnimator.Play("FadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));

        fadePanel.SetActive(false);
    }
}
