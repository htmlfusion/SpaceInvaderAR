using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {

	public float speed;
	
	void Start()
	{
		  GetComponent<Rigidbody>().velocity = transform.forward * speed;
		//GetComponent<Rigidbody>().velocity = new Vector3(0,0, 5 * speed);
	}
}
