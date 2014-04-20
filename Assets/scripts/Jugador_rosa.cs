using UnityEngine;
using System.Collections;

public class Jugador_rosa : Jugador {

	// Use this for initialization
	void Start () {

		activo = true;
		equipo = Equipos.Rosa;
		this.velocidad = def_velocidad;
	
	}
	

}
