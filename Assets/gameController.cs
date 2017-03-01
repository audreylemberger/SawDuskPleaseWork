using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class gameController : MonoBehaviour {
	public GameObject leftController;
	public GameObject rightController;
	public Vector3 dispenseLocation;
	public bool woodDispensed1;
	public bool woodDispensed2;
	public bool woodDispensed3;
	public bool woodDispensed4;
	public GameObject wood;
	public GameObject smallWood;
	public GameObject mediumWood;
	public GameObject largeWood;
	public GameObject buttonWood;
	public GameObject buttonSmallWood;
	public GameObject buttonMediumWood;
	public GameObject buttonLargeWood;
	public Vector3 rotation;

	private void Start()
	{			
		woodDispensed1 = false;
		woodDispensed2 = false;
		woodDispensed3 = false;
		woodDispensed4 = false;
		dispenseLocation = new Vector3 (-1.34f, 5.355f, -10.962f);
		rotation = new Vector3 (0, -90, 0);

	}

	public void Update ()
	{
		GameObject leftTouched;
		GameObject rightTouched;
		leftTouched = leftController.GetComponent<VRTK_InteractTouch> ().GetTouchedObject ();
		rightTouched = rightController.GetComponent<VRTK_InteractTouch> ().GetTouchedObject ();
		//Debug.Log ("touched");
		if (leftTouched || rightTouched == buttonWood) {
			if (woodDispensed1 == false) { 
				Instantiate (mediumWood, dispenseLocation, Quaternion.Euler(rotation));
				woodDispensed1 = true;
			} 
		} else {
			woodDispensed1 = false;
		}
	
		if (leftTouched || rightTouched == buttonSmallWood) {
			if (woodDispensed2 == false) { 
				Instantiate (smallWood, dispenseLocation, Quaternion.Euler(rotation));
				woodDispensed2 = true;
			} 
		}else {
			woodDispensed2 = false;
		}
		if (leftTouched || rightTouched == buttonMediumWood) {
			if (woodDispensed3 == false) { 
				Instantiate (wood, dispenseLocation, Quaternion.Euler(rotation));
				woodDispensed3 = true;
			} 
		}else {
			woodDispensed3 = false;
		}
		if (leftTouched || rightTouched == buttonLargeWood) {
			if (woodDispensed4 == false) { 
				Instantiate (largeWood, dispenseLocation, Quaternion.Euler(rotation));
				woodDispensed4 = true;
			} 
		}else {
			woodDispensed4 = false;
		}
				
	}
}
	
