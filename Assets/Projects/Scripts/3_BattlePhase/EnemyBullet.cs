using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 0.5f;

    [SerializeField]
    public Vector2 frightOffset = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        //start return
        if (GameManager.IsGame == false)
        {
            Destroy(this.gameObject);
            return;
        }

        this.transform.position = new Vector2(this.transform.position.x + (frightOffset.x * Time.deltaTime)
                                            , this.transform.position.y + ((frightOffset.y - bulletSpeed) * Time.deltaTime));

        if (this.gameObject.transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
