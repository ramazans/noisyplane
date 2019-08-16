using UnityEngine;
using System.Collections;

public class SceneLooper : MonoBehaviour {
	[System.Serializable]
	public class ObjectToLoop {
		//This would be multiplied by the sceneSpeed for paralaxing effect
		public float speedMultiplier;
		//Parent holding the tiles
		public Transform parentHoldingObjects;
		//size of the one tile 
		[HideInInspector]
		public float sizeOfOneTile;
		//rightest tile
		[HideInInspector]
		public Transform lastTile;
	}
	//How fast?
	public float sceneSpeed = 5.0f;
	//On which element the obstacles should be planted
	public int plantObstaclesInElement = 1;
	//Object to apply the motion to
	public ObjectToLoop[] objectsToLoop;
	//All the obstacles
	public GameObject[] obstacles;
	//this is to check whether the game has started or not
	public PlaneMovement plane;

	// Use this for initialization
	void Start () {
		//Calculates size of the tile and choses the object on the rightest side
		CalculateSizeAndSelectLastTile ();
	}

	void CalculateSizeAndSelectLastTile (){

		foreach (ObjectToLoop currObj in objectsToLoop){
			if (currObj.parentHoldingObjects && currObj.parentHoldingObjects.childCount > 0){

				for (int i = 0; i < currObj.parentHoldingObjects.childCount; i++){
					if (!currObj.lastTile){
						currObj.lastTile = currObj.parentHoldingObjects.GetChild(i).transform;
					}
					if (currObj.lastTile.position.x < currObj.parentHoldingObjects.GetChild(i).position.x){
						currObj.lastTile = currObj.parentHoldingObjects.GetChild(i).transform;
					}
				}
				//calculate the xSize of the tile
				if (currObj.parentHoldingObjects.GetChild(0).GetComponent<SpriteRenderer>()){
					currObj.sizeOfOneTile = currObj.parentHoldingObjects.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x - 0.01f;;
				}
				else {
					Debug.LogWarning("Script was not able to find a sprite renderer attached to the parent's first child");
				}
			}
			else {
				Debug.LogWarning("parent object missing");
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		//Mave and place object on after the other
		MoveObjects ();
	}
	//Move and reset tiles the set the obstacles
	void MoveObjects (){
		int currChilds = 0;
		int currentElement = 0;
		GameObject tempObstacle;
		int randomObstacle = 0;

		foreach (ObjectToLoop currObj in objectsToLoop) {
			if (currObj.parentHoldingObjects)
				currChilds = currObj.parentHoldingObjects.childCount;
			else{
				Debug.LogWarning("Variable missing");
				break;
			}
			for (int i = 0; i < currChilds; i++){
				if (currObj.parentHoldingObjects.GetChild(i).position.x < -((currChilds/2)*(currObj.sizeOfOneTile*1.25))){
					//reset the tile and set it to be the last tile
					currObj.parentHoldingObjects.GetChild(i).position = new Vector3 (currObj.lastTile.position.x + currObj.sizeOfOneTile,currObj.parentHoldingObjects.GetChild(i).position.y,currObj.parentHoldingObjects.GetChild(i).position.z);
					currObj.lastTile = currObj.parentHoldingObjects.GetChild(i).transform;

					if (currentElement == plantObstaclesInElement){
						//Destroy the last created obstacles
						for (int j = 0; j < currObj.parentHoldingObjects.GetChild(i).transform.childCount; j++){
							Destroy(currObj.parentHoldingObjects.GetChild(i).transform.GetChild(j).gameObject);
						}
						//Place obstacles
						if (currentElement == plantObstaclesInElement && plane && plane.started){
							randomObstacle = Random.Range(0,obstacles.Length);
							if (obstacles[randomObstacle]){
								tempObstacle = (GameObject)Instantiate(obstacles[randomObstacle],currObj.parentHoldingObjects.GetChild(i).position,Quaternion.identity);
								tempObstacle.transform.parent = currObj.parentHoldingObjects.GetChild(i).transform;
							}
							else{
								Debug.Log("Obstacle slot empty");
							}
						}
					}
				} 
				//Move objects
				currObj.parentHoldingObjects.GetChild(i).position = new Vector3 (currObj.parentHoldingObjects.GetChild(i).position.x - ((sceneSpeed * currObj.speedMultiplier) * Time.deltaTime),currObj.parentHoldingObjects.GetChild(i).position.y,currObj.parentHoldingObjects.GetChild(i).position.z);

			}
			currentElement++;
		}
	}	
}