using UnityEngine;
using System.Collections;

public class EquationCache {
	
	static EquationCache sharedCache;
	public Equation[] equationCache;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static EquationCache SharedCache
	{
		get
		{
			if (sharedCache == null)
				sharedCache = new EquationCache();
			
			return sharedCache;
		}
	}
	
	public void SetEquations(int count)
	{
		equationCache = new Equation[count];
		
		//Lesson currentLesson = GetLesson(ProfileManager.currentProfile.Grade,ProfileManager.currentProfile.Planet);
		
		
//		for (int i=0; i < count;i++)
//		{
//			Lesson currentLesson = GetLesson(level, i);
//			equationCache[i] = new Equation(currentLesson, GetNumOfAnswers(level));
//		}
	}
	
	public Equation ChangeSingleEquation(int index, Lesson lesson, int level)
	{
		int prev = -1;
		if (index >0)
		{
			prev = equationCache[index-1].answer;
		}
		
		equationCache[index] = new Equation(lesson,prev);
		return equationCache[index];
	}
	
	public Equation ChangeSingleEquation(int index, int level)
	{
		int prev = -1;
		if (index > 0)
			prev = equationCache[index-1].answer;
		
		equationCache[index] = new Equation(GetLesson(level,0), prev);
		return equationCache[index];
	}
	
	Lesson GetLesson(int level, int question)
	{
		if (level ==1 && question <5)
			return new Lesson(0,5,0,2,false,2,3);
		else if (level == 1 && question >=5)
			return new Lesson(0,10,0,2,false,2,3);
		
		return null;
	}
	
	public Equation GetEquation(int index)
	{
		if (index >= equationCache.Length)
			return null;
		
		return equationCache[index];
	}
	
	int GetNumOfAnswers(int level)
	{
//		int planet = ProfileManager.currentProfile.Planet;
		
		if (level ==1)
		{
			return Random.Range(2,3);
		}
		if (level ==2)
		{
			return Random.Range(2,3);
		}
		if (level ==3)
		{
			return Random.Range(2,4);
		}
		if (level ==4)
		{
			return Random.Range(3,4);
		}
		if (level ==5)
		{
			return Random.Range(3,5);
		}
		if (level ==6)
		{
			return Random.Range(3,5);
		}
		if (level ==7)
		{
			return Random.Range(3,6);
		}
		if (level ==8)
		{
			return Random.Range(3,6);
		}
		if (level ==9)
		{
			return Random.Range(4,6);
		}
		return 0;
	}
}

public class Lesson
{
	public int type; //Equation type, See Equation in Equation Generator to see the corresponding enum
	public int min; //Min value of the answer
	public int max; //Max value of the answer
	public int count; //Amount values in the equation 1+2 would be 2
	public bool shapes; //Used to say if the equation is displayed as numbers or shapes
	public int numOfAnswers; //Number of answers, this includes the correct one (incorrect answers +1)
	
	public enum Restriction
	{
		None, Doubles, Single10, Double10, Five, NoCarry, Change10, NoRegroup
	}
	public Restriction restriction;
	
	public enum Pattern
	{
		Null, AB, AAB, ABC
	}
	public Pattern pattern;
	
	public enum PatternStyle 
	{
		Color, Shape, Number
	}
	public PatternStyle style;
	
	public Lesson(int min, int max, int type, int count, bool shapes, int minAnswers, int maxAnswers)
	{
		this.min = min;
		this.max = max;
		this.type = type;
		this.count = count;
		this.shapes = shapes;
		numOfAnswers = Random.Range(minAnswers,maxAnswers+1);
	}
	
	public Lesson(int min, int max, int type, int count, bool shapes, int minAnswers, int maxAnswers, Pattern pattern, PatternStyle style)
	{
		this.min = min;
		this.max = max;
		this.type = type;
		this.count = count;
		this.shapes = shapes;
		numOfAnswers = Random.Range(minAnswers,maxAnswers+1);
		this.pattern = pattern;
		this.style = style;
	}
	
	
	//Addition/Subtraction Restrictions
	//Doubles
	//Single Multiple of 10
	//Double Multiple of 10
	//One is 5
	//Does not change 10s
	//Add 2 or 3 but changes 10s digit
	//Double digit, no regrouping
	
	
}



