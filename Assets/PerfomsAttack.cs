using UnityEngine;
using System.Collections;

public class PerfomsAttack : MonoBehaviour {

	public float range = 100.0f;

	public float cooldown = 0.2f;
	float cooldownRemaining = 0;

	public float damage = 40f;

	public GameObject debrisPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;

		if( Input.GetMouseButton(0) && cooldownRemaining <= 0 ) {
			cooldownRemaining = cooldown;
			Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
			RaycastHit hitInfo;

			if( Physics.Raycast(ray, out hitInfo, range) ) {
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				Debug.Log ("Hit Object: " + go.name);
				Debug.Log ("Hit Point: " + hitPoint);

				HasHealth h = go.GetComponent<HasHealth>();

				if(h != null) {
					h.RecieveDamage(damage);
				}

				if(debrisPrefab != null) {
					Instantiate( debrisPrefab, hitPoint, Quaternion.identity );
				}
			}
		}
	}
}
