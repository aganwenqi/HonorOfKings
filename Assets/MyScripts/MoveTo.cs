using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MoveTo : MonoBehaviour {

    public float speed;

    public GameObject pa01;
    public float delay01;

    public GameObject pa02;
    public float delay02;

    public UnityEvent play;
    void Start () {
        Destroy(this,10);
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "qiangti")
        {
            if (pa01 != null)
            {
                var ar = GameObject.Instantiate(pa01, this.transform.position, Quaternion.identity);
                Destroy(ar, delay01);
            }
            if (pa02 != null)
            {
                var ar = GameObject.Instantiate(pa02, this.transform.position, Quaternion.identity);
                Destroy(ar, delay02);
            }
            if (play != null)
                play.Invoke();
            else
                Destroy(this.gameObject);
        }
       
    }
//    private void OnCollisionEnter(Collision other)
//{
//        if (other.gameObject.tag == "qiangti")
//        {
//            if (pa01 != null)
//            {
//                var ar = GameObject.Instantiate(pa01, this.transform.position, Quaternion.identity);
//                Destroy(ar, delay01);
//            }
//            if (pa02 != null)
//            {
//                var ar = GameObject.Instantiate(pa02, this.transform.position, Quaternion.identity);
//                Destroy(ar, delay02);
//            }
//            Destroy(this.gameObject);
//        }

//    }
}
