using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

	public Vector3 redStar;
	public Vector3 blueStar;
	public List<GameObject> objs;
	public GameObject nowObj;

	void Start () {}
	
	void Update () {
		if(nowObj)
			blueStar = nowObj.transform.position;
	}

}
