using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 mpos  = Input.mousePosition;
            mpos.z = 10;
            Ray ray = Camera.main.ScreenPointToRay(mpos);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                this.GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }
	}
}
