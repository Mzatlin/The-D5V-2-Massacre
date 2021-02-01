using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMap : MonoBehaviour
{
    public Canvas map;
    IPlayerState player => GetComponent<IPlayerState>();
    // Start is called before the first frame update
    void Start()
    {
        if(map != null)
        {
            map.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TryActivateMap(); 
        }
    }

    void TryActivateMap()
    {
        if (player.PlayerState.IsPlayerReady())
        {
            SetMap();
        }
    }

    void SetMap()
    {
       // player.PlayerState.isPaused = !player.PlayerState.isPaused;
        map.enabled = !map.enabled;
    }
}
