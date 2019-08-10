using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomItemPanel : BasePanel {

    // Use this for initialization
    public RoomListController roomListControl;

    private bool quit = false;
	void Start () {
        //roomListControl = transform.Find("List").GetComponent<RoomListController>();
        roomListControl.front.onClick.AddListener(OnEnterFront);
        roomListControl.back.onClick.AddListener(OnEnterBack);
    }

    //前进按钮
    void OnEnterFront()
    {
        uiMng.PushPanel(UIPanelType.HeroSelection);
        quit = false;
        SetIsZero();
    }
    //后退按钮
    void OnEnterBack()
    {
        uiMng.PopPanel();
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        roomListControl.PlayForwards();
        quit = true;
        SetIsZero();
    }
    void SetIsZero()
    {
        if (quit)
            this.transform.localScale = Vector3.one;
        else
            this.transform.localScale = Vector3.zero;
    }
    /// <summary>
    /// 界面暂停
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
        roomListControl.PlayReverses();
        Invoke("SetIsZero", 1);
        quit = false;
    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();
        roomListControl.PlayForwards();
        quit = true;
        SetIsZero();
    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        roomListControl.PlayReverses();
        Invoke("SetIsZero", 1);
        quit = false;
    }
}
