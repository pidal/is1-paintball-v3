﻿using UnityEngine;
using System.Collections;

public class Arena : Terreno {

	// Use this for initialization
	void Start () {
		cambio_velocidad = 0.7f;
		cambio_radio_vision = 1;
		cambio_radio_disparo = 1;
		cambio_radio_deteccion = 1;
		cambio_transparencia = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
