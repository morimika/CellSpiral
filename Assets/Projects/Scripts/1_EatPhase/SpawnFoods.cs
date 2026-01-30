using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnFoods : MonoBehaviour
{
    public static SpawnFoods instance;

    [Header("したレーン")]
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

    [Header("胃")]

    [SerializeField]
    private GameObject foodObj;
    [SerializeField]
    private Transform foodObjGeneTra;

    void Start()
    {
        //初期設定
        GanarateTime = 0;
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        //一定時間ごと生成
        //時間が0になったら
        if (GanarateTime <= 0)
        {
            //ランダムでリストからピック
            int picFood = Random.Range(0, foodsList.FoodLists[kindRotation % 3].FoodDatas.Count);
            Debug.Log("食べ物：" + picFood);
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

    /// <summary>
    /// 胃に生成するものを取得し生成
    /// </summary>
    /// <param name="foodData"></param>
    public void StmObjGenerator(FoodData foodData)
    {
        float ram = Random.Range(-0.3f, 0.3f);
        var obj =Instantiate(foodObj, new Vector2(foodObjGeneTra.position.x+ ram, foodObjGeneTra.position.y), Quaternion.identity);
        obj.GetComponent<GetFoodData>().foodData = foodData;
        obj.GetComponent<SpriteRenderer>().sprite = foodData.FoodImage;
    }

}
