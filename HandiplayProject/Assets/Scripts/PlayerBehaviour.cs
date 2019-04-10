using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

	// On déclare les variables

	public float moveSpeed; // Définit la vitesse de déplacement du joueur
	public float jumpForce; // Définit la force du saut du joueur, elle dépend aussi de la gravité

	private Rigidbody2D rb2D; // Notre joueur
	private Collider2D myCollider2D; // La zone de collision du joueur

	public bool onTheGround; // Booléen qui servira à tester si le joueur touche le sol
	public LayerMask theGround; // Définit ce qu'est le sol

	// Use this for initialization
	void Start () {
		
		// On cherche le Rigidbody du GameObject (Player)
		rb2D = GetComponent<Rigidbody2D>();
		// On cherche le Collider du GameObject (Player)
		myCollider2D = GetComponent<Collider2D>();

		// On définit la vitesse de déplacement du joueur
		/* A11Y : pouvoir changer la vitesse dans un menu */
		moveSpeed = 5;

		//On définit la force du saut
		jumpForce = 25;

		} // fin de la fonction Start
	
	
	// Update is called once per frame
	void FixedUpdate () {

        //Le booléen est vrai lorsque le joueur touche le sol défini dans la couche theGround
        onTheGround = Physics2D.IsTouchingLayers(myCollider2D,theGround);

		// Le joueur se déplace tout seul vers la droite avec une vitesse moveSpeed par frame
		rb2D.velocity = new Vector2(moveSpeed,rb2D.velocity.y);

        // Si le joueur appuie sur la touche configurée pour la valeur positive de l'axe Vertical 
        // ET... si il sur le sol, donc si le booléen onTheGround est vrai :
		if (Input.GetAxis("Vertical") > 0f && onTheGround) {

			// Le joueur se déplace verticalement de la valeur jumpForce. Il est affecté par le vecteur de déplacement horiziontal et la gravité
			rb2D.velocity = new Vector2(rb2D.velocity.x,jumpForce);
			
		} // fin du if

	} // fin de la fonction FixedUpdate




} // fin de classe
