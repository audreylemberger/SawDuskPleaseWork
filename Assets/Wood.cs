using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

public class Wood : MonoBehaviour {

	// Use this for initialization
	public GameObject empty;
	public GameObject emptyInScene;
	public bool isSticky;
	void Start () {
		isSticky = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void makeSticky(){
		isSticky = true;
		//Debug.Log("is this happening?");
	}
	//calls to make wood sticky or not sticky (might need to set a timer to see how long things are sticky)
	

	void OnCollisionEnter (Collision target) { 
		if (target.gameObject.tag.Equals ("wood") == true) { 
			//if this wood is sticky or the other wood object is sticky, connect
			if (target.gameObject.GetComponent<Wood>().isSticky || this.isSticky){
				if ((gameObject.transform.parent == null) && (target.gameObject.transform.parent == null)){
					if (((Mathf.Abs (GameObject.FindWithTag ("leftCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().x)) < .5f) &&
					    ((Mathf.Abs (GameObject.FindWithTag ("leftCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().y)) < .5f) &&
					    ((Mathf.Abs (GameObject.FindWithTag ("leftCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().z)) < .5f) &&
					    ((Mathf.Abs (GameObject.FindWithTag ("rightCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().x)) < .5f) &&
					    ((Mathf.Abs (GameObject.FindWithTag ("rightCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().y)) < .5f) &&
					    ((Mathf.Abs (GameObject.FindWithTag ("leftCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ().z)) < .5f)) {
						Debug.Log (GameObject.FindWithTag ("leftCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ());
						Debug.Log (GameObject.FindWithTag ("rightCont").GetComponent<VRTK_ControllerEvents> ().GetVelocity ());
						emptyInScene = Instantiate (empty);
						gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						target.gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						GameObject.FindWithTag ("leftCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						GameObject.FindWithTag ("rightCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						Destroy (gameObject.GetComponent<FixedJoint> ());
						Destroy (target.gameObject.GetComponent<FixedJoint> ());
						Destroy (gameObject.GetComponent<VRTK_FixedJointGrabAttach> ());
						Destroy (target.gameObject.GetComponent<VRTK_FixedJointGrabAttach> ());
						Destroy (gameObject.GetComponent<VRTK_InteractControllerAppearance> ());
						Destroy (target.gameObject.GetComponent<VRTK_InteractControllerAppearance> ());
						gameObject.GetComponent<VRTK_InteractableObject> ().enabled = false;
						target.gameObject.GetComponent<VRTK_InteractableObject> ().enabled = false;
						Destroy (gameObject.GetComponent<VRTK_InteractableObject> ());
						Destroy (target.gameObject.GetComponent<VRTK_InteractableObject> ());
						Destroy (target.gameObject.GetComponent<Rigidbody> ());
						Destroy (gameObject.GetComponent<Rigidbody> ());
						gameObject.transform.SetParent (emptyInScene.transform);
						target.gameObject.transform.SetParent (emptyInScene.transform);
						//emptyInScene.transform.SetParent(gameObject.transform);
						//target.gameObject.transform.SetParent(emptyInScene.transform);
						//Destroy(target.gameObject.GetComponent<Rigidbody>());
						//Destroy(gameObject.GetComponent<Rigidbody>());


						Debug.Log ("stuck");
						//target.gameObject.transform.SetParent(empty.transform); //sticks both wood objects together
						//gameObject.transform.SetParent(empty.transform);
						//gameObject.transform.SetParent(empty.transform);

						//Destroy(target.gameObject.GetComponent<Rigidbody>());
						//Destroy(gameObject.GetComponent<Rigidbody>());
			
						/*HingeJoint joint = gameObject.AddComponent<HingeJoint>();
				joint.connectedAnchor.Set (0, 0, 0);
				JointSpring hingeSpring = joint.spring;


				hingeSpring.spring = 100000;
				joint.spring = hingeSpring;
				joint.useSpring = true;
				joint.autoConfigureConnectedAnchor = false;
				joint.angularXMotion = ConfigurableJointMotion.Locked;
				joint.angularYMotion = ConfigurableJointMotion.Locked;
				joint.angularZMotion = ConfigurableJointMotion.Locked;
				joint.xMotion = ConfigurableJointMotion.Locked;
				joint.yMotion = ConfigurableJointMotion.Locked;
				joint.zMotion = ConfigurableJointMotion.Locked;
				joint.projectionMode = JointProjectionMode.PositionAndRotation;

				joint.connectedBody = target.gameObject.GetComponent<Rigidbody>(); */

						makeSticky ();
					} else if (gameObject.transform.parent == true && target.gameObject.transform.parent == null) {
						gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						target.gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						GameObject.FindWithTag ("leftCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						GameObject.FindWithTag ("rightCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						Destroy (target.gameObject.GetComponent<FixedJoint> ());

						target.transform.SetParent (emptyInScene.transform);
					} else if (target.gameObject.transform.parent == true && gameObject.transform.parent == null) {
						gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						target.gameObject.GetComponent<VRTK_InteractableObject> ().ForceStopInteracting ();
						GameObject.FindWithTag ("leftCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						GameObject.FindWithTag ("rightCont").GetComponent<VRTK_InteractGrab> ().ForceRelease ();
						gameObject.transform.SetParent (emptyInScene.transform);
					}
				}
			}

		}

	}
			

		
}



