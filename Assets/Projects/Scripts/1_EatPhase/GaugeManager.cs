using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform FatStatsBar;
    [SerializeField]
    private RectTransform ProteinStatsBar;
    [SerializeField]
    private RectTransform CarbohydratesStatsBar;

    [SerializeField]
    private HumanStatus humanStatus;

    [SerializeField]
    private float DisAdd = 1;

    float currentVelocityf = 0;
    float currentVelocityp = 0;
    float currentVelocityc = 0;


    void Start()
    {
        FatStatsBar.localScale = new Vector2(0, FatStatsBar.localScale.y);
        ProteinStatsBar.localScale = new Vector2(0, ProteinStatsBar.localScale.y);
        CarbohydratesStatsBar.localScale = new Vector2(0, CarbohydratesStatsBar.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        //ä…Ç‚Ç©Ç…ÉQÅ[ÉWÇÃílÇ™ïœâª
        float currentDashPTfat = Mathf.SmoothDamp(FatStatsBar.localScale.x, humanStatus.HumanFatValue / DisAdd, ref currentVelocityf, 10 * Time.deltaTime);
        FatStatsBar.localScale = new Vector2(currentDashPTfat, FatStatsBar.localScale.y);

        float currentDashPTpro = Mathf.SmoothDamp(ProteinStatsBar.localScale.x, humanStatus.HumanProteinValue / DisAdd, ref currentVelocityp, 10 * Time.deltaTime);
        ProteinStatsBar.localScale = new Vector2(currentDashPTpro, ProteinStatsBar.localScale.y);

        float currentDashPTcar = Mathf.SmoothDamp(CarbohydratesStatsBar.localScale.x, humanStatus.HumanCarbohydratesValue / DisAdd, ref currentVelocityc, 10 * Time.deltaTime);
        CarbohydratesStatsBar.localScale = new Vector2(currentDashPTcar, CarbohydratesStatsBar.localScale.y);
    }
}
