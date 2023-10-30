using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    

    private Animator anim;
    private Movement movement;
    private float cooldownTimer = Mathf.Infinity;
    public Transform point1;
    public Transform point2;
    public float attackRange1;
    public float attackRange2;
    public LayerMask enmylayer;
    AudioManager audioManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            Skill1();
        }
        else if (Input.GetKeyDown(KeyCode.S) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            Skill2();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Skill1()
    {
        audioManager.PlaySFX(audioManager.chieu1);
        anim.SetTrigger("skill1");
        cooldownTimer = 0;
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(point1.position, attackRange1, enmylayer);
        
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<monsterMovement>().TakeDame(6f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (point1 != null)
        {
            Gizmos.DrawWireSphere(point1.position, attackRange1);
        }
        if (point2 != null)
        {
            Gizmos.DrawWireSphere(point2.position, attackRange2);
        }
        return;
    }

    private void Skill2()
    {
        audioManager.PlaySFX(audioManager.chieu2);
        anim.SetTrigger("skill2");
        cooldownTimer = 0;
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(point2.position, attackRange2, enmylayer);
        
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<monsterMovement>().TakeDame(5f);
        }
    }

}
