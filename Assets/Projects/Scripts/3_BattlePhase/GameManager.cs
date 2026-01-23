using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool IsGame = false;

    [SerializeField]
    private float startCount = 3f;
    private float defStartCount;

    [SerializeField]
    private GameObject panelCanvas;
    [SerializeField]
    private TextMeshProUGUI titleText;

    public static float BattleTime;

    [SerializeField]
    private GameObject pankPL;
    [SerializeField]
    private GameObject pankBS;

    [SerializeField]
    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        IsGame = false;
        defStartCount=startCount;
        titleText.text = "êÌì¨äJén";
        BattleTime = 0;
        pankPL.SetActive(false);
        pankBS.SetActive(false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame == false)
        {
            if (defStartCount != 0)
            {
                defStartCount -= Time.deltaTime;
            }
            if (defStartCount < 0)
            {
                defStartCount = 0;
                panelCanvas.SetActive(false);
                titleText.text = "åàíÖ";
                IsGame = true;
            }
        }
        else if (IsGame)
        {
            BattleTime += Time.deltaTime;
        }
    }

    public void Pank(bool isPlayerDeath)
    {
        BGMSEManager.BSInstance.BGMStoper(1);
        if (isPlayerDeath)
        {
            IsGame = false;
            ResultManager.isWin = false;
            pankPL.SetActive(true);
            StartCoroutine(Shake(0.3f, 0.6f));
            Invoke(nameof(Finish), 2);
        }
        else
        {
            BGMSEManager.BSInstance.SEPlayer(4);
            IsGame = false;
            ResultManager.isWin = true;
            pankBS.SetActive(true);
            StartCoroutine(Shake(0.3f, 0.6f));
            Invoke(nameof(Finish), 2);
        }
    }

    private void Finish()
    {
        BGMSEManager.BSInstance.SEPlayer(2);
        panelCanvas.SetActive(true);
        Invoke(nameof(EndGame), 3);
    }

    private void EndGame()
    {
        MySceneManager.Instance.SceneFadeChange("Result");
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = cameraObj.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            cameraObj.transform.position = originalPosition + Random.insideUnitSphere * magnitude;
            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraObj.transform.position = originalPosition;
    }
}
