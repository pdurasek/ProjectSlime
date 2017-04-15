using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private int camera_x_maxMove = 0;
    [SerializeField] private int camera_y_maxMove = 4;
    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Debug.Log(transform.position.y);
	    transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -camera_x_maxMove, camera_x_maxMove), 
            Mathf.Clamp(player.transform.position.y, -camera_y_maxMove, camera_y_maxMove), 0);
	}
}
