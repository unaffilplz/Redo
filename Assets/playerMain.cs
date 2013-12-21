using UnityEngine;
using System.Collections;

public class playerMain : MonoBehaviour {

	// Flags

	// Holds whether character background modifiers has been applied to character
	public bool backgroundApplied = false;

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
	
	// Skill proficiencies	


	public int search;
	public int detection;
	public int stealth;
	public int lockpick;
	public int survival;
	
	public int electronics;
	public int repair;
	public int trade;


	// Stats	

	public string playerName;

	public int stamina;
	public int deflection;
	public int attackBonus;
	public int condition;

	public int ballisticThreshold;
	public int bludgeoningThreshold;
	public int piercingThreshold;
	public int slashingThreshold;


	//Apply background to character


	public void applyBackground()
	{								
		search = Background.searchMod;
		detection = Background.detectionMod;
		stealth = Background.stealthMod;
		lockpick = Background.lockpickMod;
		survival = Background.survivalMod;

		electronics = Background.electronicsMod;
		repair = Background.repairMod;

		//backgroundApplied = true;
		Debug.Log("Background applied");
		
	}

	// Use this for initialization
	void Start () {

	}
	
	void OnGUI () {
		if (GUI.Button(new Rect(10, 70, 30, 30), "+")){
			athletics += 1;}
		if (GUI.Button(new Rect(50, 70, 30, 30), "-")){
			athletics -= 1;}

		if (GUI.Button(new Rect(10, 10, 100, 30), "Thief"))
		{
			Background.characterBackground("thief");
			applyBackground();
		}

		if (GUI.Button(new Rect(10, 40, 100, 30), "Scavenger"))
		{
			Background.characterBackground("scavenger");
			applyBackground();
		}
			


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}