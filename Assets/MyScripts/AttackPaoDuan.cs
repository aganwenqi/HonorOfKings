using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AttackPaoDuan : MonoBehaviour {

    public GameObject zidan;
    public Transform zidanPos;
    public GameObject lizi1;
    public GameObject lizi2;
    public GameObject dapao;
    public Transform dapaoPos;
    private int attackCollider = Animator.StringToHash("attackCollider");
    private int bigCollider = Animator.StringToHash("BigCollider");

    //获取动画控制器
    private Animator ani;

    //普通攻击
    private bool isattack1 = false;

    //大招攻击
    private bool isbigAttack = false;


    public UnityEvent daZhao;
    public UnityEvent xiaoZhao;
    private AudioSource source;
    public AudioClip da;
    public AudioClip xiao;
    void Start () {
        ani = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //攻击
        if(ani.GetFloat(attackCollider) >= 0.29f)
        {
            if (isattack1 == false)
            {
                Attack1();
                isattack1 = true;
            }
                
        }
        else if(isattack1)
        {
            isattack1 = false;
        }


        if (ani.GetFloat(bigCollider) >= 0.18f)
        {
            if (isbigAttack == false)
            {
                BigAttack();
                isbigAttack = true;
            }
                
        }
        else if (isbigAttack)
        {
            isbigAttack = false;
        }
    }

    //打出攻击
    void Attack1()
    {
        if (xiaoZhao != null)
            xiaoZhao.Invoke();
        source.clip = xiao;
        source.Play();
        GameObject.Instantiate(zidan, zidanPos.transform.position, zidanPos.transform.rotation);
        GameObject.Instantiate(lizi2, zidanPos.transform.position, zidanPos.transform.rotation);
    }
    void BigAttack()
    {
        if (daZhao != null)
            daZhao.Invoke();
        source.clip = da;
        source.Play();
        GameObject.Instantiate(dapao, dapaoPos.transform.position, dapaoPos.transform.rotation);
        GameObject.Instantiate(lizi1, dapaoPos.transform.position, dapaoPos.transform.rotation);
        
    }
}
