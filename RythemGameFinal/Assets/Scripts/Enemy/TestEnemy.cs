using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    Rigidbody2D testEnemy;
    Player playerProperties;
    TestLevel audioInformation;
    bool comboBreak;

    [SerializeField] GameObject audioController;
    float musicCurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        testEnemy = GetComponent<Rigidbody2D>();
        playerProperties = GameObject.FindWithTag("Player").GetComponent<Player>();
        audioInformation = GameObject.FindWithTag("MusicController").GetComponent<TestLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        TestMovement();
    }

    void TestMovement()
    {
        musicCurrentTime = audioInformation.GetCurrentTime();
       
        transform.position += new Vector3(-_enemySpeed * musicCurrentTime * _timeFromPlayer, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckPlayerCollision(collision);
    }

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
