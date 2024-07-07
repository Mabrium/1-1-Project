using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSS : MonoBehaviour
{
    public float shakeAmount = 0.5f;
    public float shakeTime = 0.3f;

    public IEnumerator Shake(float ShakeAmount, float ShakeTime)
    {
        float timer = 0;
        while (timer <= ShakeTime)
        {
            Camera.main.transform.position =
                (Vector3)Random.insideUnitCircle * ShakeAmount;
            timer += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
    }
}
