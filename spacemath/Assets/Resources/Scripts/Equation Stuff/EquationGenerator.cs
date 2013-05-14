using UnityEngine;
using System.Collections;

public class EquationGenerator : MonoBehaviour {
	
	string answerField = "";
	bool displayEquation;
	Equation currentEquation;
	public int planetLevel;
	public int currentEquationIndex;
	public GameObject[] clusters;
	
	//Test Textures
	public Texture2D star;
	public Texture2D array5;
	public Texture2D array10;
	public Texture2D starSquare;
	public Texture2D[] stars;
	public Texture2D[] dominos;
	
	// Use this for initialization
	void Start () {
		//CreateEquation(min, max, Random.Range(2,6),count, false);
		
		//EquationCache.SharedCache.SetEquations(10);
//		currentEquationIndex = 0;
//		currentEquation = EquationCache.SharedCache.GetEquation(currentEquationIndex);
//		clusters = new GameObject[EquationCache.SharedCache.equationCache.Length];
//		for ( int i=0; i < clusters.Length;i++)
//		{
//			clusters[i] = CreateCluster(i, EquationCache.SharedCache.GetEquation(i));
//		}
		
		Reset ();
		
		displayEquation = true;
	}
	
	void Reset()
	{
		currentEquationIndex = 0;
		
		int count = GameObject.Find ("SpawnPoints").transform.childCount;
		EquationCache.SharedCache.SetEquations(count);
		
		for ( int i=0; i < count;i++)
		{
			CreateCluster(i);
		}
		
		currentEquation = EquationCache.SharedCache.GetEquation(currentEquationIndex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if (displayEquation)
		{
			DisplayEquation();
			
//			answerField = GUI.TextField(new Rect(Screen.width*.5f-50,Screen.height *.85f,100,30),answerField);
			
//			if (GUI.Button(new Rect(Screen.width*.5f-50,Screen.height*.9f,100,30),"Guess"))
//			{
//				CheckEquationAnswer(System.Int32.Parse(answerField));
//			}
//			
//			if (GUI.Button(new Rect(Screen.width*.5f-50,Screen.height*.2f,100,50),"Next"))
//			{
//				NextEquation();
//			}
//			
//			if (GUI.Button(new Rect(Screen.width*.5f-50,Screen.height*.1f,100,50),"Results"))
//			{
//				CalculateResults();
//			}
			
//			if (GUI.Button(new Rect(Screen.width *.2f-50,Screen.height*.8f,100,30),"Number Value"))
//			{
//				CreateEquation(0,10,0,1);
//			}
//			if (GUI.Button(new Rect(Screen.width *.3f-50,Screen.height*.8f,100,30),"Pattern"))
//			{
//				CreateEquation(8,100,1,6, false);
//			}
//			if (GUI.Button(new Rect(Screen.width *.4f-50,Screen.height*.8f,100,30),"X Array"))
//			{
//				CreateEquation(0,9,2,2);
//			}
//			if (GUI.Button(new Rect(Screen.width *.5f-50,Screen.height*.8f,100,30),"Addition"))
//			{
//				CreateEquation(min,max,3,count);
//			}
//			if (GUI.Button(new Rect(Screen.width *.6f-50,Screen.height*.8f,100,30),"Subtraction"))
//			{
//				CreateEquation(min,max,4,count);
//			}
//			if (GUI.Button(new Rect(Screen.width *.7f-50,Screen.height*.8f,100,30),"Multiplication"))
//			{
//				CreateEquation(min,max,5,count);
//			}
//			if (GUI.Button(new Rect(Screen.width *.8f-50,Screen.height*.8f,100,30),"Division"))
//			{
//				CreateEquation(min,max,6,count);
//			}
			
//			GUI.Label (new Rect(Screen.width*.4f-50,Screen.height*.9f,100,30),"Min : " +min.ToString());
//			if (GUI.Button(new Rect(Screen.width*.4f-50,Screen.height*.95f,50,30),"-"))
//			{
//				min --;
//			}
//			if (GUI.Button(new Rect(Screen.width*.4f,Screen.height*.95f,50,30),"+"))
//			{
//				min ++;
//			}
//			
//			GUI.Label (new Rect(Screen.width*.5f-50,Screen.height*.9f,100,30),"Max : " +max.ToString());
//			if (GUI.Button(new Rect(Screen.width*.5f-50,Screen.height*.95f,50,30),"-"))
//			{
//				max --;
//			}
//			if (GUI.Button(new Rect(Screen.width*.5f,Screen.height*.95f,50,30),"+"))
//			{
//				max ++;
//			}
//			
//			GUI.Label (new Rect(Screen.width*.6f-50,Screen.height*.9f,100,30),"Count : " +count.ToString());
//			if (GUI.Button(new Rect(Screen.width*.6f-50,Screen.height*.95f,50,30),"-"))
//			{
//				count --;
//			}
//			if (GUI.Button(new Rect(Screen.width*.6f,Screen.height*.95f,50,30),"+"))
//			{
//				count ++;
//			}
		}
	}
	
	
	void CreateEquation(int min, int max, int type, int count, int numOfAnswers)
	{
		CreateEquation(min,max,type,count,false,numOfAnswers);
	}
	
	void CreateEquation(int min, int max, int type, int count, bool shapes, int numOfAnsers)
	{
		//currentEquation = new Equation(min, max, type, count, shapes, numOfAnsers);
		displayEquation = true;
	}
	
	void DisplayEquation()
	{
		Rect equationRect = new Rect(Screen.width*.5f - 150, Screen.height*.75f,300,50);
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		
		string eq = "";
		
		if (currentEquation.type == 0)
		{
			if (currentEquationIndex <5)
			{
				GUI.Box(equationRect,"                                         = ?");
				Rect arrayRect = new Rect(equationRect.x+10,equationRect.y+5,200,40);
				GUI.DrawTexture(arrayRect,array5);
				for (int i=0; i < currentEquation.answer;i++)
				{
					float x = 10 + equationRect.x + 40*(i%5);
					float y = equationRect.y+5;
					GUI.DrawTexture(new Rect(x,y,40,40),star);
				}
			}
			else
			{
				GUI.Box(equationRect,"                         = ?");
				Rect arrayRect = new Rect(equationRect.x+30,equationRect.y+5,100,40);
				GUI.DrawTexture(arrayRect,array10);
				for (int i=0; i < currentEquation.answer;i++)
				{
					float x = 30 + equationRect.x + 20*(i%5);
					float y = equationRect.y+5;
					if (i >=5)
						y += 20;
					GUI.DrawTexture(new Rect(x,y,20,20),star);
				}
			}
		}
		else if (currentEquation.type == 1)
		{
		}
		else if (currentEquation.type ==2)
		{
		}
		else if (currentEquation.type == 3)
		{
			GUI.DrawTexture(new Rect(Screen.width*.5f-50,Screen.height*.7f,100,100),dominos[7]);
			if (currentEquation.answer != 0)
				GUI.DrawTexture(new Rect(Screen.width*.5f-50,Screen.height*.7f,100,100),dominos[currentEquation.answer]);
		}
		else if (currentEquation.type == 4)
		{
			//eq = currentEquation.values[0].ToString() + "  " + currentEquation.values[1].ToString() + " = ";
			GUI.DrawTexture(new Rect(Screen.width*.5f-100,Screen.height*.7f,200,100),dominos[0]);
			if (currentEquation.values[0] != 0)
				GUI.DrawTexture(new Rect(Screen.width*.5f-100,Screen.height*.7f,100,100),dominos[currentEquation.values[0]]);
			if (currentEquation.values[1] != 0)
				GUI.DrawTexture(new Rect(Screen.width*.5f,Screen.height*.7f,100,100),dominos[currentEquation.values[1]]);
			
			//GUI.Box (equationRect,eq);
		}
		else if (currentEquation.type == 5 && currentEquation.shapes)
		{
			int width = 30*currentEquation.values.Length;
			Rect arrayRect = new Rect(Screen.width*.45f-width*.5f,Screen.height*.5f,width,50);
			equationRect = new Rect(Screen.width *.5f-200,Screen.height*.5f,400,50);
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(equationRect,"                         = ?");
			
			GUI.BeginGroup(arrayRect);
			
			for (int i=0; i < currentEquation.values.Length;i++)
			{
				GUI.DrawTexture(new Rect(i*30,10,30,30),stars[currentEquation.values[i]]);
			}
			
			GUI.EndGroup();
		}
		else if ( (currentEquation.type ==5 && !currentEquation.shapes) || currentEquation.type ==6)
		{
			
			for (int i=0; i < currentEquation.values.Length;i++)
			{
				eq += currentEquation.values[i].ToString();
				
				if (i < currentEquation.values.Length-1)
					eq += currentEquation.GetOperation();
				else
					eq += "...?";
			}
			
			GUI.Box (equationRect,eq);
			
		}
		else if (currentEquation.type >=7 || (currentEquation.type ==5 && !currentEquation.shapes))
		{
			
			for (int i=0; i < currentEquation.values.Length;i++)
			{
				eq += currentEquation.values[i].ToString();
				
				if (i < currentEquation.values.Length-1)
					eq += currentEquation.GetOperation();
				else
					eq += " = ?";
			}
			
			GUI.Box (equationRect,eq);
		}
	}
	
	public bool CheckEquationAnswer(int index, int guess)
	{
		if (index != currentEquationIndex)
			return false;
		
		if (guess == currentEquation.answer)
		{
			//Skill skill = SkillDataBase.GetSkill(currentEquation.type,currentEquation.answer);
			//skill.AddProgress(ProfileManager.currentProfileIndex, .1f);
			currentEquation.status = Equation.Status.Correct;
			NextEquation(index);
			return true;
		}
		else
		{
			currentEquation.status = Equation.Status.Incorrect;
			NextEquation (index);
			return false;
		}
	}
	
	GameObject CreateCluster(int index )
	{
		Transform spawn = GameObject.Find ("SpawnPoints").transform.FindChild(index.ToString());
		Equation eq = EquationCache.SharedCache.ChangeSingleEquation(index,spawn.gameObject.GetComponent<SpawnPoint>().lesson, planetLevel);
		
		GameObject currentCluster = (GameObject)GameObject.Instantiate((GameObject)Resources.Load ("Prefabs/Cluster"));
		currentCluster.GetComponent<Cluster>().SetValues(eq.answer,eq.incorrectAnswers, index);
		currentCluster.transform.position = spawn.position;
		currentCluster.transform.rotation = spawn.rotation;
		
		return currentCluster;
	}
	
	public void NextEquation(int index)
	{
		if (index != currentEquationIndex)
			return;
		
		if (currentEquation.status == Equation.Status.Null)
			currentEquation.status = Equation.Status.Skipped;
			
		
		currentEquationIndex++;
		currentEquation = EquationCache.SharedCache.GetEquation(currentEquationIndex);
		
		
		if (currentEquation == null)
		{
			displayEquation = false;
			CalculateResults();
			return;
		}
		
		//CreateCluster();
	}
	
	void CalculateResults()
	{
		int count = 0;
		int correct=0;
		int incorrect=0;
		int skipped=0;
		
		for (int i=0; i < EquationCache.SharedCache.equationCache.Length;i++)
		{
			if (EquationCache.SharedCache.equationCache[i].status == Equation.Status.Correct)
			{
				count++;
				correct++;
			}
			if (EquationCache.SharedCache.equationCache[i].status == Equation.Status.Incorrect)
			{
				count++;
				incorrect++;
			}
			if (EquationCache.SharedCache.equationCache[i].status == Equation.Status.Skipped)
			{
				count++;
				skipped++;
			}
		}
		
		Debug.Log ("Correct: " + correct + " / " +count);
		Debug.Log ("Incorrect: " + incorrect + " / " +count);
		Debug.Log ("Skipped: " + skipped + " / " +count);
	}
}

public class Equation
{
	public int type;
	public int[] values;
	public int answer;
	public bool shapes;
	public int[] incorrectAnswers;
	
	public enum Operation
	{
		NumberValue, PieChart, Geometry, Dice, Dominos, Pattern, CountOn, Addition, Subtraction, Multiplication, Division
	}
	Operation operation;
	
	public enum Status
	{
		Null,Correct,Incorrect,Skipped
	}
	public Status status;
	
	public string GetOperation()
	{
		switch (operation)
		{
		case Operation.Pattern:
			return ", ";
		case Operation.CountOn:
			return ", ";
		case Operation.Addition:
			return " + ";
		case Operation.Subtraction:
			return " - ";
		case Operation.Multiplication:
			return " x ";
		case Operation.Division:
			return " / ";
		}
		
		return "";
	}
	
	//Constructors
	/*
	public Equation(int min, int max, int type, int valCount, bool shapes, int numOfAnswers)
	{
		this.type = type;
		values = new int[valCount];
		answer = Random.Range(min,max);
		operation = (Operation)type;
		this.shapes = shapes;
		incorrectAnswers = new int[numOfAnswers-1];
		
		switch (operation)
		{
		case Operation.Pattern:
			CreatePatternProblem(min, max, shapes);
			break;
		case Operation.MultiplicationArray:
			CreateMultiplicationArrayProblem(null, max);
			break;
		case Operation.Addition:
			CreateAdditionProblem(null);
			break;
		case Operation.Subtraction:
			CreateSubtractionProblem(null, max);
			break;
		case Operation.Multiplication:
			CreateMultiplicationProblem(null, max);
			break;
		case Operation.Division:
			CreateDivisionProbelm(null, max);
			break;
		}
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(min,max);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			}
			Debug.Log (incorrectAnswers[i]);
		}
	}*/
	
	public Equation(Lesson lesson, int prevAnswer)
	{
		
		this.type = lesson.type;
		values = new int[lesson.count];
		answer = Random.Range(lesson.min,lesson.max);

		while (answer == prevAnswer)
		{
			answer = Random.Range(lesson.min,lesson.max);
		}
		
		operation = (Operation)lesson.type;
		this.shapes = lesson.shapes;
		incorrectAnswers = new int[lesson.numOfAnswers-1];
		
		switch (operation)
		{
		case Operation.NumberValue:
			for (int i=0; i < incorrectAnswers.Length;i++)
			{
				bool unique = false;
				
				while (!unique)
				{
					unique = true;
					incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
					
					if (incorrectAnswers[i] == answer)
						unique = false;
					for (int j=0; j <i;j++)
					{
						if (incorrectAnswers[i] == incorrectAnswers[j])
							unique = false;
					}
					
					if ((answer == 6 || answer == 9) && (incorrectAnswers[i] == 6 || incorrectAnswers[i] == 9))
						unique = false;
					if ((answer == 2 || answer == 5) && (incorrectAnswers[i] == 2 || incorrectAnswers[i] == 5))
						unique = false;
				}
			}
			break;
		case Operation.PieChart:
			CreatePieChartProblem(lesson);
			break;
		case Operation.Geometry:
			CreateGeometryProblem(lesson);
			break;
		case Operation.Dice:
			for (int i=0; i < incorrectAnswers.Length;i++)
			{
				bool unique = false;
				
				while (!unique)
				{
					unique = true;
					incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
					
					if (incorrectAnswers[i] == answer)
						unique = false;
					for (int j=0; j <i;j++)
					{
						if (incorrectAnswers[i] == incorrectAnswers[j])
							unique = false;
					}
				}
			}
			break;
		case Operation.Dominos:
			CreateDominoProblem(lesson);
			break;
		case Operation.Pattern:
			CreatePatternProblem(lesson);
			break;
		case Operation.CountOn:
			CreateCountOnProblem(lesson);
			break;
		case Operation.Addition:
			CreateAdditionProblem(lesson);
			break;
		case Operation.Subtraction:
			CreateSubtractionProblem(lesson);
			break;
		case Operation.Multiplication:
			CreateMultiplicationProblem(lesson);
			break;
		case Operation.Division:
			CreateDivisionProbelm(lesson);
			break;
		}
		
		//DebugValues();
	}
	
	void CreatePieChartProblem(Lesson lesson)
	{
	}
	
	void CreateGeometryProblem(Lesson lesson)
	{
	}
	
	void CreateDominoProblem(Lesson lesson)
	{
		int temp = answer;
		for (int i=0; i < values.Length-1;i++)
		{
			if (answer ==0)
				values[i] = Random.Range(0,Mathf.Clamp(temp,0,6));
			else
				values[i] = Random.Range(Mathf.Clamp(answer-6,0,6),Mathf.Clamp(temp,0,6));
			temp -= values[i];
		}
		
		values[values.Length-1] = temp;
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			}
		}
	}
	
	void CreatePatternProblem(Lesson lesson)
	{
		if (lesson.pattern == Lesson.Pattern.AB)
		{
			values[0] = Random.Range(lesson.min, lesson.max);
			values[1] = Random.Range(lesson.min, lesson.max);
			
			while(values[0] == values[1])
				values[1] = Random.Range(lesson.min, lesson.max);
			
			for (int i=2; i< lesson.count;i++)
			{
				values[i] = values[i%2];
			}
			
			answer = values[lesson.count%2];
			Debug.Log (answer);
		}
		else if (lesson.pattern == Lesson.Pattern.AAB)
		{
			values[0] = Random.Range(lesson.min, lesson.max);
			values[1] = values[0];
			values[2] = Random.Range(lesson.min, lesson.max);
			
			while(values[0] == values[2])
				values[2] = Random.Range(lesson.min, lesson.max);
			
			for (int i=3; i< lesson.count;i++)
			{
				
				values[i] = values[i%3];
			}
			
			answer = values[lesson.count%3];
		}
		else if (lesson.pattern == Lesson.Pattern.ABC)
		{
			values[0] = Random.Range(lesson.min, lesson.max);
			values[1] = Random.Range(lesson.min, lesson.max);
			
			while(values[0] == values[1])
				values[1] = Random.Range(lesson.min, lesson.max);
			
			values[2] = Random.Range(lesson.min, lesson.max);
			
			while(values[2] == values[0] || values[2] == values[1])
				values[2] = Random.Range(lesson.min, lesson.max);
			
			for (int i=3; i< lesson.count;i++)
			{
				values[i] = values[i%3];
			}
			
			answer = values[lesson.count%3];
		}
		
		/* old pattern
		if (shapes)
		{
			int pat = Random.Range (0,3);
			//AB Pattern
			if (pat == 0)
			{
				int a = Random.Range (0,4);
				int b = a;
				while (a == b)
				{
					b = Random.Range (0,4);
				}
				for (int i=0; i < values.Length;i+=2)
				{
					values[i] = a;
				}
				for (int i=1; i < values.Length;i+=2)
				{
					values[i] = b;
				}
				if (values[values.Length-1] == a)
					answer = b;
				else
					answer = a;
			}
			//ABA Pattern
			else if (pat ==1)
			{
				
				int a = Random.Range (0,4);
				int b = a;
				while (a == b)
				{
					b = Random.Range (0,4);
				}
				for (int i=0; i < values.Length;i+=3)
				{
					values[i] = a;
				}
				for (int i=1; i < values.Length;i+=3)
				{
					values[i] = b;
				}
				for (int i=2; i < values.Length;i+=3)
				{
					values[i] = a;
				}
				
				if (values[values.Length-1] == a && values[values.Length-2] ==a)
					answer= b;
				else
					answer = a;
			}
			else if (pat == 2)
			{
				int a = Random.Range (0,4);
				int b = a;
				int c = a;
				while (a ==b)
				{
					b = Random.Range (0,4);
				}
				while (c == a || c == b)
				{
					c = Random.Range(0,4);
				}
				
				for (int i=0; i < values.Length;i+=3)
				{
					values[i] = a;
				}
				for (int i=1; i < values.Length;i+=3)
				{
					values[i] = b;
				}
				for (int i=2; i < values.Length;i+=3)
				{
					values[i] = c;
				}
				
				if (values[values.Length-1] == a)
					answer = b;
				else if (values[values.Length-1] == b)
					answer = c;
				else
					answer = a;
			}
		}
		else
		{
			int temp = Random.Range(0,4);
			int pat = 0;
			if (temp ==0)
				pat =2;
			else if (temp ==1)
				pat = 3;
			else if (temp ==2)
				pat = 5;
			else if (temp ==3)
				pat = 10;
			
			answer = Random.Range (lesson.min + pat*values.Length,lesson.max);
			for (int i=0; i < values.Length;i++)
			{
				values[i] = answer -pat*(values.Length-i);
			}
		}
		*/
	}
	
	void CreateCountOnProblem(Lesson lesson)
	{
		values[lesson.count-1] = answer-1;
		
		for (int i=lesson.count-2; i >=0 ;i--)
		{Debug.Log (i);
			values[i] = values[i+1]-1;
		}
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(1,answer+5);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			}
		}
	}
	
	// Doubles, Single10, Double10, Five, NoCarry, Change10, NoRegroup
	//Addition/Subtraction Restrictions
	//Doubles = 2 same didgit
	//Single10 = 1 digit is a Multiple of 10
	//Double10 = both digits are a Multiple of 10
	//Five = one digit is 5
	//NoCarry = Does not change 10s
	//Change10 = Add 2 or 3 but changes 10s digit
	//NoRegroup = Double digit, no regrouping
	void CreateAdditionProblem(Lesson lesson)
	{
		Lesson.Restriction res = lesson.restriction;

		
		switch(res)
		{
			#region None
			case Lesson.Restriction.None:
			{
				int temp = answer;
				for (int i=0; i < values.Length-1;i++)
				{
					if (answer ==0)
						values[i] = Random.Range(0,temp);
					else
						values[i] = Random.Range(1,temp);
					temp -= values[i];
				}
				
				values[values.Length-1] = temp;
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
					}
				}
				break;
			}
			#endregion
			#region Doubles
			case Lesson.Restriction.Doubles:
			{
				//Make answer an even number
				if (answer%2 ==1)
				{
					if (answer == lesson.max)
						answer--;
					else
						answer++;
				}
				
				values[0] = answer/2;
				values[1] = values[0];
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
					
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
						
						if (incorrectAnswers[i] == values[0])
							unique = false;
					}
				}
				break;
			}
			#endregion
			#region Single10
			case Lesson.Restriction.Single10:
			{
				int temp = answer;
				temp /= 10;
				temp = Random.Range(1,temp);
				temp*=10;
				Debug.Log ("Single10 temp = " + temp);
				
				values[0] = answer-temp;
				values[1] = temp;
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
					
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
						
					}
				}
				break;
			}
			#endregion
			#region Double10
			case Lesson.Restriction.Double10:
			{
				//Make the answer a power of 10
				answer /= 10;
				answer *= 10;
			
				
				values[0] = Random.Range(0,answer/10+1)*10;
				values[1] = answer - values[0];
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
					
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
						
					}
				}
				break;
			}
			#endregion
			#region Five
			case Lesson.Restriction.Five:
			{
				//Make the answer 
				answer /= 5;
				answer *= 5;
			
				
				values[0] = answer-5;
				values[1] = 5;
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
					
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
						
						if (incorrectAnswers[i] == 5)
							unique = false;
					}
				}
				break;
			}
			#endregion
			#region NoCarry
			case Lesson.Restriction.NoCarry:
			{
				//Make the answer a power of 5
				answer /= 5;
				answer *= 5;
			
				
				values[0] = answer-5;
				values[1] = 5;
				
				for (int i=0; i < incorrectAnswers.Length;i++)
				{
					bool unique = false;
					
					while (!unique)
					{
						unique = true;
						incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
						
						if (incorrectAnswers[i] == answer)
							unique = false;
					
						for (int j=0; j <i;j++)
						{
							if (incorrectAnswers[i] == incorrectAnswers[j])
								unique = false;
						}
						
						if (incorrectAnswers[i] == 5)
							unique = false;
					}
				}
				break;
			}
			#endregion
		}
		
	}
	
	void CreateSubtractionProblem(Lesson lesson)
	{
		int temp = lesson.max - answer;
		temp = Random.Range(1,temp);
		Debug.Log (temp);
		values[0] = answer + temp;
		
		for (int i=1; i < values.Length-1;i++)
		{
			values[i] = Random.Range(0,temp);
			temp -= values[i];
			
		}
		
		values[values.Length-1] = temp;
		
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(lesson.min,lesson.max);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			}
		}
	}
	
	void CreateMultiplicationProblem(Lesson lesson)
	{
		values = new int[2];
		values[0] =  Random.Range(0,lesson.max);
		values[1] = Random.Range(0,lesson.max);
		answer = values[0] * values[1];
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(lesson.min*lesson.min,lesson.max*lesson.max);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			
			}
		}
	}
	
	void CreateDivisionProbelm(Lesson lesson)
	{
		values = new int[2];
		int temp1 = Random.Range(0,lesson.max);
		int temp2 = Random.Range (1,lesson.max);
		int temp3 = temp1*temp2;
		
		values[0] = temp3;
		values[1] = temp2;
		answer = temp1;
		
		
		for (int i=0; i < incorrectAnswers.Length;i++)
		{
			bool unique = false;
			
			while (!unique)
			{
				unique = true;
				incorrectAnswers[i] = Random.Range(lesson.min*lesson.min,lesson.max*lesson.max);
				
				if (incorrectAnswers[i] == answer)
					unique = false;
				for (int j=0; j <i;j++)
				{
					if (incorrectAnswers[i] == incorrectAnswers[j])
						unique = false;
				}
			}
		}
	}
	
	public void DebugValues()
	{
		Debug.Log ("****************************************");
		Debug.Log ("Type: " + type + " (" + operation + ")");
		Debug.Log ("Is Shapes? " +shapes);
		Debug.Log ("Answer: " + answer);
		Debug.Log ("Values--------------------");
		for (int i=0; i < values.Length;i++)
		{
			Debug.Log ("	" + i + " = " + values[i]);
		}
		Debug.Log ("Incorrect Answers---------");
		for (int i=0; i< incorrectAnswers.Length;i++)
		{
			Debug.Log ("	" + i + " = " + incorrectAnswers[i]);
		}
	}
}
