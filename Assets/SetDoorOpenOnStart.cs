using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDoorOpenOnStart : MonoBehaviour
{
    public SaveStateSO save;
    public List<GameObject> doors = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (save != null && save.IsOpeningComplete)
        {
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        foreach(GameObject door in doors)
        {
            var doorInteract = door.GetComponent<IDoor>();
            if(doorInteract != null)
            {
                doorInteract.OpenDoor();
            }
        }
    }
}
