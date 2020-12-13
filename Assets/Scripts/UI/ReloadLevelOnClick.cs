using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelOnClick : MonoBehaviour
{
    public string levelName = "";
    GameObject mainCamera;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
    }

    public void ReloadLevel()
    { 
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
