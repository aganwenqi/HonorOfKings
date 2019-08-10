using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class StopCamera : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();
        var ar = GameObject.Find("ARCamera (1)");
        if (ar != null)
            ar.SetActive(false);
    }
    void Start () {
        Application.targetFrameRate = 60;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
