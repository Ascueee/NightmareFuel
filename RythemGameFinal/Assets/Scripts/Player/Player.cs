using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] int _playerHealth;
    [SerializeField] int _playerScore;
    [SerializeField] int _playerCombo;

    [SerializeField] GameObject glitchManager;
    [SerializeField] GameObject CamManager;

    [Header("Attack Data")]
    [SerializeField] PlayerAttack playerAttack;
    public static int scoreTracker;
    public static int ComboTracker;
    public static int healthTracker;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTracker = _playerScore;
        ComboTracker = _playerCombo;
        healthTracker = _playerHealth;

        //if (_playerHealth <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    //Getter methods related to the player
    public int GetPlayerHealth()
    {
        return _playerHealth;
    }

    public int GetPlayerScore()
    {
        return _playerScore;
    }

    public int GetPlayerCombo()
    {
        return _playerCombo;
    }



    //setter methods which update current variables
    public void PlayerDamage(int damage)
    {
        _playerHealth = _playerHealth - damage;

        //if the player is hit then it access the index and increments it
        playerAttack.index++;
        //checks if the index is less the the level notes length so it does not throw a index error
        if(playerAttack.index < playerAttack.levelNotes.Length)
        {
            //calls the update note to update the game object
            playerAttack.UpdateAttackNote(playerAttack.index);
        }
        
        if (_playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerScore(int enemyScore)
    {
        _playerScore = _playerScore + enemyScore;
    }

    public void SetPlayerCombo(bool comboBreak)
    {
        if(comboBreak == false)
        {
            _playerCombo++;
            
        }
        else
        {
            bool juiceEffects = true;
            glitchManager.GetComponent<GlitchManager>().IsGlitchActive(juiceEffects);
            CamManager.GetComponent<CameraShake>().IsCameraShakeActive(juiceEffects);
             _playerCombo = 0;
        }
    }
}
