using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class RandomSprite : MonoBehaviour
{
    [Header("Sprite Arrays")]
    [SerializeField] Sprite[] basicNoteSprites;
    [SerializeField] Sprite[] holdNoteSprites;
    [SerializeField] SpriteRenderer holdNoteChild;
    SpriteRenderer spriteRend;
    bool isHoldNote;
    Color orange = new Color(1f, 0.64f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        isHoldNote = GetComponent<Enemy>().GetIsHoldNote();
        

        CheckTypeNote();
        
    }

    void CheckTypeNote()
    {
        if(isHoldNote == false)
        {
            RandomBaseNoteSprite();
        }
        else
        {
            RandomHoldNoteSprite();
        }
    }

    void RandomBaseNoteSprite()
    {
        
        int randIndex = Random.Range(0, basicNoteSprites.Length);
        var sprite = basicNoteSprites[randIndex];
        spriteRend.sprite = sprite;
        

    }

    void RandomHoldNoteSprite()
    {
        int randIndex = Random.Range(0,holdNoteSprites.Length);
        var sprite = holdNoteSprites[randIndex];
        holdNoteChild.sprite = sprite;

        if(randIndex == 0)
        {
            spriteRend.color = orange;
        }
        else if(randIndex == 1)
        {
            spriteRend.color = Color.red;
        }
        
    }
}
