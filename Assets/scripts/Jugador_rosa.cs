using UnityEngine;
using System.Collections;

public class Jugador_rosa : Jugador {

	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
		activo = true;
		equipo = Equipos.Rosa;
		postura = Postura.DePie;
		this.velocidad = def_velocidad;

	}
	

}
