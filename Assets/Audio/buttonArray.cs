using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class buttonArray : MonoBehaviour {
	public AudioSource audio;
	public AudioClip[] buttonSounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playRandomSound(){
		int random = Random.Range(0,buttonSounds.Length);
		audio.PlayOneShot(buttonSounds[random]);
	}
}
