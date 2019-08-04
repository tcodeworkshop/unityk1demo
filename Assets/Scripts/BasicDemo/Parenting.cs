using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

    [SerializeField]
    private Transform _child = null;

    [SerializeField]
    private Transform _parent = null;


	// Use this for initialization
	private void Start () {
        _child.SetParent(_parent, worldPositionStays: false);
	}
}
