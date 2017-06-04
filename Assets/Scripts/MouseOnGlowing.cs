using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnGlowing : MonoBehaviour {
    private Renderer rend;
    public Material origin_mat;
    public Material dest_mat;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        origin_mat = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        //rend.material.shader = Shader.Find("Outlined/Silhouetted Diffuse");
        rend.material = dest_mat;
    }
    private void OnMouseExit()
    {
        rend.material = origin_mat;
    }
}
