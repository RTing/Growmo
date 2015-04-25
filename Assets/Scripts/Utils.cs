using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	public Properties GetProperties(GameObject obj) {
		Properties properties = obj.GetComponent<Properties>();
		return properties;
	}
}
