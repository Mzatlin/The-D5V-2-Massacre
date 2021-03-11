using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour, ICameraShake
{
    private bool isShaking = false;
    public bool IsShaking => isShaking; 
    private IEnumerator shake = null;
    private float elapsedTime = 0f;
    private Vector3 orignalPosition;

    void Awake()
    {
        orignalPosition = transform.position;
    }

    public void TryShake(float duration, float magnitude)
    {
        if (!isShaking)
        {
            orignalPosition = transform.position;
            isShaking = true;
            shake = Shake(duration, magnitude);
            StartCoroutine(shake);
        }
    }

    public void ResetShake()
    {
        if(shake != null)
        {
            isShaking = false;
            StopCoroutine(shake);
            transform.position = orignalPosition;
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float x = Random.Range(-0.15f, 0.15f) * magnitude;
            float y = Random.Range(-0.15f, 0.15f) * magnitude;

            transform.position += new Vector3(x, y, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
            Debug.Log("Shake");
        }
        transform.position = orignalPosition;
        isShaking = false;
    }

}
