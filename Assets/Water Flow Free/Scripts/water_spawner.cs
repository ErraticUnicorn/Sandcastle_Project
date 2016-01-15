using UnityEngine;
using System.Collections;

public class water_spawner : MonoBehaviour {

	public Transform waterMolecule;
	public int instanceCount = 100;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < instanceCount; i++) {
			Instantiate (waterMolecule, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CreateInstances() {


	}
}
