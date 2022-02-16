using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventarioSwap : MonoBehaviour
{
    public GraphicRaycaster graphRay;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults; //Array para almacenar el item que coges con el raycaster
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
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>()) //si el objeto que pulsamos tiene el componente Item
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    exParent = objetoSeleccionado.transform.parent.transform; //para guardar la posicion principal del item al pulsarlo
                    objetoSeleccionado.transform.SetParent(canvas); //desenparentar el item del slit
                }
            }
        }

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition); //Que se vea el item moviendose junto al raton
        }
        if (Input.GetMouseButtonUp(0))
        {
            pointerData.position = Input.mousePosition;
            raycastResults.Clear(); //eliminar los resultados del RayCast
            graphRay.Raycast(pointerData, raycastResults); //para saber donde dejamos el item
            if (raycastResults.Count > 0)
            {
                foreach (var resultado in raycastResults)
                {
                    if (resultado.gameObject == objetoSeleccionado) continue;
                    if (resultado.gameObject.CompareTag("Slot")) //caso de slot libre
                    {
                        if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                        {
                            objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                            
                        }
                        else //caso de slot ocupado
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID) //acceder al ID y si es igual
                            {
                                resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad; //suma las cantidadesd e un mismo item, (2 pociones + 2 pociones)
                                Destroy(objetoSeleccionado.gameObject);
                            }
                            else //si el ID es distinto
                            {
                                objetoSeleccionado.transform.SetParent(exParent.transform);
                                objetoSeleccionado.transform.localPosition = Vector2.zero;
                            }
                        }
                    }
                    else
                    {
                        objetoSeleccionado.transform.SetParent(exParent.transform);
                        objetoSeleccionado.transform.localPosition = Vector2.zero;
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

        return (new Vector2(viewportPoint.x * canvasSize.x, viewportPoint.y * canvasSize.y) - (canvasSize / 2)); //multiplica la cantidad de pixeles para dividirla y tener un punto intermedio
    }
}
