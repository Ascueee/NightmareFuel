using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Position Information")]
    [SerializeField] Transform camTrans;
    Vector3 camOriginalpos;

    [Header("Shake information")]
    [SerializeField] float shakeTimer;
    [SerializeField] float shakeAmount;
    [SerializeField] float decreaseFactor;
    float resetTimer;
    float resetShakeAmount;
    bool inEffect;


    // Start is called before the first frame update
    void Start()
    {
        resetTimer = shakeTimer;
        resetShakeAmount = shakeAmount;
        camOriginalpos = camTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(inEffect == true)
        {
            if (Player.healthTracker > 0)
            {


                if (shakeTimer > 0)
                {
                    camTrans.localPosition = camOriginalpos + Random.insideUnitSphere * shakeAmount;

                    shakeTimer -= Time.deltaTime * decreaseFactor;
                    shakeAmount -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    shakeTimer = resetTimer;
                    shakeAmount = resetShakeAmount;
                    camTrans.localPosition = camOriginalpos;
                    inEffect = false;
                }
            }
        }
    }

    //setter methods
    public void IsCameraShakeActive(bool juiceEffects)
    {
        inEffect = juiceEffects;
    }
}
