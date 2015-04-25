using UnityEngine;
using System.Collections;

public class Directors : MonoBehaviour {

	GameObject[] allObjects;
	public GameObject global;
	Utils utils;

	// Use this for initialization
	void Start () {
		allObjects = FindObjectsOfType (typeof(GameObject)) as GameObject[];
		utils = global.GetComponent<Utils>();
	}

	void FixedUpdate() {
		foreach (GameObject obj in allObjects) {
			Properties props = utils.GetProperties (obj);
			FilterMovement(obj, props);
		}

	}

	void FilterMovement(GameObject obj, Properties props) {
		if (props.movable) {
			MoveTo (obj, props);
			RandomMove (obj, props);
		}
	}

	void MoveTo(GameObject obj, Properties props) {
		obj.transform.position = Vector3.MoveTowards(obj.transform.position, props.destination, props.speed * Time.deltaTime);
	}

	void RandomMove(GameObject obj, Properties props) {
		if (props.randomMove && props.destination == obj.transform.position) {
			props.destination = new Vector3 (Random.Range (-10, 10), 0, Random.Range (-10, 10));
		}	
	}

}
