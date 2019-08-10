using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShouShang : MonoBehaviour {

    public UnityEvent shaoHp;
    public UnityEvent siDiao;
    public int hp;

    private bool kaiwan = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "xiaozhao")
            BeiAttack_xiao();
        else if (other.tag == "dazhao")
            BeiAttack_Da();
    }
    public void BeiAttack_Da()
    {
        if (hp < 0) return;
        
        hp -= 35;
        if (hp < 0)
            if (siDiao != null)
                siDiao.Invoke();
        if (hp < 30 && kaiwan)
        {
            shaoHp.Invoke();
            kaiwan = false;
        }
    }
    public void BeiAttack_xiao()
    {
        if (hp < 0) return;
        
        hp -= 10;
        if (hp < 0)
            if (siDiao != null)
                siDiao.Invoke();
        if (hp < 30 && kaiwan)
        {
            shaoHp.Invoke();
            kaiwan = false;
        }
    }
}
