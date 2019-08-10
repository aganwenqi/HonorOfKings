using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class BeginGame : MonoBehaviour {


    private GameFacadeLogin gamefacade;
    public GameObject zhuce;
    private void Awake()
    {
        transform.Find("LoginButton").GetComponent<Button>().onClick.AddListener(LoginGameUIScenen);

        transform.DOScale(0, 0.0f);//播放渐变
    }
    public void OnEnter(GameFacadeLogin gamefacade)
    {
        this.gamefacade = gamefacade;
    }


    //进入动画
    public void EnterAnim()
    {
        gameObject.SetActive(true);

        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.5f);//播放渐变
        zhuce.SetActive(true);
    }
    //隐藏动画
    private void LoginGameUIScenen()
    {
        SceneManager.LoadScene("UIBegin");
    }

}
