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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            Skill1();
        }
        else if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            Skill2();
        }else if (Input.GetKeyDown(KeyCode.L) && cooldownTimer > attackCooldown && movement.canAttack())
        {
            Skill3();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Skill1()
    {
        anim.SetTrigger("skill1");
        cooldownTimer = 0;
    }
    private void Skill2()
    {
        anim.SetTrigger("skill2");
        cooldownTimer = 0;
    }
    private void Skill3()
    {
        anim.SetTrigger("skill3");
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
