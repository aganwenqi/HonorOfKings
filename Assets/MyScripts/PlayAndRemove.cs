using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndRemove : MonoBehaviour {

    public GameObject target;
    public float time;
	void Start () {
        if(time >= 0)
            Destroy(target,time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
