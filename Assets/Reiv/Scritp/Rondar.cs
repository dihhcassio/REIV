using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Mover))]
public class Rondar : MonoBehaviour
{

	public float distancia = 5.0F;
	public Mover.EnumDirecao direcaoInicial = Mover.EnumDirecao.NORTE;
	private Mover mover;

	private ArrayList pontosRonda;

	// Use this for initialization
	void Start ()
	{ 	
		pontosRonda = new ArrayList ();
		mover =GetComponent<Mover>();
		mover.DirecaoAtual = direcaoInicial;
		criaPontosDeRonda(transform.position);
	}

	// Update is called once per frame
	void Update ()
	{
		Mover.EnumDirecao direcao = mover.calcDirecaoDestino ((Vector3)pontosRonda [0]);
		Debug.Log (direcao);
		mover.Movimenta(direcao);
	}

	void criaPontosDeRonda (Vector3 position)
	{
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));

	}
}

