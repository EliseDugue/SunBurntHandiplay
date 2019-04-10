using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount;

	List<GameObject> pooledObjects;

	// Use this for initialization 
	void Start () {
		pooledObjects = new List<GameObject>();

		for(int i = 0; i < pooledAmount; i++) {

			GameObject obj = (GameObject)Instantiate(pooledObject); // crée un objet
			obj.SetActive(false); // l'objet n'est pas actif
			pooledObjects.Add (obj); // ajoute l'objet à la liste

		} //fin du FOR

	} // fin du START
	
	
	public GameObject GetPooledObject() {

		// boucle FOR pour accéder un à un aux objets de la liste
		for(int i = 0; i < pooledObjects.Count; i++) {

			// si l'objet dans la liste n'est pas actif...
			if (!pooledObjects[i].activeInHierarchy) {

				return pooledObjects[i]; //retourner l'objet de la liste

			} //fin du IF

		} //fin du FOR


		GameObject obj = (GameObject)Instantiate(pooledObject); // crée un objet
		obj.SetActive(false); // l'objet n'est pas actif
		pooledObjects.Add (obj); // ajoute l'objet à la liste

		return obj; //renvoie l'objet

		
	} // fin de la fonction

} // fin de la classe
