using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

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
	
	public Background background;
	
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
		search = background.searchMod;
		detection = background.detectionMod;
		stealth = background.stealthMod;
		lockpick = background.lockpickMod;
		survival = background.survivalMod;

		electronics = background.electronicsMod;
		repair = background.repairMod;

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
			background.characterBackground("thief");
			applyBackground();
		}

		if (GUI.Button(new Rect(10, 40, 100, 30), "Scavenger"))
		{
			background.characterBackground("scavenger");
			applyBackground();
		}
			


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}