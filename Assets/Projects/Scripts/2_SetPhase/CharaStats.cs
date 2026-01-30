using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateCharaStats")]
public class CharaStats : ScriptableObject
{
    [Label("ƒLƒƒƒ‰F–¼‘O")]
    public string Name;
    [Label("ƒLƒƒƒ‰F—§‚¿ŠG‰æ‘œ")]
    public Sprite CharaStandImage;
    [Label("ƒLƒƒƒ‰F‘€ì‰æ‘œ")]
    public Sprite CharaImage;
    [Label("ƒLƒƒƒ‰FŸ—˜‰æ‘œ")]
    public Sprite CharaWinImage;
    [Label("ƒLƒƒƒ‰F”s–k‰æ‘œ")]
    public Sprite CharaLoseImage;
    [Label("’eF‰æ‘œ")]
    public Sprite Bullet;
    [Label("Šî‘b‘Ì—Í")]
    public int DefHp;
    [Label("Šî‘bUŒ‚—Í")]
    public int DefAttack;
    [Label("Šî‘bˆÚ“®‘¬“x")]
    public int DefMoveSpeed;
    [Label("Šî‘b–hŒä—Í")]
    public int DefDefence;
    [Label("Œ©o‚µ")]
    public string TitleText;
    [Label("à–¾"), TextArea]
    public string InfomationText;
}
