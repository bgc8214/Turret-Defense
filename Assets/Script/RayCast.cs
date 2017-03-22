using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    public Camera camera;
    int PlaneMask;
    void Start () {
       PlaneMask  = 1 << LayerMask.NameToLayer("Plane");
    }

    
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, PlaneMask))
        {
            Transform objectHit = hit.transform;
            if(Input.GetMouseButtonDown(0)){ 
            Debug.Log(hit.collider.gameObject.name);
                
            }
        }

    }
}
