using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnStart : MonoBehaviour
{
    IDoor Door => GetComponent<IDoor>();
    // Start is called before the first frame update
    void Start()
    {
        if (Door != null)
        {
            Door.OpenDoor();
        }
    }

}
