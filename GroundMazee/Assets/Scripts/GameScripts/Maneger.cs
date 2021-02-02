using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneger : MonoBehaviour
{
    [Header("Swipe Scripti")]
    public Swipe swipeSc;


    public GameObject spere;
    public Transform solSphereTransforms;
    public Transform sagSphereTransforms;
    public Transform asansorSol;
    public Transform asansorSag;
    public GameObject asansor;
    public Material red;
    public Material blue;


    bool asansorControler;
    List<Material> materials;
    void Start()
    {


        asansorControler = false;
        int random;


        materials = new List<Material>();

        for (int i = 0; i < solSphereTransforms.childCount; i++)
        {
            materials.Add(red);
            materials.Add(blue);

        }

        random = Random.Range(0, 2);

        for (int i = 0; i < 4; i++)
        {
            if (random == 0)
            {
                materials.Add(red);
            }
            else
            {
                materials.Add(blue);
            }
        }






        for (int i = 0; i < solSphereTransforms.childCount; i++)
        {

            random = Random.Range(0, materials.Count);

            Instantiate(spere, solSphereTransforms.GetChild(i)).GetComponent<Renderer>().material = materials[random];
            materials.Remove(materials[random]);

            random = Random.Range(0, materials.Count);

            Instantiate(spere, sagSphereTransforms.GetChild(i)).GetComponent<Renderer>().material = materials[random];
            materials.Remove(materials[random]);

        }


        for (int i = 0; i < 4; i++)
        {

            random = Random.Range(0, materials.Count);

            Instantiate(spere, asansor.transform.Find(i.ToString()).transform).GetComponent<Renderer>().material = materials[random];
            materials.Remove(materials[random]);
        }


        for (int i = 0; i < solSphereTransforms.childCount; i++)
        {
            solSphereTransforms.GetChild(i).GetChild(0).tag = "top";
            sagSphereTransforms.GetChild(i).GetChild(0).tag = "top";

        }
        for (int i = 0; i < 4; i++)
        {
            asansor.transform.Find(i.ToString()).GetChild(0).gameObject.tag = "top";
        }


       
    }


    
    private void Update()
    {

        RaycastHit hit;
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        if ((Physics.Raycast(ray, out hit)))
        {
            if (hit.transform.tag == "top")   /// topların hareketi için
            {
                if (swipeSc.SwipeDown)
                {
                    changeSphare();
                }
                else if (swipeSc.SwipeUp)
                {
                    changeSphareTers();
                }
               
            }
        }

        if ((Physics.Raycast(ray, out hit)))
        {
            if (hit.transform.tag == "asansor")
            {
                if (swipeSc.SwipeRight)
                {
                    asansorMeth();
                }
                else if (swipeSc.SwipeLeft)
                {
                    asansorMeth();
                }
            }



        }

    }









    public void asansorMeth()
    {

        if (asansorControler)
        {
            asansor.transform.position = asansorSol.position;

            asansorControler = false;
        }
        else if (!asansorControler)
        {
            asansor.transform.position = asansorSag.position;
            asansorControler = true;
        }

    }


    GameObject holder;
    public void changeSphare()
    {
        List<GameObject> colorList = new List<GameObject>();

        if (!asansorControler)
        {
            for (int i = 0; i < solSphereTransforms.childCount; i++)
            {
                colorList.Add(solSphereTransforms.GetChild(i).gameObject);
            }

            for (int i = 0; i < 4; i++)
            {
                colorList.Add(asansor.transform.Find(i.ToString()).gameObject);

            }

            for (int i = 0; i < colorList.Count; i++)
            {
                if (i == 0)
                {
                    holder = colorList[i].transform.GetChild(0).gameObject;

                }



                if (i + 1 != colorList.Count)
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(colorList[i + 1].transform.GetChild(0).gameObject, colorList[i].transform);

                }
                else
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(holder, colorList[i].transform);

                }

            }



        }
        else if (asansorControler)
        {

            for (int i = 0; i < sagSphereTransforms.childCount; i++)
            {
                colorList.Add(sagSphereTransforms.GetChild(i).gameObject);
            }

            for (int i = 3; i >= 0; i--)
            {
                colorList.Add(asansor.transform.Find(i.ToString()).gameObject);

            }

            for (int i = colorList.Count - 1; i >= 0; i--)
            {
                if (i == colorList.Count - 1)
                {
                    holder = colorList[i].transform.GetChild(0).gameObject;


                }

                if (i != 0)
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(colorList[i - 1].transform.GetChild(0).gameObject, colorList[i].transform);

                }
                else
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(holder, colorList[i].transform);

                }




            }




        }










    }


    public void changeSphareTers()
    {
        List<GameObject> colorList = new List<GameObject>();

        if (!asansorControler)
        {
            for (int i = 0; i < solSphereTransforms.childCount; i++)
            {
                colorList.Add(solSphereTransforms.GetChild(i).gameObject);
            }

            for (int i = 0; i < 4; i++)
            {
                colorList.Add(asansor.transform.Find(i.ToString()).gameObject);

            }

            for (int i = colorList.Count - 1; i >= 0; i--)
            {
                if (i == colorList.Count - 1)
                {
                    holder = colorList[i].transform.GetChild(0).gameObject;


                }

                if (i != 0)
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(colorList[i - 1].transform.GetChild(0).gameObject, colorList[i].transform);

                }
                else
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(holder, colorList[i].transform);

                }




            }




        }
        else if (asansorControler)
        {

            for (int i = 0; i < sagSphereTransforms.childCount; i++)
            {
                colorList.Add(sagSphereTransforms.GetChild(i).gameObject);
            }

            for (int i = 3; i >= 0; i--)
            {
                colorList.Add(asansor.transform.Find(i.ToString()).gameObject);

            }


            for (int i = 0; i < colorList.Count; i++)
            {
                if (i == 0)
                {
                    holder = colorList[i].transform.GetChild(0).gameObject;

                }



                if (i + 1 != colorList.Count)
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(colorList[i + 1].transform.GetChild(0).gameObject, colorList[i].transform);

                }
                else
                {
                    Destroy(colorList[i].transform.GetChild(0).gameObject);
                    Instantiate(holder, colorList[i].transform);

                }

            }

           



        }










    }

}
