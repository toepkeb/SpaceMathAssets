using UnityEngine;
using System.Collections;

public class RadioController : MonoBehaviour {
	
	public RadioButton[] radioButtons;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetupButtons()
	{
		for (int i=0; i < radioButtons.Length;i++)
		{
			if (i==0)
				radioButtons[i].Init(this,true);
			else
				radioButtons[i].Init (this,false);

		}
	}
	
	public void Clicked(RadioButton but)
	{
		for(int i=0; i < radioButtons.Length;i++)
		{
			if (but == radioButtons[i])
				radioButtons[i].SetState(true);
			else
				radioButtons[i].SetState(false);
		}
	}
}
