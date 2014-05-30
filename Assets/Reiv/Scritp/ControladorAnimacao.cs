using UnityEngine;
using System.Collections;

public class ControladorAnimacao : MonoBehaviour {


	public Animator animator;

	private ThirdPersonController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<ThirdPersonController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.Walking) 
			animator.SetFloat ("velocidade", 1.0F);
		else
			animator.SetFloat ("velocidade", 0.0F);
	}
}
