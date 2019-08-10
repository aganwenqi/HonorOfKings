using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListController : MonoBehaviour {

    public Button front;
    public Button back;

    public TweenPosition[] twps;
	void Start () {
       // twps = GetComponentsInChildren<TweenPosition>();
    }
    public void PlayForwards()
    {
        foreach (TweenPosition i in twps)
            i.PlayForward();
    }
    public void PlayReverses()
    {
        foreach (TweenPosition i in twps)
            i.PlayReverse();
    }
}
