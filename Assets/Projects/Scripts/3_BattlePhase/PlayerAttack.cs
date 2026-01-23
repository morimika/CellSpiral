using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private SetBattleStatus battleStatus;
    private CharaStats charaStats;

    [SerializeField]
    private GameObject bulletObj;
    private GameObject obj;

    [SerializeField]
    private float bulletDelay = 0.3f;
    private float deftime;

    // Start is called before the first frame update
    void Start()
    {
        battleStatus = GetComponent<SetBattleStatus>();
        charaStats = battleStatus.playerChara;
        deftime = bulletDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //start return
        if(GameManager.IsGame == false) return;

        deftime-=Time.deltaTime;
        if (deftime < 0)
        {
            //’e”­ŽË
            obj = Instantiate(bulletObj, transform.position, Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite=charaStats.Bullet;

            //ƒŠƒZƒbƒg
            deftime = bulletDelay;
        }
    }
}
