using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EatPhaseCountDown : MonoBehaviour
{
    [SerializeField]
    private bool inGame = false;

    [SerializeField]
    private int maxTime;
    private float defTime;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private RectTransform gaugeBG;

    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TextMeshProUGUI title;

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
            if (!panel.gameObject.activeSelf)
            {
                panel.SetActive(true);
            }
            //パネル表示
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
        if (defTime <= 0)
        {
            inGame = false;
            defTime = 0;
            title.text = "終了";
        }

    }
}
