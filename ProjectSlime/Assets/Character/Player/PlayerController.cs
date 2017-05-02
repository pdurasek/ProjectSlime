using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   private Animator animator;
   private Rigidbody2D playerRigidbody;
   [SerializeField]
   private float movementSpeed = 2f;
   private bool hasMoveOrder = false;
   private Vector2 moveOrderDestination;

   public float lastMoveY = 0;
   public float lastMoveX = 0;
   // Use this for initialization
   void Start()
   {
      DontDestroyOnLoad(gameObject);
      animator = GetComponent<Animator>();
      playerRigidbody = GetComponent<Rigidbody2D>();
      moveOrderDestination = transform.position;
   }

   // Update is called once per frame
   // TODO put movement in FixedUpdate
   void Update()
   {
      if (hasMoveOrder)
      {
         Vector2 moveLocation = Vector2.MoveTowards(transform.position, moveOrderDestination, Time.fixedDeltaTime * movementSpeed * 2);
         playerRigidbody.MovePosition(moveLocation);

         if (Vector2.Distance(playerRigidbody.position, moveOrderDestination) < 0.1)
         {
            hasMoveOrder = false;
         }
      }
      else
      {
         ProcessInputMovement();
      }
   }

   private void ProcessInputMovement()
   {
      Vector2 move_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

      if (move_vector != Vector2.zero)
      {
         animator.SetBool("isMoving", true);
         animator.SetFloat("input_x", move_vector.x);
         animator.SetFloat("input_y", move_vector.y);

         lastMoveX = move_vector.x;
         lastMoveY = move_vector.y;
      }
      else
      {
         animator.SetBool("isMoving", false);
      }

      playerRigidbody.MovePosition(playerRigidbody.position + move_vector * Time.deltaTime * movementSpeed);
   }

   public void MoveBy(Vector2 moveDestination)
   {
      hasMoveOrder = true;
      moveOrderDestination = (Vector2)transform.position + moveDestination;
   }

    void OnCollisionEnter2D(Collision2D collision2)
   {
      //Debug.Log("collison" + collision2);
   }
}
