using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //获取动画控制器
    private Animator ani;
    //获取遥感脚本
    public UIjoysticks touch;

    private int attack1 = Animator.StringToHash("attack1");
    private int bigAttack = Animator.StringToHash("BigAttack");

    private float speed = 4.0f;

    //攻击
    private bool isattack1 = false;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    //加速
    public void On_AddSpeed(bool quit)
    {
        if(quit)
            speed = 8;
        else
            speed = 4;
    }

    //普通攻击
    public void On_Attack1(bool quit)
    {
        if (isattack1 == false)
        {
            ani.SetBool(attack1, quit);
            isattack1 = quit;
        }
    }

    //大招攻击
    public void On_BigAttack(bool quit)
    {
        if (isattack1 == false)
        {
            ani.SetBool(bigAttack, quit);
            isattack1 = quit;
        }    
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Attack();

        if (!isattack1)
            MoveAndRotation();
    }

    //攻击
    void Attack()
    {
        var animatorInfo = ani.GetCurrentAnimatorStateInfo(0);
        //攻击完毕
        if (ani.IsInTransition(0) == false)
        {
            if (animatorInfo.IsName("Movement"))
            {
                ani.SetBool(attack1, false);
                ani.SetBool(bigAttack, false);
                isattack1 = false;
            }
            else if(animatorInfo.IsName("Movement"))
            {
                
                isattack1 = false;
            }
        }
            
    }
    //移动
    void MoveAndRotation()
    {
        //hor = 遥感脚本中的localPosition.x
        float hor = touch.Horizontal;
        //hor = 遥感脚本中的localPosition.y
        float ver = touch.Vertical;

        Vector3 direction = new Vector3(hor, 0, ver);
        if (direction != Vector3.zero)
        {
            //控制移动
            float newSpeed = Mathf.LerpAngle(ani.GetFloat("Forward Input"), speed, Time.deltaTime);
            ani.SetFloat("Forward Input", newSpeed);
            //控制旋转
            
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);

            Vector3 ve = new Vector3(0, 0, ani.GetFloat("Forward Input") * 0.01f);

            transform.Translate(ve);

        }
        else
        {
            //停止移动
            float newSpeed = Mathf.Lerp(ani.GetFloat("Forward Input"), 0, Time.deltaTime * 5);
            ani.SetFloat("Forward Input", 0);
        }
    }
}
