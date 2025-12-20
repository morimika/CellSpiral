using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveFoodImage : MonoBehaviour
{
    private RectTransform rectTra;

    public float moveFoodDuration;

    [SerializeField]
    private bool doTween = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTra = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doTween) return;
        doTween = true;
        rectTra.DOAnchorPosX((-rectTra.localPosition.x), moveFoodDuration).SetEase(Ease.Linear).OnComplete(() => Destroy(this.gameObject));
    }
}
