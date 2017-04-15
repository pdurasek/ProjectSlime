using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidni;
    [SerializeField] private float movementSpeed = 2f;

    public float lastMoveY = 0;
    public float lastMoveX = 0;
	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	    rigidni = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
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

        rigidni.MovePosition(rigidni.position + move_vector * Time.deltaTime * movementSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision2)
    {
        //Debug.Log("collison" + collision2);
    }
}
