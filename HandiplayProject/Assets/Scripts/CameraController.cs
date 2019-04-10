using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerBehaviour thePlayer; // reprend les conditions du script PlayerBehaviour pour définir ce qu'est le joueur et ses caractéristiques.

	private Vector3 lastPlayerPosition; // on utilise la 3D car la caméra fonctionne uniquement avec la 3D
	private float distanceToMove; // définit la distance de déplacement de la caméra

	// Use this for initialization
	void Start () {

		// Trouver le joueur à partir du script PlayerBehaviour
		thePlayer = FindObjectOfType<PlayerBehaviour>() ;

		// On enregistre la position du joueur dans une variable : on accède au paramètre position du composant transform inclus par défaut dans Unity
		lastPlayerPosition = thePlayer.transform.position; 

	} // fin de la fonction Start
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// On calcule la distance en soustrayant la position x du joueur actuellement de celle à la frame d'avant
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

		// La caméra avance sur l'axe x jusqu'à la nouvelle position du joueur
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		// On enregistre la position du joueur dans une variable : on accède au paramètre position du composant transform inclus par défaut dans Unity
		lastPlayerPosition = thePlayer.transform.position; 

	} // fin de la fonction FixedUpdate



} // fin de la classe
