using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateFoodDataList")]
public class FoodDataList : ScriptableObject
{
    [Label("H‚×•¨ƒŠƒXƒg")]
    public List<ChildLists> FoodLists = new List<ChildLists>();
}

[System.Serializable]
public class ChildLists
{
    public string ListName;
    public List<FoodData> FoodDatas = new List<FoodData>();

    public ChildLists(List<FoodData> _list)
    {
        FoodDatas = _list;
    }
}