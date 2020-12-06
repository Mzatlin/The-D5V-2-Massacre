using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreObjectCollision : MonoBehaviour
{
    [SerializeField]
    Transform enemy;
    public Collider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        colliders = enemy.GetComponents<Collider2D>();
        foreach(Collider2D collider in colliders)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
        }
       
    }
}
