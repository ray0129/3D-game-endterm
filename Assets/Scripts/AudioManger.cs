using System.Collections;
using System; //FIND
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManger : MonoBehaviour {

	public Sound[] sounds;

	void Awake(){
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
		

	void Start(){
		Play ("BackGround");
	}

	public void Play(string name){
		Debug.Log ("Sound From" + name);
		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Play ();
	}
}
