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

	public float RandomValue;

	public GameObject Player;
	// Use this for initialization
	void Start ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		PlayerAudio = audioSources[0];
		
		CollectableHit = audioSources[0].clip;
		Pickup1 = audioSources[1].clip;
		Pickup2 = audioSources[2].clip;
		
		
		ballBehavior ballBehavior = Player.GetComponent<ballBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("collectable"))
		{
			RandomValue = Random.value;

			if (RandomValue < 0.5)
			{
				PlayerAudio.PlayOneShot(Pickup1);
			}

			if (RandomValue > 0.5)
			{
				PlayerAudio.PlayOneShot((Pickup2));
			}
		}
	}
}
