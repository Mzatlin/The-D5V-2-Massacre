using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnDeath : HandleDeathBase
{
    Camera cam => Camera.main;
    protected override void HandleDie()
    {
        AkSoundEngine.PostEvent("Play_DeathTransition", cam.gameObject);
    }
}
