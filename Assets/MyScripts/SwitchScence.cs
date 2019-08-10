using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScence : MonoBehaviour {

    public void UIBegin()
    {
        SceneManager.LoadScene("UIBegin");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
}
