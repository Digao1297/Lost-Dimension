using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tela : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Inicializar(){
		SceneManager.LoadScene("Loading");
		//Application.LoadLevel("jogo");
	}
	public void Sair(){
		Application.Quit();
	}
}
