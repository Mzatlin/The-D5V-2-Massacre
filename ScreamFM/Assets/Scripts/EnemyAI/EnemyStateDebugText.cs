using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStateDebugText : MonoBehaviour
{
    EnemyStateMachine stateMachine => GetComponent<EnemyStateMachine>();
    [SerializeField]
    TextMeshProUGUI stateText;
    Vector2 canvasPosition;
    Camera camera;
    [SerializeField]
    float canvasOffsetY = 1f;
    [SerializeField]
    float canvasOffsetX = -0.5f;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        canvasPosition = camera.WorldToScreenPoint(new Vector2(transform.position.x + canvasOffsetX, transform.position.y + canvasOffsetY));
        stateText.transform.position = canvasPosition;
        if (stateMachine.CurrentState.GetType() == typeof(PatrolState))
        {
            stateText.text = "Patrolling";
        }
        else if(stateMachine.CurrentState.GetType() == typeof(ChasePlayerState))
        {
            stateText.text = "Chasing";
        }
        else if (stateMachine.CurrentState.GetType() == typeof(InvestigateObjectState))
        {
            stateText.text = "Investigating";
        }

    }
}
