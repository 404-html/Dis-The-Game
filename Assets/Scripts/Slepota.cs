using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class Slepota : MonoBehaviour {

	public GameObject camera;
	public PostProcessingProfile blurProfile;
	public float val;
	// Use this for initialization
	void Start () {
		SetDof (0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.name == "Player")
		{
			SetDof (val);

		}

	}

	public void SetDof(float val)
	{
		
		var dof = blurProfile.chromaticAberration.settings;
		dof.intensity = val;
		blurProfile.chromaticAberration.settings = dof;
	}
}
