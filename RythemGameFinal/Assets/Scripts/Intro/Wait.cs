using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
     float time = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroTimer());
    }

    IEnumerator IntroTimer()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(1);
    }
}
