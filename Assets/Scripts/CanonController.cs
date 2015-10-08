using UnityEngine;
using System.Collections;
using Leap;

public class CanonController : MonoBehaviour {
	
	public float speed;
	
	//Assume a reference to the scene HandController object
	public HandController handCtrl;

	public AudioClip shootSound;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	private Quaternion canonRotation;
	private AudioSource source;

	void Awake () {

		source = GetComponent<AudioSource> ();

	}

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
			nextShot.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
			source.Play (); 
			//source.PlayOneShot(shootSound, 1F);

		}
		

	}
	void FixedUpdate ()
	{
		
	}
	
}
