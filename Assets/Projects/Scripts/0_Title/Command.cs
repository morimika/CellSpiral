using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    [SerializeField]
    private GameObject commandObj;

    [SerializeField]
    private CharaStats charaStats;

    private void Start()
    {
        commandObj.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)&& Input.GetKey(KeyCode.C)&& Input.GetKey(KeyCode.M))
        {
            commandObj.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            commandObj.SetActive(false);
        }
    }

    public void SetAllHuman()
    {
        SettingManager.CarbohydratesStats = 450;
        SettingManager.FatStats = 450;
        SettingManager.ProteinStats = 450;
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }

    public void SetProHuman()
    {
        SettingManager.CarbohydratesStats = 400;
        SettingManager.FatStats = 400;
        SettingManager.ProteinStats = 600;
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }

    public void SetFatHuman()
    {
        SettingManager.CarbohydratesStats = 400;
        SettingManager.FatStats = 600;
        SettingManager.ProteinStats = 400;
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }

    public void SetSleepHuman()
    {
        SettingManager.CarbohydratesStats = 600;
        SettingManager.FatStats = 400;
        SettingManager.ProteinStats = 400;
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }

    public void SetNoman()
    {
        SettingManager.CarbohydratesStats = 10;
        SettingManager.FatStats = 10;
        SettingManager.ProteinStats = 10;
        MySceneManager.Instance.SceneFadeChange("CharaSet");
    }

    public void ToWin()
    {
        GameManager.BattleTime = 999;
        PlayerMove.hp = 999;
        SetBattleStatus.HP = 999;
        SetBattleStatus.ATTACK = 999;
        SetBattleStatus.DEFENCE = 999;
        SetBattleStatus.MOVESPEED = 9;
        SettingManager.picChara = charaStats;
        ResultManager.isWin = true;
        MySceneManager.Instance.SceneFadeChange("Result");
    }

    public void ToLose()
    {
        SettingManager.picChara = charaStats;
        ResultManager.isWin = false;
        MySceneManager.Instance.SceneFadeChange("Result");
    }
}
