using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionPanel : BasePanel {

    private HeroSelectionController heroSControl;

    public PeopleModelController peopleModel;

    private AudioSource beijing_yinye;

    private AudioSource thissource;

    void Start () {
        heroSControl = GetComponent<HeroSelectionController>();
        heroSControl.back.onClick.AddListener(OnEnterBack);
        
        
    }

    //前进按钮
    void OnEnterFront()
    {
        
    }
    //后退按钮
    void OnEnterBack()
    {
        uiMng.PopPanel();
        peopleModel.HideAllModels();
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        if(beijing_yinye == null)
            beijing_yinye = GameObject.FindGameObjectWithTag("Respawn").GetComponent<AudioSource>();

        if(thissource == null)
            thissource = GetComponent<AudioSource>();

        this.transform.localScale = Vector3.one;
        beijing_yinye.Stop();
        thissource.Play();
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public override void OnPause()
    {
        base.OnPause();
        this.transform.localScale = Vector3.zero;
        beijing_yinye.Play();
        thissource.Stop();
    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public override void OnResume()
    {
        base.OnResume();
        this.transform.localScale = Vector3.one;
        beijing_yinye.Stop();
        thissource.Play();
    }

    /// <summary>
    /// 界面不显示,退出这个界面，界面被关系
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this.transform.localScale = Vector3.zero;
        beijing_yinye.Play();
        thissource.Stop();
    }
}
