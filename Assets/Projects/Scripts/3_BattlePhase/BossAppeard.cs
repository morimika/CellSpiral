using DG.Tweening;
using UnityEngine;

public class BossAppeard : MonoBehaviour
{
    [SerializeField]
    private GameObject BossObj;

    [SerializeField]
    private CanvasGroup CG;

    [SerializeField]
    private GameObject SizeObj;

    [SerializeField]
    private float bossStampSize = 0.2f;
    [SerializeField]
    private float bossStampDuration = 0.1f;

    private Tween Tween;

    void Start()
    {
        SizeObj.transform.localScale = new Vector2(4, 4);
        Invoke(nameof(Appeard), 0.4f);
        Invoke(nameof(Fade), 3.4f);
    }

    private void Appeard()
    {
        BGMSEManager.BSInstance.SEPlayer(3);
        BGMSEManager.BSInstance.BGMPlayer(1);
        SizeObj.transform.DOScale(Vector2.one, 0.2f);
        Tween = BossObj.transform.DOScaleY(BossObj.transform.localScale.y - bossStampSize, bossStampDuration).SetLoops(-1, LoopType.Yoyo);
    }

    private void Fade()
    {
        CG.DOFade(0, 0.2f).OnComplete(()=>this.gameObject.SetActive(false));
    }

    private void OnDisable()
    {
        Tween.Kill();
    }
}
