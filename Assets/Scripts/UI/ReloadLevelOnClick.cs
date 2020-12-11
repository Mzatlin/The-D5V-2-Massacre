using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelOnClick : MonoBehaviour
{
    public void ReloadLevel()
    {
        GameObject mainCamera = FindObjectOfType<Camera>().gameObject;
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
