using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersController : MonoBehaviour {

    public GameObject target;

    public float delay;

    private int num;
    public int maxNum;

    public int distance;
    public int Num
    {
        get
        {
            return num;
        }

        set
        {
            num = value;
        }
    }

    void Start () {
        StartCoroutine(Wait(delay));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);//运行到这，暂停t秒
        if (Num < maxNum)
        {
            var a = GameObject.Instantiate(target, transform.position, Quaternion.identity).GetComponent<MonsterControllers>();
            a.zongMonster = this;
            a.distances = distance;
        }

    }
}
