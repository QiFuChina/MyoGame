using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float camera_height=10.0f;
	public float camera_distance=10.0f;
	private Transform player;
	private Transform camera;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").transform;
		camera = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		camera.eulerAngles =new Vector3(camera.eulerAngles.x,player.eulerAngles.y,camera.eulerAngles.z);
		float angle = camera.eulerAngles.y;
		float deltaX = camera_distance * Mathf.Sin(angle * Mathf.PI /180 );

		//float deltaY = camera_distance * Mathf.Sin(angle * Mathf.PI /180 );
		float deltaZ = camera_distance * Mathf.Cos (angle * Mathf.PI / 180);
		camera.position = new Vector3 (player.position.x-deltaX, player.position.y+ camera_height, player.position.z-deltaZ );
	}
}
