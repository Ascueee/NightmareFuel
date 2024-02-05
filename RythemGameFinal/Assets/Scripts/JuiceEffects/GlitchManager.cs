using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    [Header("glitch information")]
    [SerializeField] float glitchTimer;
    float resetTimer;
    bool inEffect;
    Renderer rend;
   

    // Start is called before the first frame update
    void Start()
    {
        resetTimer = glitchTimer;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inEffect == true)
        {
            glitchTimer -= Time.deltaTime;

            if (glitchTimer > 0)
            {
                rend.enabled = true;
            }
            else
            {
                rend.enabled = false;
                glitchTimer = resetTimer;
                inEffect = false;
            }
        }
    }

    public void IsGlitchActive(bool juiceEffects)
    {
        inEffect = juiceEffects;

    }

    
}
