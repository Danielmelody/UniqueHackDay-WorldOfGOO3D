using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerController : MonoBehaviour
{
    private LineRenderer lineRendererProto;
    private LineRenderer lineRenderer;
    public Transform origin;
    public Transform dest;

    public lazerController init(Transform origin, Transform dest) {
        this.origin = origin;
        this.dest = dest;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
        return this;
    }

	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, dest.position);
	}
}
