using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacadeLogin : MonoBehaviour {

    public LoginPanel loginPanel;
    public BeginGame beginGame;
    
    private AUdioManager audioMng;
    
    private void Awake()
    {
       
    }
    void Start()
    {
        Invoke("InitManager", 1);
    }
  
  
    private void InitManager()
    {

        loginPanel.OnEnter(this);
        beginGame.OnEnter(this);

    }
    //开始游戏界面
    public void BeginGame()
    {
        beginGame.EnterAnim();
    }

    //播放音乐
    public void PlayBgSound(string soundName)
    {
        return;
        audioMng.PlayBgSound(soundName);
    }
    public void PlayNormalSound(string soundName)
    {
        return;
        audioMng.PlayNormalSound(soundName);
    }
}
