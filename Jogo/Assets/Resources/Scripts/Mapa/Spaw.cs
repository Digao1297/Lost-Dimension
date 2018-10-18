using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spaw : MonoBehaviour {
 

	public int largura;
	public float alturaMult;
    public int alturaAdd;
	public float Suavidade;
	[HideInInspector]
	public float seed;
    //GameObjects
    public GameObject Terra;
    public GameObject Pedra;
    public GameObject Grama;
    public GameObject Rocha;
    public GameObject carvao;
	public GameObject ferro;
	public GameObject cobre;
	public GameObject quadPala;
    public GameObject arvore;
    public GameObject salgueiro;
    public GameObject arbusto;
    public GameObject frogion;
    public GameObject nekofiro;




   
    public TextAsset xml;
	private List<Bloco> blocos;
    public List<Animal> animal;



	void Start () {
        animal = LerXml.Animal(xml);
        blocos = LerXml.Bloco (xml);
        
		foreach (var bloco in blocos) {
			if (bloco.nomes.Equals("cobre")) {
				cobre.GetComponent<Minerios>().raridade= bloco.raridade;
                cobre.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
			}if (bloco.nomes.Equals("carvao")) {
                carvao.GetComponent<Minerios>().raridade = bloco.raridade;
                carvao.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("ferro")) {
                ferro.GetComponent<Minerios>().raridade = bloco.raridade;
               ferro.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("quadpala")) {
                quadPala.GetComponent<Minerios>().raridade = bloco.raridade;
                quadPala.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("pedra"))
            {
                Pedra.GetComponent<Minerios>().raridade = bloco.raridade;
                Pedra.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("terra"))
            {
                Terra.GetComponent<Minerios>().raridade = bloco.raridade;
                Terra.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("grama"))
            {
                Grama.GetComponent<Minerios>().raridade = bloco.raridade;
                Grama.GetComponent<Minerios>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("arvoreDragao"))
            {
                arvore.GetComponent<Fauna>().raridade = bloco.raridade;
                arvore.GetComponent<Fauna>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("arbusto"))
            {
                arbusto.GetComponent<Fauna>().raridade = bloco.raridade;
                arbusto.GetComponent<Fauna>().durabilidade = bloco.durabilidade;
            }
            if (bloco.nomes.Equals("salgueiro"))
            {
                salgueiro.GetComponent<Fauna>().raridade = bloco.raridade;
                salgueiro.GetComponent<Fauna>().durabilidade = bloco.durabilidade;
            }





        }
        foreach (var a in animal)
        {
            if (a.nome.Equals("Frogion"))
            {
                frogion.GetComponent<Animal>().nome = a.nome;
                frogion.GetComponent<Animal>().raridade = a.raridade;
                frogion.GetComponent<Animal>().vida = a.vida;
                frogion.GetComponent<Animal>().dano= a.dano;
                frogion.GetComponent<Animal>().velocidadeAT = a.velocidadeAT;
                frogion.GetComponent<Animal>().VelocidadeM = a.VelocidadeM;

            }
            if (a.nome.Equals("Nekofiro"))
            {
                nekofiro.GetComponent<Animal>().nome = a.nome;
                nekofiro.GetComponent<Animal>().raridade = a.raridade;
                nekofiro.GetComponent<Animal>().vida = a.vida;
                nekofiro.GetComponent<Animal>().dano = a.dano;
                nekofiro.GetComponent<Animal>().velocidadeAT = a.velocidadeAT;
                nekofiro.GetComponent<Animal>().VelocidadeM = a.VelocidadeM;

            }
        }

        Gerador ();
       
    }


    void Gerador () {
		for (int i = 0; i <largura; i++) {
			int h=Mathf.RoundToInt(Mathf.PerlinNoise(seed,(i+transform.position.x)/Suavidade)*alturaMult)+alturaAdd;
            for (int j = 0; j < h; j++) {
				GameObject Bloco;

				if (j<h-h+1) {
					Bloco = Rocha;
				}
				else if (j < h - 8) {
					Bloco = Pedra;
				} else if (j < h -1) {
					Bloco = Terra;
				} else {
					Bloco = Grama;
				}	
				GameObject newTile = Instantiate (Bloco, Vector3.zero,
					                    Quaternion.identity)as GameObject;
				newTile.transform.parent = this.gameObject.transform;
				newTile.transform.localPosition = new Vector2 (i, j);
			}	
		}

		Populate ();
        PopulateArvores();
        PopulateAnimais();
        
    }
	public void Populate(){
		foreach (GameObject t in GameObject.FindGameObjectsWithTag
			("min-Pedra")) {
			if (t.transform.parent==this.gameObject.transform) {
			float r  = Random.Range (0f, 100f);
			GameObject Selecionar = null;

                if (r<quadPala.GetComponent<Minerios>().raridade) {
					Selecionar = quadPala;
				}else if (r<ferro.GetComponent<Minerios>().raridade) {
					Selecionar = ferro;
				}else if (r<cobre.GetComponent<Minerios>().raridade) {
					Selecionar = cobre;
				}
				else if (r<carvao.GetComponent<Minerios>().raridade) {
				Selecionar = carvao;
			}
			
				if (Selecionar != null) {
					GameObject newResourceTile=Instantiate (Selecionar, t.transform.position,
						Quaternion.identity)as GameObject;
					Destroy (t);
				}
				}
		}



	}
    public void PopulateArvores() {
       
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("min-Grama"))
        {
            

            if (g.transform.parent==this.gameObject.transform)
            {
                
                
                   
                    
                

                float r = Random.Range(0f, 100f);
                GameObject select=null;
                if (r<=arvore.GetComponent<Fauna>().raridade)
                {
                    select = arvore;
                }else if (r <= salgueiro.GetComponent<Fauna>().raridade)
                {
                    select = salgueiro;
                }
                else if (r<=arbusto.GetComponent<Fauna>().raridade)
                {
                    select = arbusto;
                }
                if (select!=null&&select==salgueiro)
                {
                    GameObject newResourseTile = Instantiate(select, new Vector3(g.transform.position.x, g.transform.position.y + 3.005f, 0), Quaternion.identity) as GameObject;
                   
                    
                }
                if (select!=null&&select==arvore)
                {
                    GameObject newResourseTile = Instantiate(select, new Vector3(g.transform.position.x,g.transform.position.y+3.005f,0), Quaternion.identity) as GameObject;
               
                   
                }
                if (select!=null&&select==arbusto)
                {
                    GameObject newResourseTile = Instantiate(select, new Vector3(g.transform.position.x, g.transform.position.y + 1, 0), Quaternion.identity) as GameObject;
                    
                    
                }
            }
        }
    }
    public void PopulateAnimais()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("min-Grama"))
        {
            if (g.transform.parent == this.gameObject.transform)
            {
                float r = Random.Range(0f, 100f);
                GameObject select = null;
                if (r<= nekofiro.GetComponent<Animal>().raridade)
                {
                    select = nekofiro;
                }else if (r<= frogion.GetComponent<Animal>().raridade)
                {
                    select = frogion;
                }
                if (select!=null)
                {
                    if (select==frogion)
                    {
                        GameObject newObgject = Instantiate(select, new Vector3(g.transform.position.x, g.transform.position.y + 1.275f, 0), Quaternion.identity) as GameObject;
                    }
                    if (select == nekofiro)
                    {
                        GameObject newObgject = Instantiate(select, new Vector3(g.transform.position.x, g.transform.position.y + 4f, 0), Quaternion.identity) as GameObject;
                    }
                }
            }
        }
    }

   
}
