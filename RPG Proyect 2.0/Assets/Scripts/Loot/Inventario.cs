using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventario : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    public Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform exParent;
    void Start()
    {
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        Arrastrar();
    }
    void Arrastrar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
            graphRay.Raycast(pointerData, raycastResults);
            if(raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    exParent = objetoSeleccionado.transform.parent.transform; //para guardar la posicion principal del item al pulsarlo
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }

        if(objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition); //Que se vea el item moviendose junto al raton
        }
        if (Input.GetMouseButtonUp(0))
        {
            pointerData.position = Input.mousePosition;
            raycastResults.Clear();
            graphRay.Raycast(pointerData, raycastResults);
            if(raycastResults.Count > 0)
            {
                foreach(var resultado in raycastResults)
                {
                    if(resultado.gameObject.tag == "Slot")
                    {
                        /*if (resultado.gameObject.GetComponentInChildren<Item> == null)
                        {

                        }*/
                    }
                }
            }
            objetoSeleccionado = null;
        }
        raycastResults.Clear();
    }
    public Vector2 CanvasScreen(Vector2 screenPos) //Ubicar la camara principal para ver el rango de vision de la camara
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta; //Coge el tamaño del canvas

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2)); 
    }
}
