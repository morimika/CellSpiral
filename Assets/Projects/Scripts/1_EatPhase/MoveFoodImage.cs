using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MoveFoodImage : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rectTra;

    public float moveFoodDuration;

    [SerializeField]
    private bool doTween = false;

    private Tween tween;

    public FoodData foodData;

    // Start is called before the first frame update
    void Start()
    {
        rectTra = GetComponent<RectTransform>();
        foodData = GetComponent<GetFoodData>().foodData;
    }

    // Update is called once per frame
    void Update()
    {
        if (doTween) return;
        doTween = true;
        tween = rectTra.DOAnchorPosX((-rectTra.localPosition.x), moveFoodDuration).SetEase(Ease.Linear).OnComplete(() => Destroy(this.gameObject));
    }

    private void OnDestroy()
    {
        if (tween != null && tween.IsActive())
        {
            tween.Kill();
        }
    }

    /// <summary>
    /// ‰Ÿ‚³‚ê‚½‚Æ‚«ˆİ‚É“ü‚ê‚é
    /// </summary>
    /// <param name="pointerData"></param>
    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(this.gameObject.name + "‚ª‰Ÿ‚³‚ê‚½");

        BGMSEManager.BSInstance.SEPlayer(5);

        //ˆİ‚É“ü‚ê‚é‚à‚Ì‚Ì“à—e‚ğó‚¯“n‚µ‚Ä¶¬‚µ‚Ä‚à‚ç‚¤
        SpawnFoods.instance.StmObjGenerator(foodData);

        Destroy(this.gameObject);
    }
}
