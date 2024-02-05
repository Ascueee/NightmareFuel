using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Class Data")]
    Enemy enemyCheckStatus;
    Player playerStatus;
    bool isAttacking;
    int enemyPoints;
    bool attackCoolDown;
    [SerializeField] float coolDownTimer;
    float timerReset;
    public bool comboBreak;


    [Header("Rythem Data")]
    bool isInEarly;
    bool isInGood;
    bool isInPerfect;
    bool isHoldNote;
    [SerializeField] int earlyMultiplier;
    [SerializeField] int goodMultiplier;
    [SerializeField] int perfectMultiplier;

    [Header("Note Data")]
    public GameObject[] levelNotes;
    public int index;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<Player>();
        timerReset = coolDownTimer;
        UpdateAttackNote(index);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCheck();
        CanAttack();
        AttackCoolDownUpdate();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AttackCoolDownUpdate();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    //updates the tag as well as the array so that the game can access the next object
     public void UpdateAttackNote(int index)
    {
        if(index < levelNotes.Length) {
            var currentEnemey = levelNotes[index];
            enemyCheckStatus = currentEnemey.GetComponent<Enemy>();
            isHoldNote = enemyCheckStatus.GetIsHoldNote();
        }
    }


    //checks the status of where the enemies are and what their status is
    void UpdateCheck()
    {
        
        isInEarly = enemyCheckStatus.GetInEarly();
        isInGood = enemyCheckStatus.GetInGood();
        isInPerfect = enemyCheckStatus.GetInPerfect();
    }

    void AttackCoolDownUpdate()
    {
        if(attackCoolDown == true)
        {
            if(coolDownTimer > 0)
            {
                coolDownTimer -= Time.deltaTime;
            }
            else
            {
                attackCoolDown = false; 
            }
        }
    }


    //checks if the enemy is in any of the attack areas and then attacks the enemy if the plater can
    void CanAttack()
    {
        //checks if the assigned note is a hold note or not
        if(isHoldNote != true)
        {
            //checks if the input key is pressed
            if (Input.GetMouseButtonDown(0) && attackCoolDown == false)
            {
                //checks what multiplier position the note is in and if so then it updates the player score accordingly
                if (isInEarly == true)
                {

                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();
                    enemyPoints = enemyPoints * earlyMultiplier;
                    playerStatus.SetPlayerScore(enemyPoints);
                    playerStatus.SetPlayerCombo(comboBreak);

                    attackCoolDown = true;
                    coolDownTimer = timerReset;
                    index++;
                    UpdateAttackNote(index);


                }
                else if (isInGood == true)
                {
                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();
                    enemyPoints = enemyPoints * goodMultiplier;
                    playerStatus.SetPlayerScore(enemyPoints);
                    playerStatus.SetPlayerCombo(comboBreak);

                    attackCoolDown = true;
                    coolDownTimer = timerReset;
                    index++;
                    UpdateAttackNote(index);
                }
                else if (isInPerfect == true)
                {
                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();
                    enemyPoints = enemyPoints * perfectMultiplier;
                    playerStatus.SetPlayerScore(enemyPoints);
                    playerStatus.SetPlayerCombo(comboBreak);

                    attackCoolDown = true;
                    coolDownTimer = timerReset;
                    index++;
                    UpdateAttackNote(index);


                }
            }
        }
        else if(isHoldNote == true)
        {
            //checks if the player is holding down the mouse button and checks if the cooldown is down
            if (Input.GetMouseButton(0) && attackCoolDown == false)
            {
                if(isInEarly == true)
                {
                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();
                    

                }
                else if(isInGood == true)
                {
                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();

                   

                    
                }
                else if (isInPerfect == true)
                {
                    comboBreak = false;
                    enemyCheckStatus.CheckCondition(true);
                    enemyPoints = enemyCheckStatus.GetEnemyPoints();
                    
                }
            }
            else
            {
                enemyCheckStatus.CheckCondition(false);
            }
        }
    }
}
