using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    [SerializeField] private GameObject magicBullet;

    [SerializeField] private Transform firePoint;

    private Collider2D playerCollider;

    private float fireRate=0.5f;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        FireManage();
    }
    private void FireManage()
    {
        if(Input.GetMouseButton(0))
        {
            fireRate -= Time.deltaTime;
            if(fireRate<=0)
            {
                FireBullet();
                fireRate = 0.5f;
            }
        }
    }
    private void FireBullet()
    {
        GameObject bullet = Instantiate(magicBullet);
        bullet.transform.position = firePoint.position;
    }
}
