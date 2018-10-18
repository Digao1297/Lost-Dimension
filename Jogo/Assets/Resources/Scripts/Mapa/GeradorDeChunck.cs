using UnityEngine;
using System.Collections;

public class GeradorDeChunck : MonoBehaviour {

	public GameObject chunk;
	private int Chunklargura;
	public int numChunk;
	private float seed;
    public GameObject personagem;

	void Start () {
		Chunklargura = chunk.GetComponent<Spaw> ().largura;
		seed = Random.Range (-100000f, 100000f);
		Gerar ();

      
    }
	
	
	void Gerar () {
		int lastX = -Chunklargura;
		for (int i = 0; i < numChunk; i++) {
			GameObject newChunk = Instantiate (chunk, new Vector2 (lastX + Chunklargura, 0f), Quaternion.identity)as GameObject;
			newChunk.GetComponent<Spaw> ().seed = seed;
			lastX += Chunklargura;
           
		}
	
	}



   

}
