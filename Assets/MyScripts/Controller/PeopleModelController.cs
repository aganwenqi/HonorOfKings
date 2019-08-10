using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleModelController : MonoBehaviour {

    public GameObject[] models;

    private int current = -1;
   

    public void HideAllModels()
    {
        if (current != -1)
            models[current].SetActive(false);
        current = -1;
    }

    public void PlayWho(int i)
    {
        //第一次进来
        if (current == -1)
        {
            models[i].SetActive(true);
            current = i;
            return;
        }

        //不进行操作
        if (current == i) return;

        models[current].SetActive(false);
        models[i].SetActive(true);
        current = i;
    }
}
