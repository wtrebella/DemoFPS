using UnityEngine;
using System.Collections;

public class FireBlaster : MonoBehaviour {
	public GameObject blaster;
	
	private Transform myTransform;
	private Transform cameraHeadTransform;
	private Vector3 launchPosition = new Vector3();
	private float fireRate = 0.2f;
	private float nextFire = 0;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		cameraHeadTransform = myTransform.FindChild("CameraHead");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire Weapon") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			
			launchPosition = cameraHeadTransform.TransformPoint(0, 0, 0.2f);
			
			Instantiate(blaster, launchPosition, Quaternion.Euler(cameraHeadTransform.eulerAngles.x + 90, myTransform.eulerAngles.y, 0));
		}
	}
}
