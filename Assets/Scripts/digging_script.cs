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

		Debug.Log (xRes + "," + yRes);
		
		initializePoints();
	}

	//120 200 -420 10
	
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

		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.z);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.Log (ray);
		Debug.Log (Input.mousePosition);

		for (int z = (int) ray.origin.z - 50; z < (int) ray.origin.z + 50; z++) {
			for(int x = (int) ray.origin.x - 50; x < (int) ray.origin.x + 50; x++) {
				heights[z,x] = .1f;
			}
		}

		//heights[(int) ray.origin.z, (int) ray.origin.x] = 0.1f;

		tData.SetHeights (0, 0, heights);

	}

	void initializePoints() {
		heights = tData.GetHeights(0, 0, xRes, yRes);
		
		for (int y = 0; y < yRes; y++) {
			for (int x = 0; x < xRes; x++) {
				heights[x,y] = 0.0f;
			}
		}
		
		tData.SetHeights(0, 0, heights);
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
