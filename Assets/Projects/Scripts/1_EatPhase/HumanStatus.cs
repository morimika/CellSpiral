using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStatus : MonoBehaviour
{
    [Label("‰¿—Ê")]
    public int HumanFatValue = 0;
    [Label("ƒ^ƒ“ƒpƒN¿—Ê")]
    public int HumanProteinValue = 0;
    [Label("’Y…‰»•¨—Ê")]
    public int HumanCarbohydratesValue = 0;

    private void Start()
    {
        HumanFatValue = 0;
        HumanProteinValue = 0;
        HumanCarbohydratesValue = 0;
    }

    void Update()
    {
        //0ˆÈ‰º‚Í‚ ‚è“¾‚È‚¢
        if (HumanFatValue < 0) HumanFatValue = 0;
        if (HumanProteinValue < 0) HumanProteinValue = 0;
        if (HumanCarbohydratesValue < 0) HumanCarbohydratesValue = 0;

        SettingManager.FatStats=HumanFatValue;
        SettingManager.ProteinStats=HumanProteinValue;
        SettingManager.CarbohydratesStats=HumanCarbohydratesValue;
    }
}
