using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldEnemy : Enemy
{
    Rigidbody2D testEnemy;
    Player playerProperties;
    TestLevel audioInformation;
    [SerializeField] GameObject playerAttackGameObject;
    PlayerAttack playerHit;
    bool comboBreak;

    [SerializeField] GameObject audioController;
    float musicCurrentTime;

    //this variable is the multiplier for the hold note
    [SerializeField] float noteStretchFactor;
    [SerializeField] float stretchReducerFactor;

    // Start is called before the first frame update
    void Start()
    {
        testEnemy = GetComponent<Rigidbody2D>();
        playerProperties = GameObject.FindWithTag("Player").GetComponent<Player>();
        audioInformation = GameObject.FindWithTag("MusicController").GetComponent<TestLevel>();
        playerHit = playerAttackGameObject.GetComponent<PlayerAttack>();

        NoteStretchSize();
    }

    // Update is called once per frame
    void Update()
    {
        NoteMovement();
    }

    //this overrides the checkcondition in the base class and checks if  the 
    public override void CheckCondition(bool checkDeath)
    {
        _isDead = checkDeath;

        if(_isDead == true)
        {
            if(transform.localScale.x > 0)
            {
                //transform.localScale -= new Vector3(stretchReducerFactor, 0f, 0f);
                DecreaseObjectSize(stretchReducerFactor, new Vector3(1f, 0f, 0f));
            }
            else if (transform.localScale.x <= 0)
            {
                Destroy(gameObject);
                //updates the array once the hold note gets destroyed
                playerHit.index++;
                playerHit.UpdateAttackNote(playerHit.index);

                //when dead it gives the player set amount of points
                var enemyPoints = _enemyPointDrop;
                playerProperties.SetPlayerScore(enemyPoints);
                playerProperties.SetPlayerCombo(comboBreak);
            }
        }
    }

    //scales the object in one direction
    public void DecreaseObjectSize(float amount, Vector3 direction)
    {
        transform.position -= direction * amount / 2;
        transform.localScale -= direction * amount;
    }

    //stretches the note to the desired amount
    void NoteStretchSize()
    {
        
        var strech = transform.localScale.x * noteStretchFactor;
        transform.localScale = new Vector3(strech,transform.localScale.y,transform.localScale.z);
    }

    //this controls the movement of the enemy bringing closer to the player
    void NoteMovement()
    {
        musicCurrentTime = audioInformation.GetCurrentTime();

        transform.position += new Vector3(-_enemySpeed * musicCurrentTime * _timeFromPlayer, 0f, 0f);

    }

    //Checks if the player has touched an object
    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckPlayerCollision(collision);
    }

    //checks collision and if the enemy has hit the player
    void CheckPlayerCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            comboBreak = true;
            playerProperties.PlayerDamage(_enemyDamage);
            playerProperties.SetPlayerCombo(comboBreak);
            Destroy(gameObject);
        }
    }
}
