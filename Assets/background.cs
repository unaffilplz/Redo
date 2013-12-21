using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {	
	
	// Skill Proficincies

	public int searchMod;
	public int detectionMod;
	public int stealthMod;
	public int lockpickMod;
	public int survivalMod;
	public int electronicsMod;
	public int repairMod;
	public int tradeMod;

	// Stunts

	// Sneak attack

	// Double tap
	// Spray room
	// Suppressing fire
	// Snipe
	// Shot on the run

	

	public void characterBackground(string backgroundName)		
	{		
		switch(backgroundName)			
		{			
		case "thief":
			searchMod = 1;
			detectionMod = 1;
			stealthMod = 1;
			lockpickMod = 1;
			survivalMod = 0;
			electronicsMod = 1;
			repairMod = 0;
			tradeMod = 0;
			break;
			
		case "scavenger":
			searchMod = 1;
			detectionMod = 0;
			stealthMod = 0;
			lockpickMod = 1;
			survivalMod = 1;
			electronicsMod = 1;
			repairMod = 1;
			tradeMod = 1;
			break;			
			
		default:			
			this.name = "Citizen";			
			break;			
		}		
	}	
}