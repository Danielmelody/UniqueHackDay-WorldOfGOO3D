using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndConnect : MonoBehaviour {

    public GameObject parent;

    public GameObject otherP;

    public GameObject laserProto;

    public GameObject[] connectors;

    public List<GameObject> lasers;

    void setOneSideSpring(DetectAndConnect sub, DetectAndConnect other)
    {
        var otherRB = other.GetComponent<Rigidbody>();
        var dir = (other.transform.position - sub.transform.position);
        float distance = (sub.transform.position - sub.parent.transform.position).magnitude * 1;
        dir.Normalize();
        SpringJoint sp1 = sub.gameObject.AddComponent<SpringJoint>();
        // sp1.autoConfigureConnectedAnchor = false;
        sp1.spring = 10000.0f;
        sp1.connectedBody = otherRB;
        sp1.anchor = Vector3.zero;
        sp1.connectedAnchor = Vector3.zero;
        // sp1.maxDistance = distance + 0.1f;
        // sp1.minDistance = distance - 0.1f;
        SpringJoint sp2 = sub.parent.AddComponent<SpringJoint>();
        //sp2.autoConfigureConnectedAnchor = false;
        sp2.spring = 10000.0f;
        sp2.connectedBody = otherRB;
        sp2.anchor = Vector3.zero;
        sp2.connectedAnchor = Vector3.zero;
        // sp2.maxDistance = distance + 0.1f + (sub.parent.transform.position - sub.transform.position).magnitude;
        // sp2.minDistance = distance - 0.1f + (sub.parent.transform.position - sub.transform.position).magnitude;

    }

    void OnTriggerEnter(Collider other)
    {
        if (!otherP)
        {

            var otherConnect = other.GetComponent<DetectAndConnect>();
            if (otherConnect && otherConnect.otherP != parent)
            {
                otherP = otherConnect.parent;
                var scripts = parent.GetComponentsInChildren<DetectAndConnect>();
                    foreach (DetectAndConnect script in scripts ) {
                        script.otherP = otherP;
                    }
                Debug.Log("detected");
                // Debug.Log(otherConnect);

                // GetComponent<Rigidbody>().AddForce(dir * 100.0f);
                //
                setOneSideSpring(this, otherConnect);
                setOneSideSpring(otherConnect, this);
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 4; ++j) {
                        var laser = Instantiate(laserProto);
                        laser.GetComponent<lazerController>().init(connectors[i].transform, otherConnect.connectors[j].transform);
                        laser.transform.parent = gameObject.transform;
                        lasers.Add(laser);
                    }
                }
            }
        }
    }

    void Start()
    {
        var otherP = parent.GetComponent<ParentDetect>().other;
        laserProto = GameObject.Find("Controler").GetComponent<HandleControler>().laserProto;
        connectors = new GameObject[4];
        lasers = new List<GameObject>();
        Vector3[] vertposes = new Vector3[] {
            new Vector3(0.5f, 0.5f, 0),
            new Vector3(0.5f, -0.5f, 0),
            new Vector3(-0.5f, 0.5f, 0),
            new Vector3(-0.5f, -0.5f, 0)
        };
        var offset = (parent.transform.position - transform.position) / 2.0f;
        for (int i = 0; i < 4; ++i)
        {
            connectors[i] = new GameObject();
            var con = connectors[i];
            con.transform.parent = gameObject.transform;
            con.transform.localPosition = vertposes[i];
            con.transform.position += offset;
        }
    }

	// Update is called once per frame
	void Update () {
	}
}
