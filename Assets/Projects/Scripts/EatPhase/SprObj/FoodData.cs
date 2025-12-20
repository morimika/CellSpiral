using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(menuName ="CreateFoodData")]
public class FoodData : ScriptableObject
{
    [Label("料理：名前")]
    public string FoodName;
    [Label("料理：画像")]
    public Sprite FoodImage;
    [Label("脂質：増加値")]
    public int Fat;
    [Label("タンパク質：増加値")]
    public int Protein;
    [Label("炭水化物：増加値")]
    public int Carbohydrates;
}
