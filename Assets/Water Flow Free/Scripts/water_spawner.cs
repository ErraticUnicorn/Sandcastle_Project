using UnityEngine;
using System.Collections;

public class water_spawner : MonoBehaviour {

	public Transform waterMolecule;
	public int instanceCount = 100;
	public int updateCount = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		updateCount++;

		if(updateCount %1 ==0){
		//for (int i = 0; i < 2; i++) {
 		   Instantiate (waterMolecule, new Vector3(350+Random.Range (-4, 4), 200+Random.Range (-4, 4), 100+Random.Range (-4, 4)), Quaternion.identity);
		}
	}



	private void CreateInstances() {


	}
}
