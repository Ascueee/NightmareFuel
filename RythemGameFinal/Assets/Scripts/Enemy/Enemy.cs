using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*WHAT THIS SCRIPT DOES: This script holds the data of the enemies to be able to recreate many different types of enemies
     as well as data to be able to be accessed by different scripts mainly the player script*/

    [Header("Enemy Data")]
    [SerializeField] public int _enemyDamage; 
    [SerializeField] public int _enemyPointDrop;
    [SerializeField] public float _enemySpeed;
    [SerializeField] public float _timeFromPlayer;
    [SerializeField] public bool _canMove;
    [SerializeField] public bool _inEarly; 
    [SerializeField] public bool _inGood; 
    [SerializeField] public bool _inPerfect;
    
    [SerializeField] public bool _isDead = false;
    [SerializeField] bool _isHoldNote = false;

    //Getter Methods which allow the data to be accessed by different scripts
    public int GetEnemyDamage()
    {
        return _enemyDamage;
    }

    public int GetEnemyPoints()
    {
        return _enemyPointDrop;
    }

    public float GetEnemySpeed()
    {
        return _enemySpeed;
    }

    public bool GetInEarly()
    {
        return _inEarly;
    }

    public bool GetInGood()
    {
        return _inGood;
    }

    public bool GetInPerfect()
    {
        return _inPerfect;
    }

    public bool GetIsHoldNote()
    {
        return _isHoldNote;
    }

    //setter variables that update current variables

    //checks if the player has attacked the enemy and if so it destroys the game object
    public virtual void CheckCondition(bool checkDeath)
    {
        
        _isDead = checkDeath;

        if (_isDead == true && _isHoldNote == false)
        {
            Destroy(gameObject);
  
        }
    }

    public void UpdateEnemySpeed(int newSpeed)
    {
        _enemySpeed = newSpeed;
    }


    //miscellaneous Methods which hold specifc data for the enemey
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollisionOfTiming(collision);
    }



    //checks if the enemy has hit any of the rythem hit boxes
    void CheckCollisionOfTiming(Collider2D collision)
    {
        if (collision.gameObject.tag == "Early")
        {
            
            _inEarly = true;
            _inGood = false;
            _inPerfect = false;
            
        }

        if (collision.gameObject.tag == "Okay")
        {
            
            _inEarly = false;
            _inGood = true;
            _inPerfect = false;
            
        }

        if (collision.gameObject.tag == "Perfect")
        {
            
            _inEarly = false;
            _inGood = false;
            _inPerfect = true;
            
        }
    }
}
