using UnityEngine;
using System.Collections;

public class CameraSegue : MonoBehaviour {
	private GameObject jogador;
	private Vector2 velocidade;
	private float moof=0.09f;
	void Start () {
		jogador = GameObject.Find ("Jacklin");
		velocidade = new Vector2 (0.5f,0.5f);
	}


	void Update () {
		camSegue ();	
	}

	private void camSegue(){
        Vector2 posicaoCam=Vector2.zero;
		posicaoCam.x = Mathf.SmoothDamp (transform.position.x,
			jogador.transform.position.x, ref velocidade.x, moof);
		posicaoCam.y = Mathf.SmoothDamp (transform.position.y,
			jogador.transform.position.y, ref velocidade.y, moof);

		Vector3 novaPosicao = new Vector3 (posicaoCam.x,posicaoCam.y,
			transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao,
			Time.time);

        // new Vector3(jogador.transform.position.x, jogador.transform.position.y, -20f);
        //transform.position = Vector3.Lerp(new Vector3(jogador.transform.position.x, jogador.transform.position.y, -20f),jogador.transform.position, 0.3f);
    }
}
