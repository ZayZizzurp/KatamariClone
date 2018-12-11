using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: Place this script on the player object
//INTENT: Have the player make sounds when collecting objects, and when bumping into objects/hazards bigger than it
public class PlayerAudioManager : MonoBehaviour
{
	public AudioSource PlayerAudio;
	public AudioClip Pickup1;
	public AudioClip Pickup2;
	public AudioClip CollectableHit;

	public GameObject Player;
	// Use this for initialization
	void Start ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		PlayerAudio = audioSources[0];
		
		
		ballBehavior ballBehavior = Player.GetComponent<ballBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("collectable"))
		{
			
		}
	}
}
