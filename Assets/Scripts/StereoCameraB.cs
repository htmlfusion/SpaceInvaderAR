﻿using UnityEngine;
using System.Collections;

public class StereoCameraB : MonoBehaviour {
	
	public string eye;
	//public string screenName = "Screen";
	
	public GameObject screen;
	
	public float left = -0.2F;
	public float right = 0.2F;
	public float top = 0.2F;
	public float bottom = -0.2F;
	
	public float screenWidth;
	public float screenHeight;
	
	
	private int increment;
	private float io = 0; 
	//private GameObject screen;
	
	// Use this for initialization
	void Start () {
		//screen = GameObject.Find(screenName);
		Renderer mf = screen.GetComponent<Renderer>();
		screenWidth = mf.bounds.size.x;
		screenHeight = mf.bounds.size.y;

		// 6 cm ~3in, * 25 (world scale) / 2 
		/*
		if (eye == "left") {
			io = -35;
		}
		if (eye == "right") {
			io = 35;
		}*/
	}

	void OnDrawGizmosSelected() {
		Camera camera = GetComponent<Camera>();
		Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(p, 0.1F);
	}

	// Update is called once per frame
	void Update () {

		Camera cam = GetComponent<Camera>();
		
		float leftScreen = screenWidth / 2.0f + transform.position.x + io;
		left = -cam.nearClipPlane / -transform.position.z * leftScreen;
		
		float rightScreen = screenWidth / 2.0f - transform.position.x + io;
		right = cam.nearClipPlane / -transform.position.z * rightScreen;
		
		float bottomScreen = - screenHeight / 2.0f - transform.position.y;
		bottom = cam.nearClipPlane / -transform.position.z * bottomScreen;
		
		float topScreen = screenHeight / 2.0f - transform.position.y;
		top = cam.nearClipPlane / -transform.position.z * topScreen;

		//Vector3 relativePos = screen.transform.position - transform.position;
		//Quaternion rotation = Quaternion.LookRotation(relativePos);
		//transform.rotation = rotation;

		//Debug.Log (screen.transform.position);

		//GetComponent<Camera>().ResetProjectionMatrix();
		//Quaternion lookAtRotation = Quaternion.LookRotation(screen.transform.position, Vector3.forward);	
		// Lerp the camera's rotation between it's current rotation and the rotation that looks at the player.
		//transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation,  Time.deltaTime);
		//transform.rotation = Quaternion.LookRotation(screen.transform.position, Vector3.forward);
	}
	
	void LateUpdate() {
		Camera cam = GetComponent<Camera>();
		Matrix4x4 m = PerspectiveOffCenter(left, right, bottom, top, cam.nearClipPlane, cam.farClipPlane);
		//cam.ResetProjectionMatrix ();
		cam.projectionMatrix = m;
	}
	
	static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far) {
		float x = 2.0F * near / (right - left);
		float y = 2.0F * near / (top - bottom);
		float a = (right + left) / (right - left);
		float b = (top + bottom) / (top - bottom);
		float c = -(far + near) / (far - near);
		float d = -(2.0F * far * near) / (far - near);
		float e = -1.0F;
		Matrix4x4 m = new Matrix4x4();
		m[0, 0] = x;
		m[0, 1] = 0;
		m[0, 2] = a;
		m[0, 3] = 0;
		m[1, 0] = 0;
		m[1, 1] = y;
		m[1, 2] = b;
		m[1, 3] = 0;
		m[2, 0] = 0;
		m[2, 1] = 0;
		m[2, 2] = c;
		m[2, 3] = d;
		m[3, 0] = 0;
		m[3, 1] = 0;
		m[3, 2] = e;
		m[3, 3] = 0;
		return m;
	}
	
}
