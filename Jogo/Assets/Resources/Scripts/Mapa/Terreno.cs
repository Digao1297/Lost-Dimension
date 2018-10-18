using UnityEngine;
using System.Collections;

public class Terreno : MonoBehaviour {
	private int y;
	private int x;
	public int tamx,tamy;
	public GameObject[] blocos;
	private GameObject[,] terreno;



	void Start () {
		
		terreno = new GameObject[tamx, tamy];

		for (x = 0; x < tamx; x++) {
			y = 0;
				//terreno[x,y]=(GameObject)Instantiate(blocos[Random.Range(0,blocos.Length)],new Vector3(x,y,0f),Quaternion.identity);
				if (y==0&&x<=tamx) {
					terreno [x, y] = (GameObject)Instantiate (blocos [3], new Vector3 (x, y, 0), Quaternion.identity);	

			}
		}
		for ( x = 0; x <tamx; x++) {
			for (y = 1; y <40; y++) {
				if (y<=40&&y>0) {
					terreno [x, y] = (GameObject)Instantiate (blocos [1], new Vector3 (x, y, 0), Quaternion.identity);		
				}

			}	
		}
		for ( x = 0; x <tamx; x++) {
			for (y = 40; y <tamy; y++) {
				if (y<=tamy&&y>0) {
					terreno [x, y] = (GameObject)Instantiate (blocos [0], new Vector3 (x, y, 0), Quaternion.identity);		
				}

			}	
		}
	

	}
	


}
