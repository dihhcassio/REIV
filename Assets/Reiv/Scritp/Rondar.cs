using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Mover))]
public class Rondar : MonoBehaviour
{

	public float distancia = 5.0F;
	public Mover.EnumDirecao direcaoInicial = Mover.EnumDirecao.NORTE;
	private Mover mover;
	public Object pau;

	private ArrayList pontosRonda;

	private int indexPontoAtual= 0;
	// Use this for initialization
	void Start ()
	{ 	
		pontosRonda = new ArrayList ();
		mover =GetComponent<Mover>();
		mover.DirecaoAtual = direcaoInicial;
		criaPontosDeRonda(transform.position);
		Object pauInstante = Instantiate(pau, (Vector3)pontosRonda[indexPontoAtual], transform.rotation);
	}

	// Update is called once per frame
	void Update ()
	{

		if (indexPontoAtual > (pontosRonda.Count - 1))
		    indexPontoAtual = 0;

		Mover.EnumDirecao direcao = mover.calcDirecaoDestino ((Vector3)pontosRonda[indexPontoAtual]);
		Debug.Log (direcao);
		mover.Movimenta(direcao);

//		if (direcao == Mover.EnumDirecao.PARADO){
//			indexPontoAtual++;
//			Object pauInstante = Instantiate(pau, (Vector3)pontosRonda[indexPontoAtual], transform.rotation);
//		}
	}

	void criaPontosDeRonda (Vector3 position)
	{
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z-distancia));
		pontosRonda.Add (new Vector3(position.x-distancia, position.y, position.z+distancia));
		pontosRonda.Add (new Vector3(position.x+distancia, position.y, position.z+distancia));
		pontosRonda.Add (new Vector3(position.x+distancia, position.y, position.z-distancia));

	}
}

