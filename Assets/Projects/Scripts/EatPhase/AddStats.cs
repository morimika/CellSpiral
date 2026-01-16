using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStats : MonoBehaviour
{
    [SerializeField]
    private HumanStatus human;

    private FoodData food;

    //H‚×•¨‚ÉG‚ê‚½‚çƒqƒg‚Ö’Ç‰Á
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            food = collision.gameObject.GetComponent<GetFoodData>().foodData;
            //‰–b’Ç‰Á
            human.HumanFatValue += food.Fat;
            //‚½‚ñ‚Ï‚­’Ç‰Á
            human.HumanProteinValue += food.Protein;
            //’Y…’Ç‰Á
            human.HumanCarbohydratesValue += food.Carbohydrates;
        }
    }
}
