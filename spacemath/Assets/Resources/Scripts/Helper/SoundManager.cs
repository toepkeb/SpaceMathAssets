using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
	
	static bool playMusic;
	static bool playSFX;
	static bool playVO;
	static AudioClip[] sfx;
	
	void Awake()
	{
		DontDestroyOnLoad(this);	
	}
	
	// Use this for initialization
	void Start () {
		LoadSFX();
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void EnableSFX()
	{
		playSFX = true;
		
		if (playSFX == null)
			LoadSFX();
	}
	
	static void LoadSFX()
	{
		Object[] temp = Resources.LoadAll("Audio/SFX");
		sfx = new AudioClip[temp.Length];
		for (int i=0; i < temp.Length;i++)
		{
			sfx[i] = (AudioClip)temp[i];
		}
	}
	
	public void PlayOneShotSFX(string sfx)
	{
		if (playSFX)
			audio.PlayOneShot(GetSFX(sfx));
	}
	
	AudioClip GetSFX(string sfx)
	{
		for (int i=0; i < sfx.Length;i++)
		{
			if (SoundManager.sfx[i].name == sfx)
				return SoundManager.sfx[i];
		}
		return null;
	}
	
}
