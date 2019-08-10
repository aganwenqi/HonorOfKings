using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoZhaoBig : MonoBehaviour {

    // Use this for initialization
    public GameObject target;
	void Start () {
	}

    public void Play()
    {
        //GameObject ar = GameObject.Instantiate(target, transform.position, Quaternion.identity);
        //Destroy(ar, 2f);
        target.SetActive(true);
        target.transform.parent = null;
        Destroy(target, 2f);
        Destroy(this.gameObject);
    }
}
