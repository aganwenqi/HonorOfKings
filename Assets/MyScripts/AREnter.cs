using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class AREnter : MonoBehaviour {


    public GameObject beijing;
    public GameObject right;

    public GameObject arBtn;
    public GameObject puTongBtn;

    private CameraControllers ccontrol;
    private void Start()
    {
        ccontrol = GameObject.Find("Canvas").GetComponent<CameraControllers>();
    }

    public void OnAR()
    {
        // ccontrol.uIcam.SetActive(false);
        // ccontrol.aRcam.SetActive(true);
        //ccontrol.transform.localPosition = new Vector3(0, 0, -100f);
        ccontrol.beha.enabled = true;
        puTongBtn.SetActive(true);
        
        beijing.SetActive(false);
        right.SetActive(false);
        arBtn.SetActive(false);
        //
    }
    public void UpAR()
    {
        //ccontrol.uIcam.SetActive(true);
        //ccontrol.aRcam.SetActive(false);
        ccontrol.beha.enabled = false;
        puTongBtn.SetActive(false);
        
        beijing.SetActive(true);
        right.SetActive(true);
        arBtn.SetActive(true);
        // maincam.GetComponent<VuforiaBehaviour>().enabled = false;
    }
}
