using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup text1CG;
    [SerializeField]
    private CanvasGroup text2CG;

    private Sequence tween;

    private void Start()
    {
        if (BGMSEManager.PlayingAudio == null)
        {
            BGMSEManager.BSInstance.BGMPlayer(0);
        }

        tween = DOTween.Sequence();
        tween.Join(text1CG.DOFade(0, 0.3f).SetLoops(2, LoopType.Yoyo));
        tween.Join(text2CG.DOFade(0, 0.3f).SetLoops(2, LoopType.Yoyo));
        tween.SetDelay(1f);
        tween.SetLoops(-1);
        tween.Play();
    }
    public void OnStartButton()
    {
        tween.Kill();
        BGMSEManager.BSInstance.SEPlayer(0);
        MySceneManager.Instance.SceneFadeChange("Game_EatPhase");
    }
}
