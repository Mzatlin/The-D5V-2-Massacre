using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBar : MonoBehaviour
{
    PlayerSprint sprint => GetComponent<PlayerSprint>();
    [SerializeField]
    Slider sprintSlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sprint != null)
        {
            sprintSlider.value = sprint.SprintAmount/100;
        }
    }
}
