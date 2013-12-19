using UnityEngine;
using System.Collections;

public class playerMain : MonoBehaviour {
	
	// Attributes
	
	public int vitality;
	public int agility;
	public int wisdom;
	
	public int athletics;
	public int acrobatics;
	public int coordination;
	public int perception;
	public int charisma;	
	
	
	// Background
	
	public background Background;
	
	// Skills
	
	
	
	// Stats
	
	
	
	// Use this for initialization
	void Start () {
		Background.characterBackground("raider");
		athletics += Background.atheleticsMod;
		acrobatics += Background.acrobaticsMod;
		
	}
	
	void OnGUI () {
		if (GUI.Button(new Rect(10, 70, 30, 30), "+"))
			athletics += 1;
		if (GUI.Button(new Rect(50, 70, 30, 30), "-"))
			athletics -= 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}