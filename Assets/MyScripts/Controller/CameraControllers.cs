using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class CameraControllers : MonoBehaviour {

    // Use this for initialization
    public GameObject aRcam;
    public GameObject uIcam;

    public VuforiaBehaviour beha;
    void Start () {
        // uIcam = GameObject.FindGameObjectWithTag("MainCamera");
        //aRcam = GameObject.Find("ARCamera");
        //aRcam.SetActive(false);
        uIcam.GetComponent<VuforiaBehaviour>().enabled = false;
        //uIcam.GetComponent<v>
    }
    void Delays()
    {
        aRcam.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
	}
}
