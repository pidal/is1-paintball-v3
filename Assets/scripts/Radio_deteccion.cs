using UnityEngine;
using System.Collections;

public class Radio_deteccion : MonoBehaviour {

	public float def_distancia;
	public float distancia;

	// Use this for initialization
	void Start () {
		def_distancia = 7;
		distancia = def_distancia;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		CircleCollider2D planetCollider = this.GetComponent<CircleCollider2D>();
		planetCollider.radius = distancia;
	}

	// El rango de deteccion no tiene que detectar nada. Es pasivo y auxiliar a los demas rangos.
}