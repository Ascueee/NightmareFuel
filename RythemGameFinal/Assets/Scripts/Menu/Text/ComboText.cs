using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.ComboTracker > 1)
        {
           
            text.text = "Combo: " + Player.ComboTracker.ToString();
        }
        else
        {
            text.text = ""; 
        }
    }
}
