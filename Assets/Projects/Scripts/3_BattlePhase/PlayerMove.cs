using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private SetBattleStatus battleStatus;

    [SerializeField] private float movespeed;
    public static float hp;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float scaleX;

    [SerializeField]
    private RectTransform playerHpGauge;
    float currentVelocity = 0;
    private float DisAdd = 1;

    [SerializeField]
    private BossAI bossInfo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        battleStatus = GetComponent<SetBattleStatus>();
        movespeed = SetBattleStatus.MOVESPEED;
        hp = SetBattleStatus.HP;
        scaleX=this.transform.localScale.x;
    }
    void Update()
    {
        //start return
        if (GameManager.IsGame == false) return;

        if (hp <= 0)
        {
            hp = 0;
            playerHpGauge.localScale = new Vector2(0, playerHpGauge.localScale.y);
            GameManager.instance.Pank(true);
        }

        //move
        Vector2 pos = moveInput.normalized * movespeed * Time.deltaTime;
        rb.MovePosition(rb.position + pos);

        //ŠÉ‚â‚©‚ÉƒQ[ƒW‚Ì’l‚ª•Ï‰»
        //‘S‘Ì‚ð1‚Æ‚µ‚ÄŽÀ”’l‚ÅŒ¸‚ç‚µ‚Ä‚àŠ„‡‚ÅŒ¸­‚·‚é
        float currentDashPTfat = Mathf.SmoothDamp(playerHpGauge.localScale.x, (hp/ SetBattleStatus.HP) / DisAdd, ref currentVelocity, 10 * Time.deltaTime);
        playerHpGauge.localScale = new Vector2(currentDashPTfat, playerHpGauge.localScale.y);

        if (hp <= 0)
        {
            hp = 0;
            Debug.LogError("Debug:GameOver");
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (GameManager.IsGame == false) return;
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.x < 0)
        {
            this.transform.localScale=new Vector2(-scaleX, this.transform.localScale.y);
        }
        else if (moveInput.x > 0)
        {
            this.transform.localScale = new Vector2(scaleX, this.transform.localScale.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //“GUŒ‚—Í‚ð‘ã“ü
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(bossInfo.Attack);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //“GUŒ‚—Í‚ð‘ã“ü
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Damage(bossInfo.Attack);
        }
    }

    private void Damage(float damage)
    {
        //ƒ_ƒ[ƒW‚ª0ˆÈã‚ ‚é‚Æ‚«HpŒ¸­
        if(damage - SetBattleStatus.DEFENCE > 10)
        {
            hp -= (damage - SetBattleStatus.DEFENCE);
        }
        else
        {
            hp -= 10;
        }
        //“_–Å
    }

    [Button]
    private void DebugDamage()
    {
        Damage(10);
    }
}
