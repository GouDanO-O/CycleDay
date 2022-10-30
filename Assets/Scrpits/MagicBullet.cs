using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    private GameObject player;

    private float lifeTime = 10f;

    private Vector3 direction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        transform.position += 5 * transform.right * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "KunKun")
        {
            Destroy(gameObject);
            KunKunManager.instance.healthy -= 3;
        }
        else if(collision.gameObject.layer==6)
        {
            Destroy(gameObject);
        }
    }
}
