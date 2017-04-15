using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   private Animator animator;
   private EnemyAttackController attackController;
   private Rigidbody2D enemyRigidbody;
   private GameObject player;
   [SerializeField] private float movementSpeed = 5f;
   [SerializeField] private float aggroRange = 10f;
   private float timeSinceLastRandomMove = 0;

   void Start()
   {
      animator = GetComponent<Animator>();
      attackController = GetComponentInChildren<EnemyAttackController>();
      enemyRigidbody = GetComponent<Rigidbody2D>();
      player = GameObject.FindGameObjectWithTag("Player");
   }

   void Update()
   {
      // TODO: fix enemy collision so they can't move each other (and player as well, current fix for player is enemies having much greater mass than the player)
      timeSinceLastRandomMove += Time.deltaTime;
      float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

      if (distanceFromPlayer > aggroRange && timeSinceLastRandomMove > 0.1)
      {
         moveRandom();
      }
      else if (distanceFromPlayer <= aggroRange && !isAttacking())
      {
         moveToPlayer();
      }
   }

   private bool isAttacking()
   {
      return (animator.GetBool("isAttacking") || animator.GetCurrentAnimatorStateInfo(0).IsName("BlobAttack"));
   }

   private void moveRandom()
   {
      Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
      enemyRigidbody.MovePosition(enemyRigidbody.position + randomVector * Time.deltaTime * movementSpeed);
      timeSinceLastRandomMove = 0;
   }

   private void moveToPlayer()
   {
      Vector2 targetLocation = Vector2.MoveTowards(enemyRigidbody.position, player.transform.position, Time.deltaTime * movementSpeed / 5.0f);
      enemyRigidbody.MovePosition(targetLocation);
   }

   void Attack()
   {
      if (animator.GetBool("isAttacking"))
      {
         attackController.DoMeleeDamage();
      }
   }
}
