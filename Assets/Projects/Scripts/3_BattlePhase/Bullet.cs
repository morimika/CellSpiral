using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //start return
        if (GameManager.IsGame == false)
        {
            Destroy(this.gameObject);
            return;
        }
        float addtraY = this.transform.position.y + (bulletSpeed * Time.deltaTime);
        this.transform.position = new Vector2(this.transform.position.x, addtraY);

        if (this.gameObject.transform.position.x > 7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
