using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    [SerializeField] private Transform camTransform;

    // How long the object should shake for.
    [SerializeField] private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField] private float shakeAmount = 0.7f;
    [SerializeField] private float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            float amount = shakeAmount * Mathf.Clamp(shakeDuration * 10, 1, 10);
            camTransform.localPosition = originalPos + Random.insideUnitSphere * amount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void EnableShaking(float duration)
    {
        shakeDuration = duration;
    }
}
