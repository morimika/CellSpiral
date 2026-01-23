using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateCharaStats")]
public class CharaStats : ScriptableObject
{
    [Label("キャラ：プレハブ")]
    public GameObject CharaObj;
    [Label("キャラ：立ち絵画像")]
    public Sprite CharaStandImage;
    [Label("キャラ：操作画像")]
    public Sprite CharaImage;
    [Label("キャラ：勝利画像")]
    public Sprite CharaWinImage;
    [Label("キャラ：敗北画像")]
    public Sprite CharaLoseImage;
    [Label("弾：画像")]
    public Sprite Bullet;
    [Label("基礎体力")]
    public int DefHp;
    [Label("基礎攻撃力")]
    public int DefAttack;
    [Label("基礎移動速度")]
    public int DefMoveSpeed;
    [Label("基礎防御力")]
    public int DefDefence;
    [Label("見出し")]
    public string TitleText;
    [Label("説明"), TextArea]
    public string InfomationText;
}
