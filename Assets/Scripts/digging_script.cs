using UnityEngine;
using System.Collections;


public class digging_script : MonoBehaviour {
	Terrain  terrain; 
	TerrainData tData;
	
	int xRes;
	int yRes;
	
	float[,] heights;
	
	void Start () { 
		terrain = transform.GetComponent<Terrain>(); 
		tData = terrain.terrainData;
		
		xRes = tData.heightmapWidth;
		yRes = tData.heightmapHeight;

		randomizePoints(-0.1f);
	}

	
	void randomizePoints(float strength) { 
		heights = tData.GetHeights(0, 0, xRes, yRes);
		
		for (int y = 0; y < yRes; y++) {
			for (int x = 0; x < xRes; x++) {
				heights[x,y] = Random.Range(-0.1f, strength) * 0.5f;
			}
		}
		
		tData.SetHeights(0, 0, heights);
	}

	void OnMouseDown() {
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Debug.Log (mousePosition.x + "," + mousePosition.y + "," + mousePosition.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
 * 		for (int y = 0; y < yRes; y++) {
			for (int x = 0; x < xRes; x++) {
				heights[x,y] = Random.Range(0.0f, strength) * 0.5f;
			}
		}
		*/
