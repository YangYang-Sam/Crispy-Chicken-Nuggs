using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    bool isBreath = true;

    public float MinHigh = 0.8f;
    public float MaxHigh = 0.9f;

    float y;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            //movement of breath
            if (isBreath)
            {
                y = Mathf.Lerp(y, MaxHigh, Time.deltaTime * 1f*magnitude);
                transform.localPosition = new Vector3(originalPos.x, y, originalPos.z);
                if (y >= MaxHigh - 0.01f)
                    isBreath = !isBreath;
            }
            else
            {
                y = Mathf.Lerp(y, MinHigh, Time.deltaTime * 1f*magnitude);
                transform.localPosition = new Vector3(originalPos.x, y, originalPos.z);
                if (y <= MinHigh + 0.01f)
                    isBreath = !isBreath;
            }
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
