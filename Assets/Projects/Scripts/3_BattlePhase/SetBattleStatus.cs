using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBattleStatus : MonoBehaviour
{
    public static float HP;
    public static float ATTACK;
    public static float MOVESPEED;
    public static float DEFENCE;

    [SerializeField]
    private bool isDebug = false;

    public CharaStats playerChara;

    private void Awake()
    {
        if (isDebug == true)
        {
            DebugPic();
        }
        else
        {
            playerChara = SettingManager.picChara;
        }

        HP = 0;
        ATTACK = 0;
        MOVESPEED = 0;
        DEFENCE = 0;

        //‘Ì—Í = Šî‘b‘Ì—Í * (3+(æ“¾‰¿/100 + æ“¾ƒ^ƒ“ƒpƒN/100))
        HP = playerChara.DefHp * (3 + ((SettingManager.FatStats / 100) + (SettingManager.ProteinStats / 100)));
        //UŒ‚—Í = Šî‘bUŒ‚—Í * (1+(æ“¾ƒ^ƒ“ƒpƒN/1000 + æ“¾’Y…‰»•¨/1500))
        ATTACK = playerChara.DefAttack * (1 + ((SettingManager.ProteinStats / 1000) + (SettingManager.CarbohydratesStats / 1500)));
        //ˆÚ“®‘¬“x = (Šî‘bˆÚ“®‘¬“x * (1+(æ“¾ƒ^ƒ“ƒpƒN/1000 + æ“¾’Y…‰»•¨/1500 - æ“¾‰¿/2000)))/5
        MOVESPEED = (playerChara.DefMoveSpeed * (1 + ((SettingManager.ProteinStats / 1000) + (SettingManager.CarbohydratesStats / 1500) - (SettingManager.FatStats / 2000))))/4;
        //–hŒä—Í = Šî‘b–hŒä—Í * (1+(æ“¾‰¿/1500 + æ“¾’Y…‰»•¨/1000))
        DEFENCE = playerChara.DefDefence * (1 + ((SettingManager.FatStats / 1500) + (SettingManager.CarbohydratesStats / 1000)));
        this.GetComponent<SpriteRenderer>().sprite = playerChara.CharaImage;
    }

    private void DebugPic()
    {
        //debug
        SettingManager.FatStats = 600;
        SettingManager.ProteinStats = 600;
        SettingManager.CarbohydratesStats = 600;
        SettingManager.picChara = playerChara;
    }
}
