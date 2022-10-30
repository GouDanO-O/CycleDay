using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.EventSystems;

public class SceneManage : MonoBehaviour
{
    private bool wheatherEnter = false;

    private int scenesIndex;

    private bool isEnter=true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(wheatherEnter);
        StartCoroutine(DetetiveWheatherEnter());
        
        if (wheatherEnter)
        {           
            switch (collision.gameObject.tag)
            {
                case "Street":
                    EnterStreet();
                    break;
                case "Home":
                    EnterHome();
                    break;
                case "Home_01":
                    EnterHome_01();
                    break;
                case "Home_02":
                    EnterHome_02();
                    break;
                case "Shop":
                    EnterShop();
                    break;
                case "Factory":
                    EnterFactory();
                    break;
                case "FinalFight":
                    EnterFinalFight();
                    break;
            }
        }
    }

    private void Update()
    {
        if(DialogueLua.GetVariable("确定决战").asBool&&isEnter)
        {
            EnterFinalFight();
            isEnter = false;
        }
    }
    IEnumerator DetetiveWheatherEnter()
    {
        yield return null;
        wheatherEnter = DialogueLua.GetVariable("是否进入").asBool;
    }
    private void EnterStreet()
    {
        scenesIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        switch (scenesIndex)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene(8);
                DialogueLua.SetVariable("是否进入", false);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene(8);
                DialogueLua.SetVariable("是否进入", false);
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene(8);
                DialogueLua.SetVariable("是否进入", false);
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadScene(9);
                DialogueLua.SetVariable("是否进入", false);
                break;
            case 6:
                UnityEngine.SceneManagement.SceneManager.LoadScene(10);
                DialogueLua.SetVariable("是否进入", false);
                break;
        }        
    }
    private void EnterHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        DialogueLua.SetVariable("是否进入", false);
    }
    private void EnterHome_01()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        DialogueLua.SetVariable("是否进入", false);
    }
    private void EnterHome_02()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        DialogueLua.SetVariable("是否进入", false);
    }
    private void EnterShop()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        DialogueLua.SetVariable("是否进入", false);
    }
    private void EnterFactory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
        DialogueLua.SetVariable("是否进入", false);
    }    
    private void EnterFinalFight()
    {            
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);       
    }   
}
