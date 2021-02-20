using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelOnClick : MonoBehaviour
{
    public string levelName = "";
    public float delayTime = 0.1f;
    GameObject mainCamera;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
    }

    public void ReloadLevel()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
