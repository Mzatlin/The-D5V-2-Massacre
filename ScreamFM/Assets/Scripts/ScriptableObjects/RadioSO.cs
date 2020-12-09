using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Radio")]
public class RadioSO : ScriptableObject
{
    public string radioName = "";
    public Vector2 location = Vector3.zero;
}
