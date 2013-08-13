﻿using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {
	public GameObject blasterExplosion;
	
	private Transform myTransform;
	private float projectileSpeed = 10;
	private bool expended = false;
	private RaycastHit hit;
	private float range = 1.5f;
	private float expireTime = 5;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		
		
		StartCoroutine(DestroyMyselfAfterSomeTime());
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
		
		if (Physics.Raycast(myTransform.position, myTransform.up, out hit, range) && !expended) {
			if (hit.transform.tag == "Floor") {
				expended = true;
				
				Instantiate(blasterExplosion, hit.point, Quaternion.identity);
				
				myTransform.renderer.enabled = false;
				myTransform.light.enabled = false;
			}
		}
	}
	
	IEnumerator DestroyMyselfAfterSomeTime() {
		yield return new WaitForSeconds(expireTime);
		
		Destroy(myTransform.gameObject);
	}
}
