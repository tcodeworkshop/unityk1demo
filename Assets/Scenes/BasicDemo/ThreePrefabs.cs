using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePrefabs : MonoBehaviour {

    [SerializeField]
    private GameObject prefab1;

    [SerializeField]
    private GameObject prefab2;

    [SerializeField]
    private GameObject prefab3;

    [SerializeField]
    private Transform pos1;

    [SerializeField]
    private Transform pos2;

    [SerializeField]
    private Transform pos3;

    // Use this for initialization
    void Start () {
        Instantiate(prefab1, pos1.position, Quaternion.identity);
        Instantiate(prefab2, pos2.position, Quaternion.identity);
        Instantiate(prefab3, pos3.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
