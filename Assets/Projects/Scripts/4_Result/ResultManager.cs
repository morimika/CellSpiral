using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public static bool isWin = false;

    [SerializeField]
    private GameObject winObj;

    [SerializeField]
    private GameObject loseObj;

    [SerializeField]
    private TextMeshProUGUI battleTimeTX;
    [SerializeField]
    private TextMeshProUGUI hpTX;
    [SerializeField]
    private TextMeshProUGUI attackTX;
    [SerializeField]
    private TextMeshProUGUI defenceTX;
    [SerializeField]
    private TextMeshProUGUI moveSpeedTX;
    [SerializeField]
    private Image winPlayerSpr;
    [SerializeField]
    private Image losePlayerSpr;

    [SerializeField]
    private float StayTime = 5f;
    private bool canNext = false;

    void Start()
    {
        if (isWin)
        {
            if (BGMSEManager.PlayingAudio == null)
            {
                BGMSEManager.BSInstance.BGMPlayer(0);
            }
            BGMSEManager.BSInstance.SEPlayer(1);
            winObj.SetActive(true);
            loseObj.SetActive(false);
            battleTimeTX.text = "戦闘時間：" + GameManager.BattleTime.ToString("F2") + "秒";
            hpTX.text = "体力：" + PlayerMove.hp.ToString("F0") + " / " + SetBattleStatus.HP.ToString("F0");
            attackTX.text = "攻撃力：" + SetBattleStatus.ATTACK.ToString("F1");
            defenceTX.text = "防御力：" + SetBattleStatus.DEFENCE.ToString("F1");
            moveSpeedTX.text = "移動速度：" + SetBattleStatus.MOVESPEED.ToString("F2") + "km/h";
            winPlayerSpr.sprite=SettingManager.picChara.CharaWinImage;
        }
        else if(!isWin)
        {
            if (BGMSEManager.PlayingAudio != null)
            {
                BGMSEManager.BSInstance.BGMStoper(0);
            }
            winObj.SetActive(false);
            loseObj.SetActive(true);
            losePlayerSpr.sprite = SettingManager.picChara.CharaLoseImage;
        }

        //次へ案内
        canNext = false;
        Invoke(nameof(ActiveNextScene), StayTime);
    }

    void Update()
    {
        if (canNext)
        {
            if (Input.GetMouseButton(0))
            {
                canNext = false;
                BGMSEManager.BSInstance.SEPlayer(5);
                MySceneManager.Instance.SceneFadeChange("Title");
            }
        }
    }

    private void ActiveNextScene()
    {
        canNext = true;
    }
}
