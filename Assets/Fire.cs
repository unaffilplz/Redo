using UnityEngine;
using System.Collections;


public class Fire : MonoBehaviour {

	// Size of sphere that gets enemies around player
	public float radius;
	// Angle that the player can target enemies inside of
	public float fireAngle;
	// Cached transform of targets inside sphere
	public Transform target;
	// Direction of target, indicates if it's to the left or right of the player
	public float dirNum;
	// Cooldown for weapon, prevents spamming it and prevents multiple shots from one click
	public float cooldownTime;
	public float timer;

	public AudioSource pistolSound;


	// Used to get dirNum, the direction of the target
	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);		
		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}

	// Initialization
	void Start () {
		fireAngle = 30.0F;
		radius = 1000.0F;
		cooldownTime = 0.25F;
		timer = cooldownTime;

	}

	// Update is called once per frame
	void Update () {
		// Time since weapon last fired
		timer += Time.deltaTime;	

		Vector3 forward = transform.forward;
		Vector3 playerPosition = transform.position;


		// When fire button is pressed, get every entity with a collider in a sphere
		// around the player. For each entity, if it has the Enemy component,
		// check the angle between the player front facing and the enemy. If it's within
		// our defined firing cone 
		if(Input.GetButtonDown("Fire1") && timer > cooldownTime){
			Collider[] colliders = Physics.OverlapSphere(playerPosition, radius);
			pistolSound.Play();
			foreach (Collider entity in colliders) {
				target = entity.transform;

				Vector3 targetDir = target.position - transform.position;
				
				Vector3 heading = target.position - transform.position;
				dirNum = AngleDir(transform.forward, heading, transform.up);
				// Angle between player forward facing and target
				float angle = Vector3.Angle(forward, targetDir);
				Debug.Log (angle);
				if (entity.GetComponent<Enemy>()){
					if (angle <= fireAngle){
						Debug.Log(angle);
						Destroy(entity.gameObject);
						break;
					} 
				}								
			}
			timer = 0.0F;
		}


	}
}

