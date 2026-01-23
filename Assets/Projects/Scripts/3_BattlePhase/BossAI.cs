using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField, Label("ボス：HP")]
    private float Hp = 10000;
    private float defHp;
    [SerializeField, Label("ボス：攻撃力")]
    public float Attack = 10;

    [SerializeField]
    private SetBattleStatus battleStatus;

    [SerializeField]
    private RectTransform bossHpGauge;
    float currentVelocity = 0;
    private float DisAdd = 1;

    //移動
    private Vector2 pos;
    public int num = 1;

    private bool doOncePic = false;
    [SerializeField]
    private float bossMoveDuration = 4f;
    [SerializeField]
    private float bossStampSize = 0.2f;
    [SerializeField]
    private float bossStampDuration = 0.2f;

    [SerializeField]
    private GameObject bulletObj;
    [SerializeField]
    private float bulletDelay = 0.3f;
    private float deftime;

    private Sequence tween;

    // Start is called before the first frame update
    void Start()
    {
        defHp = Hp;
        doOncePic = false;
        deftime = bulletDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //start return
        if (GameManager.IsGame == false)
        {
            tween.Pause();
            return;
        }

        if (defHp <= 0)
        {
            defHp = 0;
            bossHpGauge.localScale = new Vector2(0, bossHpGauge.localScale.y);
            GameManager.instance.Pank(false);
        }

        //緩やかにゲージの値が変化
        //全体を1として実数値で減らしても割合で減少する
        float currentDashPTfat = Mathf.SmoothDamp(bossHpGauge.localScale.x, (defHp / Hp) / DisAdd, ref currentVelocity, 10 * Time.deltaTime);
        bossHpGauge.localScale = new Vector2(currentDashPTfat, bossHpGauge.localScale.y);

        //行動をピックして処理
        if (!doOncePic)
        {
            PicAction(3);
            doOncePic = true;
        }

        deftime -= Time.deltaTime;
        if (deftime < 0)
        {
            //弾発射
            Instantiate(bulletObj, transform.position, Quaternion.identity);
            //Instantiate(bulletObj, new Vector2(transform.position.x+3,transform.position.y-0.5f), Quaternion.identity);
            //Instantiate(bulletObj, new Vector2(transform.position.x-3,transform.position.y-0.5f), Quaternion.identity);

            //リセット
            deftime = bulletDelay;
        }
    }

    private void PicAction(int now)
    {
        int act = Random.Range(0,2);
        if (now == 1)
        {
            if (act == 1)
            {
                WipAttack_2();
            }
            else
            {
                ShootBlack_3();
            }
        }
        else if(now==2)
        {
            if (act == 1)
            {
                ShootRangeBall_1();
            }
            else
            {
                ShootBlack_3();
            }
        }
        else 
        {
            if (act == 1)
            {
                ShootRangeBall_1();
            }
            else
            {
                WipAttack_2();
            }
        }
    }

    private void ShootRangeBall_1()
    {
        tween = DOTween.Sequence();
        tween.Append(this.transform.DOMoveX(3.5f, bossMoveDuration).SetLoops(2, LoopType.Yoyo));
        tween.Append(this.transform.DOMoveX(-3.5f, bossMoveDuration).SetLoops(2, LoopType.Yoyo));
        tween.SetLoops(2);
        tween.Play().OnComplete(() => PicAction(1));
    }

    private void WipAttack_2()
    {
        tween = DOTween.Sequence();
        tween.Append(this.transform.DOMoveX(3.5f, bossMoveDuration).SetLoops(2, LoopType.Yoyo));
        tween.Append(this.transform.DOMoveX(-3.5f, bossMoveDuration).SetLoops(2, LoopType.Yoyo));
        tween.SetLoops(2);
        tween.Play().OnComplete(() => PicAction(2));
    }

    private void ShootBlack_3()
    {
        tween = DOTween.Sequence();
        tween.Append(this.transform.DOScaleY(this.transform.localScale.y-bossStampSize, bossStampDuration).SetLoops(2, LoopType.Yoyo));
        tween.SetLoops(4);
        tween.Play().OnComplete(() => PicAction(3));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            defHp -= SetBattleStatus.ATTACK;
        }
    }
}
