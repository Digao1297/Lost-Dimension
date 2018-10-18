using UnityEngine;
using System.Collections;

public class CanvasCraft : MonoBehaviour {
	public Inventario inv;
    public GameObject carneA;
    public GameObject fogueira;
	public GameObject fornalha;
	public GameObject mesa;
    public GameObject paMadeira;
    public GameObject picMadeira;
    public GameObject macMadeira;
    public GameObject espMadeira;
    public GameObject paPedra;
    public GameObject picPedra;
    public GameObject macPedra;
    public GameObject espPedra;
    public GameObject paCobre;
    public GameObject picCobre;
    public GameObject macCobre;
    public GameObject espCobre;
    public GameObject paFerro;
    public GameObject picFerro;
    public GameObject macFerro;
    public GameObject espFerro;
    public GameObject paAco;
    public GameObject picAco;
    public GameObject macAco;
    public GameObject espAco;
    public GameObject macQuad;
    public GameObject espQuad;
    public GameObject tocha;
    public GameObject lAco;
    public GameObject lFerro;
    public GameObject lCobre;

    public GameObject showCraft;
    public bool tmpPertoM, tmpPertoF, tmpPertoFo;

   
	// Use this for initialization
	void Start () {
		inv = FindObjectOfType<Inventario>();
       
	}
	
	// Update is called once per frame
	void Update () {

       

	foreach (var r in inv.inventairo) {

			


		if ((r.nomes == "pedra") && (r.amount >= 30)) {
			fornalha.SetActive (true);
		}  
		if ((r.nomes == "pedra") && (r.amount < 30)) {
			fornalha.SetActive (false);
			
		}
		if ((r.nomes == "tronco") && (r.amount >= 20)) {
				mesa.SetActive (true);
		}  
		if ((r.nomes == "tronco") && (r.amount < 20)) {
				mesa.SetActive (false);
				
		}
            if ((r.nomes == "tronco") && (r.amount >= 10))
            {
                fogueira.SetActive(true);

            }
            if ((r.nomes == "tronco") && (r.amount < 10)){
                fogueira.SetActive(false);

            }

            if ((r.nomes == "graveto") && (r.amount >= 1))
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "gosma") && (s.amount >= 1))
                    {

                        tocha.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "gosma") && (r.amount < 1)))
            {
                tocha.SetActive(false);

            }

            
            if ((r.nomes == "lingote de Ferro") && (r.amount >= 2)&& tmpPertoF)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "mCarvao") && (s.amount >= 10))
                    {

                        lAco.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "lingote de Ferro") && (r.amount < 2)) || ((r.nomes == "mCarvao") && (r.amount < 10))|| !tmpPertoF)
            {
                lAco.SetActive(false);

            }
            if ((r.nomes == "mCobre") && (r.amount >= 2) && tmpPertoF)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "mCarvao") && (s.amount >= 2))
                    {

                        lCobre.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "mCobre") && (r.amount < 2)) || ((r.nomes == "mCarvao") && (r.amount < 2)) || !tmpPertoF)
            {
                lCobre.SetActive(false);

            }
            if ((r.nomes == "mFerro") && (r.amount >= 2) && tmpPertoF)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "mCarvao") && (s.amount >= 5))
                    {

                        lFerro.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "mFerro") && (r.amount < 2)) || ((r.nomes == "mCarvao") && (r.amount < 5)) ||!tmpPertoF)
            {
                lFerro.SetActive(false);

            }

            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "tronco") && (s.amount >= 3))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                               
                                picMadeira.SetActive(true);
                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "tronco") && (r.amount < 3)) || ((r.nomes == "cipo") && (r.amount < 5)) || !tmpPertoM)
            {

                picMadeira.SetActive(false);

            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "tronco") && (s.amount >= 2))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                                macMadeira.SetActive(true);
                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "cipo") && (r.amount < 5)) || !tmpPertoM)
            {
                macMadeira.SetActive(false);

            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "tronco") && (s.amount >= 1))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                                paMadeira.SetActive(true);

                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "cipo") && (r.amount < 5)) || !tmpPertoM)
            {
                paMadeira.SetActive(false);


            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "tronco") && (s.amount >= 2))
                    {

                        espMadeira.SetActive(true);


                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "tronco") && (r.amount < 2)) || !tmpPertoM)
            {
                espMadeira.SetActive(false);

            }

            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "pedra") && (s.amount >= 1))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                                paPedra.SetActive(true);

                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "pedra") && (r.amount < 1)) || ((r.nomes == "cipo") && (r.amount < 5))||!tmpPertoM)
            {
                paPedra.SetActive(false);

            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "pedra") && (s.amount >= 3))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                                picPedra.SetActive(true);

                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "pedra") && (r.amount < 3)) || ((r.nomes == "cipo") && (r.amount < 5)) || !tmpPertoM)
            {
                picPedra.SetActive(false);

            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "pedra") && (s.amount >= 2))
                    {
                        foreach (var t in inv.inventairo)
                        {
                            if ((t.nomes == "cipo") && (t.amount >= 5))
                            {
                                macPedra.SetActive(true);

                            }
                        }
                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "pedra") && (r.amount < 2)) || ((r.nomes == "cipo") && (r.amount < 5)) ||!tmpPertoM)
            {
                macPedra.SetActive(false);

            }
            if ((r.nomes == "graveto") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "pedra") && (s.amount >= 3))
                    {

                        espPedra.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "graveto") && (r.amount < 1)) || ((r.nomes == "pedra") && (r.amount < 3)) ||!tmpPertoM)
            {
                espPedra.SetActive(false);

            }
            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de F") && (s.amount >= 2))
                    {

                        paCobre.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Cobre") && (r.amount < 2)) ||!tmpPertoM)
            {
                paCobre.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Cobre") && (s.amount >= 4))
                    {

                        picCobre.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Cobre") && (r.amount < 4)) ||!tmpPertoM)
            {
                picCobre.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Cobre") && (s.amount >= 3))
                    {

                        macCobre.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Cobre") && (r.amount < 3)) ||!tmpPertoM)
            {
                macCobre.SetActive(false);

            }
            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Cobre") && (s.amount >= 2))
                    {

                        espCobre.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Cobre") && (r.amount < 2)) ||!tmpPertoM)
            {
                espCobre.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Ferro") && (s.amount >= 4))
                    {

                        paFerro.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Ferro") && (r.amount < 4)) ||!tmpPertoM)
            {
                paFerro.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Ferro") && (s.amount >= 4))
                    {

                        picFerro.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Ferro") && (r.amount < 4)) ||!tmpPertoM)
            {
                picFerro.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Ferro") && (s.amount >= 3))
                    {

                        macFerro.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Ferro") && (r.amount < 3)) ||!tmpPertoM)
            {
                macFerro.SetActive(false);

            }
            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Ferro") && (s.amount >= 2))
                    {

                        espFerro.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Ferro") && (r.amount < 2)) ||!tmpPertoM)
            {
                espFerro.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Aco") && (s.amount >= 2))
                    {

                        paAco.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Aco") && (r.amount < 2)) ||!tmpPertoM)
            {
                paAco.SetActive(false);

            }

            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Aco") && (s.amount >= 4))
                    {

                        picAco.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Aco") && (r.amount < 4)) ||!tmpPertoM)
            {
                picAco.SetActive(false);

            }
            if ((r.nomes == "tronco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Aco") && (s.amount >= 3))
                    {

                        macAco.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 2)) || ((r.nomes == "lingote de Aco") && (r.amount < 3)) ||!tmpPertoM)
            {
                macAco.SetActive(false);

            }
            if ((r.nomes == "tronco") && (r.amount >= 1) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "lingote de Aco") && (s.amount >= 2))
                    {

                        espAco.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "tronco") && (r.amount < 1)) || ((r.nomes == "lingote de Aco") && (r.amount < 2)) ||!tmpPertoM)
            {
                espAco.SetActive(false);

            }

            if ((r.nomes == "lingote de Aco") && (r.amount >= 4) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "mQuadPala") && (s.amount >= 2))
                    {

                        macQuad.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "lingote de Aco") && (r.amount < 4)) || ((r.nomes == "mQuadPala") && (r.amount < 2)) ||!tmpPertoM)
            {
                macQuad.SetActive(false);

            }

            if ((r.nomes == "lingote de Aco") && (r.amount >= 2) && tmpPertoM)
            {
                foreach (var s in inv.inventairo)
                {
                    if ((s.nomes == "mQuadPala") && (s.amount >= 2))
                    {

                        espQuad.SetActive(true);



                    }
                }
            }
            if (((r.nomes == "lingote de Aco") && (r.amount < 2)) || ((r.nomes == "mQuadPala") && (r.amount < 2)) ||!tmpPertoM)
            {
                espQuad.SetActive(false);

            }
            if (r.nomes== "carneC"&&r.amount>=1&&tmpPertoFo)
            {
                foreach (var s in inv.inventairo)
                {
                    if (s.nomes=="mCarvao"&&s.amount>=1)
                    {
                        carneA.SetActive(true);
                    }
                }
            }
            if (((r.nomes == "carneA") && (r.amount < 1) || ((r.nomes == "mCarvao") && (r.amount < 1)) || !tmpPertoFo))
            {
                carneA.SetActive(false);

            }
        }

        print(tmpPertoM);
    }


    public void GetPertoF(bool pertoF)
    {
        tmpPertoF = pertoF;
    }
    public void GetPertoM(bool pertoM)
    {
        tmpPertoM = pertoM;
    }
    public void GetPertoFo(bool pertoFo)
    {
        tmpPertoFo = pertoFo;
    }
}