using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Mover : MonoBehaviour {
	public float speed = 2.0F;
	public float jumpSpeed = 4.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private EnumDirecao direcaoAtual;
	private CharacterController controller;
	public enum EnumDirecao {PARADO, LESTE, OESTE, NORTE, SUL, NORDESTE, NOROESTE, SUDESTE, SUDOESTE}; 

	void Start ()
	{ 
		controller = GetComponent<CharacterController>();
	}


	// Update is called once per frame
	void Update ()
	{
	}
	

	public CollisionFlags Movimenta(EnumDirecao direcao, bool pula = false){
		 
		if (controller.isGrounded) {
			direcaoAtual = direcao;
			moveDirection = getVectorDirecao(direcao);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (pula)
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		return controller.Move(moveDirection * Time.deltaTime);
		
	}

	private Vector3 getVectorDirecao(EnumDirecao direcao){
		switch (direcao) {
		case EnumDirecao.NORTE:
			return new Vector3(0, 0, 1);
		case EnumDirecao.SUL:
			return new Vector3(0, 0, -1);
		case EnumDirecao.LESTE:
			return new Vector3(1, 0, 0);
		case EnumDirecao.OESTE:
			return new Vector3(-1, 0, 0);
		case EnumDirecao.NORDESTE:
			return new Vector3(1, 0, 1);
		case EnumDirecao.NOROESTE:
			return new Vector3(-1, 0, 1);
		case EnumDirecao.SUDESTE:
			return new Vector3(1, 0, -1);
		case EnumDirecao.SUDOESTE:
			return new Vector3(-1, 0, -1);;
		default:
			return Vector3.zero;
		}
	}


	public EnumDirecao calcDirecaoDestino(Vector3 positon){
			Vector3 origem = arredondar (transform.position);
			Vector3 destino = arredondar (positon);
			if ((origem.x == destino.x) && (origem.z == destino.z)) {
					return EnumDirecao.PARADO;
			} else if ((origem.x > destino.x) && (origem.z > destino.z)) {
					return EnumDirecao.SUDOESTE;
			} else if ((origem.x < destino.x) && (origem.z < destino.z)) {
					return EnumDirecao.SUDESTE;
			} else if ((origem.x > destino.x) && (origem.z < destino.z)) {
					return EnumDirecao.NOROESTE;
			} else if ((origem.x < destino.x) && (origem.z > destino.z)) {
					return EnumDirecao.NORDESTE;
			} else if ((origem.x == destino.x) && (origem.z > destino.z)) {
					return EnumDirecao.SUL;
			} else if ((origem.x == destino.x) && (origem.z < destino.z)) {
					return EnumDirecao.NORTE;
			} else if ((origem.x > destino.x) && (origem.z == destino.z)) {
					return EnumDirecao.OESTE;
			} else if ((origem.x < destino.x) && (origem.z == destino.z)) {
					return EnumDirecao.LESTE;
			} 
			return EnumDirecao.PARADO;
		}

	private Vector3 arredondar(Vector3 vector){
		return new Vector3 (Mathf.Round(vector.x * 10), Mathf.Round(vector.y* 10), Mathf.Round(vector.z* 10));
	}

	public EnumDirecao DirecaoAtual {
		get {
			return direcaoAtual;
		}
		set {
			direcaoAtual = value;
		}
	}

}

