using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;

    [SerializeField]
    private CanvasGroup fadeImageCG;
    [SerializeField]
    private float fadeDuration = 0.3f;
    public static GameObject single;

    private void Awake()
    {
        if (single == null)
        {
            single=this.gameObject;
            Instance=this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void SceneFadeChange(string sceneName)
    {
        //フェードする
        //遷移する
        fadeImageCG.DOFade(1, fadeDuration).OnComplete(() => SceneManager.LoadScene(sceneName.ToString()));
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //フェードする
        fadeImageCG.alpha = 1;
        fadeImageCG.DOFade(0, fadeDuration).SetDelay(0.5f);
    }
}
