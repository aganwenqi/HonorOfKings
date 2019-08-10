using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayDelay : MonoBehaviour {

    public UnityEvent playOk;

    public float delay;
	void Start () {
        Invoke("Delay",delay);
	}
    void Delay()
    {
        if (playOk != null)
            playOk.Invoke();
    }
}
