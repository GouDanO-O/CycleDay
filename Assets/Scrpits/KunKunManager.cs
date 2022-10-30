using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class KunKunManager : MonoBehaviour
{
    public static KunKunManager instance;

    public int healthy = 100;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject ball;

    [SerializeField] private Transform AirPos;

    [SerializeField] private float rangeArea;

    private Vector2 initialPos;

    private Animator animator;

    private Collider2D kunkun;

    private float fireTime = 3.0f;

    private bool canFire;

    private int fireRate;

    private int fireCount=3;

    private float idleTime = 2;

    [SerializeField] private Slider healthyBar;

    [SerializeField] private GameObject endPanel;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        kunkun= GetComponent<Collider2D>();
    }
    private void Update()
    {
        BallMangager();
        if (canFire&&fireCount>0)
        {
            FireBallInGround();
        }
        if(fireCount==0)
        {
            animator.Play("Idle");
            idleTime -= Time.deltaTime;
            if(idleTime<=0)
            {
                fireCount = 3;
                idleTime = 2;
            }
        }
        HealthyManager();
        if(healthy <=0)
        {
            Death();
        }
        print(healthy);
    }
    private void BallMangager()
    {
        fireTime -= Time.deltaTime;
        if(fireTime <= 0)
        {
            fireTime = 3;
            fireRate = 0;
            fireCount--;
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }
    private void FireBallInGround()
    {
        animator.Play("Attack");
        if (fireRate==0)
        {           
            for (int i = -5; i < 2; i++)
            {
                GameObject balls = Instantiate(ball);
                Vector3 dir = Quaternion.Euler(0, i * 15, 0) * -transform.right;
                balls.transform.position = firePoint.position + dir * 1.0f;
                balls.transform.rotation = Quaternion.Euler(0, 0, i * 15);
            }
            fireRate++;
        }        
    }
    private void HealthyManager()
    {
        healthyBar.value = healthy * 0.01f;
    }
    private void Death()
    {
        animator.Play("Death");
        StartCoroutine(End());
    }
    IEnumerator End()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 0;
        endPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
