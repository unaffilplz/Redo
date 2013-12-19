using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {	
	
	// Modifiers	
	
	public int vitalityMod;	
	public int agilityMod;	
	public int wisdomMod;	
	
	public int atheleticsMod;	
	public int acrobaticsMod;	
	public int coordinationMod;	
	public int perceptionMod;	
	public int charismaMod;

	
	public void characterBackground(string backgroundName)		
	{		
		switch(backgroundName)			
		{			
		case "raider":			
			vitalityMod = 1;			
			agilityMod = 1;			
			wisdomMod = 1;			
			break;
			
		case "assassin":			
			atheleticsMod = 1;			
			acrobaticsMod = 2;			
			break;			
			
		default:			
			this.name = "Citizen";			
			break;			
		}		
	}	
}