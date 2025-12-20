using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFoods : MonoBehaviour
{
    //デフォルトプレハブ
    [SerializeField]
    private GameObject defaultPrefab;
    //食べ物リスト
    [SerializeField]
    private FoodDataList foodsList;
    //スポーン場所
    [SerializeField]
    private RectTransform spawnPos;
    //食べ物移動速度
    [SerializeField,Label("食べ物移動速度")]
    private float duration;

    [SerializeField]
    private int kindRotation = 0;

    //生成クールタイム
    [SerializeField,Label("生成間隔：時間(秒)")]
    private protected float GanarateCoolTime;
    private float GanarateTime;

    void Start()
    {
        //初期設定
        GanarateTime = 0;
    }

    void Update()
    {
        //一定時間ごと生成
        //時間が0になったら
        if (GanarateTime <= 0)
        {
            //ランダムでリストからピック
            int picFood = Random.Range(0, foodsList.FoodLists[kindRotation % 3].FoodDatas.Count);
            //リストの情報をプレハブにあてはめ生成
            //オブジェクト生成
            var obj = Instantiate(defaultPrefab, spawnPos.position, Quaternion.identity,this.transform);
            //名前変更
            obj.gameObject.name = foodsList.FoodLists[kindRotation % 3].FoodDatas[picFood].name;
            //移動速度設定
            obj.GetComponent<MoveFoodImage>().moveFoodDuration = duration;
            //画像適応
            obj.GetComponent<Image>().sprite = foodsList.FoodLists[kindRotation % 3].FoodDatas[picFood].FoodImage;
            //ステータス適応
            obj.GetComponent<GetFoodData>().foodData = foodsList.FoodLists[kindRotation % 3].FoodDatas[picFood];

            //種類変更
            kindRotation++;
            //時間リセット
            GanarateTime = GanarateCoolTime;
        }
        else
        {
            //カウントダウン
            GanarateTime -= Time.deltaTime;
        }

    }
}
