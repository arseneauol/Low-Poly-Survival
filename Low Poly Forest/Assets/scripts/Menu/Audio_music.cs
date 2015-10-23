using UnityEngine;
using System.Collections;

public class Audio_music : MonoBehaviour {
	public GameObject audiosound;
	public AudioClip music;

	void Start(){

		DontDestroyOnLoad (audiosound);
		GetComponent<AudioSource>().PlayOneShot (music);
	}
}