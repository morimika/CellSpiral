using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EatPhaseCountDown : MonoBehaviour
{
    [SerializeField]
    private bool inGame = false;

    [SerializeField]
    private int maxTime;
    private float defTime;
    [SerializeField]
    private float defstartTime=1.5f;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private RectTransform gaugeBG;

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TextMeshProUGUI title;

    private bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        defTime = maxTime;
        inGame = false;
        timeText.text = defTime.ToString("F0");
        panel.SetActive(true);
        title.text = "注文開始";
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中でないなら
        if (!inGame)
        {
            //スタート時のみ処理
            if(defTime != 0)
            {
                defstartTime -= Time.deltaTime;
                if (defstartTime <= 0)
                {
                    inGame = true;
                    return;
                }
            }

            //ゲーム中でないとき処理
            //パネル表示
            if (!panel.gameObject.activeSelf)
            {
                panel.SetActive(true);
            }

            return;
        }

        //ゲーム中
        //パネルを非表示
        if (panel.gameObject.activeSelf)
        {
            panel.SetActive(false);
        }
        //カウントダウン
        defTime -=Time.deltaTime;
        timeText.text= defTime.ToString("F0");
        gaugeBG.localScale = new Vector2((defTime/maxTime), gaugeBG.localScale.y);

        //カウントが0以下なら
        if (defTime <= 0&& finish==false)
        {
            defstartTime = 1.5f;
            defTime = 0;
            inGame = false;
            finish = true;
            BGMSEManager.BSInstance.SEPlayer(2);
            title.text = "終了";
            Invoke("ChangeScene", 3);
        }

    }

    private void ChangeScene()
    {
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }
}
