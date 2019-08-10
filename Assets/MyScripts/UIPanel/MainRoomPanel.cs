using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainRoomPanel : BasePanel {

    // Use this for initialization

    public GameObject gg;
	void Start () {
        Button btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(ButtonEnter);
        if (jintaia.static_sss == false)
        {
            jintaia.static_sss = true;
            gg.SetActive(true);
        }
    }

    //按钮按下
    private void ButtonEnter()
    {
        uiMng.PushPanel(UIPanelType.RoomItem);  
    }
    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        this.transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
        this.transform.localScale = Vector3.zero;
    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();
        this.transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this.transform.localScale = Vector3.zero;
    }
}
