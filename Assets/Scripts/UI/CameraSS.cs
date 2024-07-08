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
            Vector3 pos = 
                (Vector2)Random.insideUnitCircle * ShakeAmount;
            pos.z = -10;
            Camera.main.transform.position = pos;
            timer += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);
    }
}
