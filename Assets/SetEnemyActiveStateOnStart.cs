using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyActiveStateOnStart : MonoBehaviour
{
    public SaveStateSO save;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        if(save != null && save.IsOpeningComplete)
        {
            enemy.SetActive(true);
        }
        else
        {
            enemy.SetActive(false);
        }
    }
}
