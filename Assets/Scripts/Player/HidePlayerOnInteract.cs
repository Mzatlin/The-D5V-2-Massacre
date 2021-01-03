using System.Collections;
using UnityEngine;

public class HidePlayerOnInteract : HandleInteractionBase
{
    public Transform player;
    Vector3 originalPlayerPosition;
    Vector2 lockerPosition;
    public PlayerStateSO state;
    Collider2D playerCollider;
    SpriteRenderer playerSprite;
    Rigidbody2D playerRigidbody2D;
    IInteractionStats interactionStats => GetComponent<IInteractionStats>();
    bool isHiding = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerCollider = player.GetComponent<Collider2D>();
        playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        lockerPosition = transform.position;
        originalPlayerPosition = player.transform.position;
    }

    protected override void HandleInteract()
    {
        TogglePlayerHide();
    }

    void TogglePlayerHide()
    {
        if (playerCollider != null && playerSprite != null && playerRigidbody2D != null)
        {
            playerCollider.enabled = !playerCollider.enabled;
            playerSprite.enabled = !playerSprite.enabled;
            playerRigidbody2D.gravityScale = 0;
            playerRigidbody2D.velocity = Vector2.zero;
            state.isInteracting = !state.isInteracting;
            StartCoroutine(DelayToggle());
        }
    }

    void ChangePlayerPosition()
    {
        if (isHiding)
        {
            originalPlayerPosition = player.transform.position;
            player.transform.position = new Vector3(lockerPosition.x,player.transform.position.y, player.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHiding && Input.GetKeyDown(KeyCode.E))
        {
            TogglePlayerHide();
        }
    }
    IEnumerator DelayToggle()
    {
        yield return new WaitForSeconds(0.1f*Time.deltaTime);
        isHiding = !isHiding;
        ChangePlayerPosition();
        interactionStats.CanInteract = !interactionStats.CanInteract;
        base.HandleInteract();
    }
}
