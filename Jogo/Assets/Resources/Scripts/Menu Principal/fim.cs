using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class fim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Voltar(){
		SceneManager.LoadScene ("menu");
		//Application.LoadLevel("menu");
	}
	public void Sair(){
		Application.Quit();
	}
}
