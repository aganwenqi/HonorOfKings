using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class MonsterControllers : MonoBehaviour {

    //追踪距离
    public int distances;

    public MonstersController zongMonster;
    //普通攻击
    public UnityEvent attackOk;
    public UnityEvent bigattackOk;
    private int attack1 = Animator.StringToHash("attack1");
    private int bigAttack = Animator.StringToHash("BigAttack");
    private int walk = Animator.StringToHash("Forward Input");
    private int death = Animator.StringToHash("death");

    private NavMeshAgent nav;
    private Transform target;
    private Animator ani;

    //普通攻击
    private bool pugong = false;
    public float speed;

    //大招
    private bool dazhao = false;

    //死掉
    private bool sidiao = false;
    void Start () {
        nav = this.GetComponent<NavMeshAgent>();
        ani = this.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnDisable()
    {
        zongMonster.Num--;
    }
    // Update is called once per frame
    void Update () {
        if (sidiao) return;

        float dis = Vector3.Distance(transform.position,target.position);
        if(dis > distances)//原地待命
        {
            //transform.position = transform.position;
            nav.destination = transform.position;
            ani.SetFloat(walk, 0);
        }
        else if(dis < distances && dis > 2.5f)//追啊
        {
            if(!dazhao)
                MoveAndRotation();
        }
        else
        {
            
            nav.destination = transform.position;
            PuAttack();
        }

	}

    //普通攻击
    void PuAttack()
    {
        if(pugong == false)
        {
            if (dazhao) return;
            else
            {
                var animatorInfo = ani.GetCurrentAnimatorStateInfo(0);
                ani.SetFloat(walk, 0);
                ani.SetBool(attack1, true);
                Invoke("PuAttack_DY", 4f);
                pugong = true;
                if (attackOk != null)
                    attackOk.Invoke();
            }
            
        }
    }
    void PuAttack_DY()
    {
        ani.SetBool(attack1, false);

        pugong = false;
    }

    //大招激活
    public void EnableBigAttack()
    {
        dazhao = true;
        ani.SetFloat(walk, 0);
        ani.SetBool(bigAttack, true);
        Invoke("BigAttack_DY", 2f);
        this.transform.localScale = this.transform.localScale * 2f;
        //sidiao = true;
        if (bigattackOk != null)
            bigattackOk.Invoke();
    }
    void BigAttack_DY()
    {
        ani.SetBool(bigAttack, false);
        dazhao = false;
        //sidiao = false;
    }
    //移动
    void MoveAndRotation()
    {
        nav.destination = target.position;
        //控制移动
        float newSpeed = Mathf.LerpAngle(ani.GetFloat(walk), speed, Time.deltaTime);
        ani.SetFloat(walk, newSpeed);
            //控制旋转

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.transform.rotation.eulerAngles), Time.deltaTime * 100);
    }

    //死掉
    public void Death()
    {
        sidiao = true;
        ani.SetTrigger(death);
        nav.destination = transform.position;
        Destroy(this.gameObject,5f);
    }
}
