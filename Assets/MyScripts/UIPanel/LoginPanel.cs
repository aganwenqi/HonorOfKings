using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class LoginPanel : BasePanel
{
    private InputField usernameIF;
    private InputField passwordIF;
    private MessagePanel msgPanel;

    private GameFacadeLogin gamefacade;
    private void Awake()
    {
        usernameIF = transform.Find("UserNameLabel/UserNameInput").GetComponent<InputField>();
        passwordIF = transform.Find("PasswordLabel/PasswordInput").GetComponent<InputField>();
        msgPanel = transform.Find("MessagePanel").GetComponent<MessagePanel>();

        transform.Find("LoginButton").GetComponent<Button>().onClick.AddListener(OnLoginClick);

        transform.DOScale(0, 0.0f);//播放渐变
        gameObject.SetActive(false);
    }
    private void Start()
    {
        // Invoke("OnEnter", 1);
    }
    public void OnEnter(GameFacadeLogin gamefacade)
    {
        this.gamefacade = gamefacade;
        EnterAnim();
    }
    //退出栈
    public override void OnExit()
    {
        base.OnExit();
        HideAnim();
        //gameObject.SetActive(false);
    }

    //退出
    private void OnCloseClick()
    {
        PlayClickSound();
        uiMng.PopPanel();
        //HideAnim();
    }
    //登录
    private void OnLoginClick()
    {
        PlayClickSound();
        string msg = "";
        if (string.IsNullOrEmpty(usernameIF.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(passwordIF.text))
        {
            msg += "密码不能为空 ";
        }
        if (msg != "")
        {
            msgPanel.ShowMessage(msg); return;
        }
        if (Verify(usernameIF.text, passwordIF.text))
        {
            msg += "登陆成功";
            Invoke("HideAnim", 0.5f);

        }
        else
        {
            msg += "账户或密码错误 ";

        }
        msgPanel.ShowMessage(msg);
    }
    //验证密码
    public bool Verify(string user, string passd)
    {
        if (user == "admin" && passd == "123456")
            return true;
        return false;
    }

    //进入动画
    private void EnterAnim()
    {
        gameObject.SetActive(true);

        transform.localScale = Vector3.zero;
        transform.DOScale(2, 1);//播放渐变

    }
    //隐藏动画
    private void HideAnim()
    {
        transform.DOScale(0, 0.5f).OnComplete(() => this.HideAnimDelay());//播放渐变
    }

    private void HideAnimDelay()
    {
        gamefacade.BeginGame();
        this.enabled = false;
    }
}
