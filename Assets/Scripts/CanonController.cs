using UnityEngine;
using System.Collections;
using Leap;

public class CanonController : MonoBehaviour {
	
	public float speed;
	
	//Assume a reference to the scene HandController object
	public HandController handCtrl;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	private Quaternion canonRotation;
	
	void Update(){
		Frame frame = handCtrl.GetFrame();
		Hand rightHand = frame.Hands.Rightmost;
		Hand leftHand = frame.Hands.Leftmost;
		//HandList handsInFrame = frame.Hands;
		
		if (rightHand.IsValid) {
			transform.position = 
				handCtrl.transform.TransformPoint (rightHand.PalmPosition.ToUnityScaled ());
			canonRotation = 
				handCtrl.transform.rotation * rightHand.Basis.Rotation (false);
			transform.rotation = canonRotation;
		}
		
		if(leftHand.IsValid)
		{
			transform.position = handCtrl.transform.TransformPoint(leftHand.PalmPosition.ToUnityScaled());
			canonRotation = handCtrl.transform.rotation * leftHand.Basis.Rotation(false);
			transform.rotation = canonRotation;
		}
		
		if ((rightHand.IsValid || leftHand.IsValid) && Time.time > nextFire)
		{
			nextFire =  Time.time + fireRate;
			GameObject nextShot = (GameObject)Instantiate (shot, shotSpawn.position, canonRotation);
			//nextShot.GetComponent<Rigidbody>().velocity = new Vector3(0,0, 5 * speed);
			//nextShot.GetComponent<Rigidbody>().velocity = canonRotation.eulerAngles;
			nextShot.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5);
		}
		

	}
	void FixedUpdate ()
	{
		
	}
	
}
