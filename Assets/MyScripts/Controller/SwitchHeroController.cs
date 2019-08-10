using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHeroController : MonoBehaviour {

    public PeopleModelController people;
    //0鲁班，1孙尚香，2李白，3花木兰
    public void WhoEnter(int i)
    {
        people.PlayWho(i);
    }
}
