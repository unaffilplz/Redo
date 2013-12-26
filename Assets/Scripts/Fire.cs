using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Fire : MonoBehaviour {
	/* Gets a target in an angle front of the player and applies damage to them on click */

	public float radius;
	public float fireAngle;
	// Direction of target, indicates if it's to the left or right of the player
	public float dirNum;
	public float cooldownTime;
	public float timer;
	public AudioSource weaponSound;

	AngleDir angleDir = null;

	void Awake () {
		radius = 1000.0F;
		fireAngle = 30.0F;
		cooldownTime = 0.25F;
		timer = cooldownTime;
	}
	
	void Start () {
		angleDir = transform.parent.GetComponent<AngleDir>();
	}
	
	void Update () {
		Vector3 forward = transform.forward;
		Vector3 playerPosition = transform.position;

		timer += Time.deltaTime;

		if(Input.GetButtonDown("Fire1") && timer > cooldownTime){
			timer = 0.0F;
			weaponSound.Play();	
			Collider[] colliders = Physics.OverlapSphere(playerPosition, radius);
			colliders = colliders.OrderBy(x => Vector3.Distance(x.transform.position, playerPosition)).ToArray();

			foreach (Collider entity in colliders) {
				Enemy enemy = entity.GetComponent<Enemy>();

				if (enemy){
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

					Vector3 targetDir = enemy.transform.position - playerPosition;
					Vector3 heading = enemy.transform.position - playerPosition;
					float angle = Vector3.Angle(forward, targetDir);

					if (angleDir != null){
						dirNum = angleDir.getDir(transform.forward, heading, transform.up);}

					if(angle <= fireAngle){
						if (Physics.Raycast(playerPosition, targetDir, out hit)){
								int attackRoll = Random.Range(1,100);
								Debug.Log(attackRoll);

								if (attackRoll > enemy.deflection){
									int damageRoll = Random.Range(1,100);
									enemy.stamina -=  damageRoll-enemy.damageReduction;

									if (damageRoll-enemy.damageReduction > enemy.ballisticThreshold){
										enemy.condition -= 1;}
								}
								break;
						}
					}
				}
			}
		}	
	}
}



