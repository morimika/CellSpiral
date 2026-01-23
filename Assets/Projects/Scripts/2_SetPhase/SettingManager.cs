using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    //キャラの食事ステータス
    public static float FatStats = 0;
    public static float ProteinStats = 0;
    public static float CarbohydratesStats = 0;

    public static float AllStats = 0;

    [SerializeField]
    private List<CharaStats> charaStatsLists = new List<CharaStats>();
    public static CharaStats picChara;

    [Header("設定項目取得")]
    [SerializeField]
    private Image charaImage;
    [SerializeField]
    private TextMeshProUGUI topText;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI infoText;

    [SerializeField]
    private float StayTime = 5f;
    private float defStayTime;
    [SerializeField]
    private GameObject nextInfoTextObj;
    private bool canNext = false;

    private float fatPar = 0;
    private float proPar = 0;
    private float carPar = 0;

    [SerializeField,Label("判定誤差")]
    private float diffValue = 5;

    void Start()
    {
        //初期設定
        if (instance == null)
        {
            instance = this;
        }

        AllStats = FatStats + ProteinStats + CarbohydratesStats;
        topText.text = "よく食べました";

        //次へ案内
        canNext = false;
        Invoke(nameof(ActiveNextScene), StayTime);

        //割合算出
        fatPar= FatStats / AllStats *100;
        proPar= ProteinStats / AllStats *100;
        carPar= CarbohydratesStats / AllStats *100;

        //ピック
        //全体的に低い場合
        //4栄養無し
        if (AllStats <= 600)
        {
            Setting(4);
        }
        //各割合が37%以上ある場合
        //1=太り
        else if (fatPar > proPar + diffValue && fatPar > carPar + diffValue)
        {
            Setting(1);
        }
        //2=筋肉
        else if (proPar > fatPar + diffValue && proPar > carPar + diffValue)
        {
            Setting(2);
        }
        //3=睡眠
        else if (carPar > proPar + diffValue && carPar > fatPar + diffValue)
        {
            Setting(3);
        }
        //それ以外
        //0=普通
        else
        {
            Setting(0);
        }

        BGMSEManager.BSInstance.BGMStoper(0);
        BGMSEManager.BSInstance.SEPlayer(1);
    }

    private void Update()
    {
        if(canNext)
        {
            if (Input.GetMouseButton(0))
            {
                canNext = false;
                BGMSEManager.BSInstance.SEPlayer(0);
                MySceneManager.Instance.SceneFadeChange("Game_BattlePhase");
            }
        }
    }

    private void Setting(int charaNumver)
    {
        //食べていないときの特別演出
        if (charaNumver == 4)
        {
            topText.text = "ちゃんと食べた？";
        }
        //キャラクターセット
        picChara = charaStatsLists[charaNumver];
        titleText.text=picChara.TitleText;
        infoText.text=picChara.InfomationText;
        charaImage.sprite=picChara.CharaStandImage;
    }

    private void ActiveNextScene()
    {
        canNext = true;
        nextInfoTextObj.SetActive(true);
    }
}
