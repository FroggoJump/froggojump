using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FrogController))]
public class FreePath : MonoBehaviour
{

    [SerializeField] Material lineMaterial;
    [SerializeField] Material point;
    public Transform point1;
    Vector3 point2;
    Vector3 point3;
    Color invisible;
    public static Vector3 highestPoint;
    public static Vector3 endPosition;
    static LineRenderer lineRenderer;
    [SerializeField] GameObject end;
    [SerializeField] GameObject waterLilyRadar;
    List<Vector3> pointList;

    //[SerializeField] Color correct;
    //[SerializeField] Color incorrect;
    [SerializeField] Color dot;
    static List<GameObject> dots;
    public int vertexCount = 12;
    public static bool active;
    private void Awake()
    {
        pointList = new List<Vector3>();

        dots = new List<GameObject>();
        lineRenderer = GetComponent<LineRenderer>();
        for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
        {
            dots.Add(Instantiate(end));
        }
        waterLilyRadar = Instantiate(waterLilyRadar);

    }

    private void Start()
    {
        lineRenderer.widthMultiplier = 0;
        invisible = new Color(0, 0, 0, 0);
    }

    void Update()
    {
        if (active)
        {
            lineRenderer.widthMultiplier = 1;

            point2 = Vector3.Lerp(point1.position, highestPoint, 1);
            point3 = Vector3.Lerp(point1.position, endPosition, 1);
            pointList.Clear();
            int count = 0;
            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(point1.position, point2, ratio); //Puntos entre la rana y el punto más alto
                var tangentLineVertex2 = Vector3.Lerp(point2, point3, ratio);//Puntos entre el puntos más alto  y el suelo
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio); // interpolacion entre ambas lineas
                pointList.Add(bezierpoint);
                if (count <= dots.Count - 3)
                {
                    dots[count].transform.position = bezierpoint;

                }
                count++;
            }
            lineRenderer.positionCount = pointList.Count;
            lineRenderer.SetPositions(pointList.ToArray());

            waterLilyRadar.transform.position = new Vector3(lineRenderer.GetPosition(lineRenderer.positionCount - 1).x, lineRenderer.GetPosition(lineRenderer.positionCount - 1).y, lineRenderer.GetPosition(lineRenderer.positionCount - 1).z);
        }
        else
        {
            //waterLilyRadar.transform.position = Vector3.zero;
            point.color = invisible;
            Clear();
        }


        //var c1 = Color.Lerp(incorrect, correct, 1);
        //var c2 = Color.Lerp(correct, incorrect, 1);
        //lineMaterial.color = Color.Lerp(c1, c2, 1);






    }
    public static void Clear()
    {
        lineRenderer.widthMultiplier = 0;


    }



}
