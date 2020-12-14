using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSpawn : MonoBehaviour
{
    public Transform introSpawn;
    public Transform regularSpawn;
    public SaveStateSO save;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(save != null)
        {
            if (save.IsOpeningComplete)
            {
                SetSpawn(regularSpawn);
            }
            else
            {
                SetSpawn(introSpawn);
            }
        }        
    }

    void SetSpawn(Transform spawnPoint)
    {
        if(player != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
