using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelOnClick : MonoBehaviour
{
    public string levelName = "";
    public void ReloadLevel()
    {
        GameObject mainCamera = FindObjectOfType<Camera>().gameObject;
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
