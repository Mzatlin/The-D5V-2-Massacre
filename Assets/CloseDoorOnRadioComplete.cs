using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnRadioComplete : MonoBehaviour
{
    public RadioCompletionListSO radio;
    public List<GameObject> doors = new List<GameObject>();
    [SerializeField]
    LayerMask playerMask;
    void CloseDoor()
    {

        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                var doorToggle = door.GetComponent<IDoor>();
                if (doorToggle != null)
                {
                    doorToggle.CloseDoor();
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerMask & 1 << collision.gameObject.layer) != 0)
        {
            if (radio != null && radio.HasWon())
            {
                CloseDoor();
            }
        }
    }
}
