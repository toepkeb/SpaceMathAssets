using UnityEngine;
using System.Collections;

public class Results : MonoBehaviour {
	
	int total;
	int correct;
	int incorrect;
	int skipped;
	bool display;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (display)
		{
			if (!audio.isPlaying)
			{
				if (HelperFunctions.FadeAudio(.75f,-1) ==0)
				{
					Camera.main.audio.Stop ();
					audio.Play ();
				}
			}
			else
			{
				HelperFunctions.FadeAudio(2,1);
			}
		}
	}
	
	void OnGUI()
	{
		if (display)
		{
			GUI.Box(new Rect(Screen.width *.5f - 100, Screen.height *.5f -120, 200,240),"");
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(Screen.width *.5f - 100, Screen.height *.5f -110, 200,24),"Results");
			
			GUI.skin.label.alignment = TextAnchor.MiddleLeft;
			GUI.Label (new Rect(Screen.width *.5f - 60, Screen.height *.5f -60, 120,24), "Correct:  " + correct.ToString() + "/" + total.ToString());
			GUI.Label (new Rect(Screen.width *.5f - 60, Screen.height *.5f -30, 120,24), "Inorrect:  " + incorrect.ToString() + "/" + total.ToString());
			GUI.Label (new Rect(Screen.width *.5f - 60, Screen.height *.5f , 120,24), "Skipped:  " + skipped.ToString() + "/" + total.ToString());
			
			if (GUI.Button (new Rect(Screen.width *.5f - 50, Screen.height *.5f + 50, 100,24), "Main Menu"))
			{
				CallLevelLoad.SetLevelLoad(0,1);
			}
		}
	}
	
	public void SetResults(int correct, int incorrect, int skipped)
	{
		StarFoxPlayer.canControl = false;
		total = correct + incorrect + skipped;
		this.correct = correct;
		this.incorrect = incorrect;
		this.skipped = skipped;
		display = true;
		
	}
	
}
