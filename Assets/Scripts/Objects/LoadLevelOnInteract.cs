using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//LoadLevelOnComplete
public class LoadLevelOnInteract : MonoBehaviour
{
    public string sceneName;
    GameObject mainCamera;
    ICompleteGame Complete => GetComponent<ICompleteGame>();

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;

        if(Complete != null)
        {
            Complete.OnComplete += HandleComplete;
        }
    }

    void OnDestroy()
    {
        if(Complete != null)
        {
            Complete.OnComplete -= HandleComplete;
        }    
    }

    private void HandleComplete()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
