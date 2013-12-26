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
				Transform target = entity.transform;
				Vector3 targetDir = target.position - transform.position;
				Vector3 heading = target.position - transform.position;
				float angle = Vector3.Angle(forward, targetDir);

				if (angleDir != null){
					dirNum = angleDir.getDir(transform.forward, heading, transform.up);}

				if (entity.GetComponent<Enemy>() && angle <= fireAngle){
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

					if (Physics.Raycast(playerPosition, targetDir, out hit) && hit.collider.transform.GetComponent<Enemy>()){
							int attackRoll = Random.Range(1,100);
							Debug.Log(attackRoll);

							if (attackRoll > entity.GetComponent<Enemy>().deflection){
								int damageRoll = Random.Range(1,100);
								entity.GetComponent<Enemy>().stamina -=  damageRoll-entity.GetComponent<Enemy>().damageReduction;

								if (damageRoll-entity.GetComponent<Enemy>().damageReduction > entity.GetComponent<Enemy>().ballisticThreshold){
									entity.GetComponent<Enemy>().condition -= 1;}
							}
							break;						
						}
					} 
				}								
			}
		}
}


