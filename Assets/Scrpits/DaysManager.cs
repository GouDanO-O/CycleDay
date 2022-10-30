using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;

public class DaysManager : MonoBehaviour
{
    private AudioSource audioSource;

    private bool audioIsComplete;

    [SerializeField] private Text loopDays;

    private int days;

    [SerializeField] private Text lastTimes;

    private float lastTime=100;

    [SerializeField] private Image blackOutImage;

    private float a=255;

    private bool b;

    public GameObject[] DontDestroyObjects;

    //是否已经存在DontDestroy的物体
    private static bool isExist;

    void Awake()
    {
        if (!isExist)
        {
            for (int i = 0; i < DontDestroyObjects.Length; i++)
            {
                //如果第一次加载，将这些物体设为DontDestroy
                DontDestroyOnLoad(DontDestroyObjects[i]);
            }

            isExist = true;
        }
        else
        {
            for (int i = 0; i < DontDestroyObjects.Length; i++)
            {
                //如果已经存在，则删除重复的物体
                Destroy(DontDestroyObjects[i]);
            }
        }
        
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        b = true;
    }
    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 7)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        IsPlayComplete();
    }
    private void IsPlayComplete()
    {
        lastTime -= Time.fixedDeltaTime;
        if (lastTime < 0)
        {
            lastTime = 0;
        }
        loopDays.text = "第" + days + "次循环";
        lastTimes.text = "剩余" + (int)lastTime + "秒";
        StartCoroutine(AudioIsFinished(audioSource.clip.length));
    }
    IEnumerator AudioIsFinished(float time)
    {
        yield return new WaitForSeconds(time);
        if (b)
        {
            days++;
            lastTime = 125;
            ReturnToBed();
            b = false;
        }       
        BlackEffect();
    }
    private void BlackEffect()
    {
        a -= 20;
        blackOutImage.color=new Color(blackOutImage.color.r, blackOutImage.color.g, blackOutImage.color.b,a);   
    }
    private void ReturnToBed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
