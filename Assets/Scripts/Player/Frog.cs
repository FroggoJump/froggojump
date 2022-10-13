using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Frog : MonoBehaviour
{
    [SerializeField] GameObject frog;
    float xMax;
    public static float objectOfsset;
    public static Vector3  nextPos;
    public static int currentShield = 0, maxShield = 3;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("savedRings") != 0)
        {
            StartCoroutine(UpdateRing());
        }
           
        
       
    }
    public void changeRotation(float angle)
    {
        transform.eulerAngles = new Vector3(this.transform.rotation.x, angle, this.transform.rotation.z);
    }

    public Vector3 GetHighestPoint(float v0)
    {
        Vector3 pos = GetEndPoint(v0);
        //float distance = AutomaticJump.CalcDistance(this.gameObject, pos);
        Vector3 point = Lerp(this.gameObject.transform.position, pos, 0.5f);
        float y = (transform.position.y + (-Physics.gravity.y * Mathf.Pow(AutomaticJump.GetTime(v0), 2)) / 4);

        return new Vector3(point.x, y, point.z);
    }

    public  Vector3 GetEndPoint(float v0)
    {
        xMax = (-v0 * AutomaticJump.GetTime(v0))/2;
        nextPos = (new Vector3((transform.right.x * xMax-0.2f )+ frog.transform.position.x, transform.right.y+ (objectOfsset/50)+0.65f, (transform.right.z * xMax-0.2f )+ frog.transform.position.z) ) ;

        return nextPos;
    }
    Vector3 Lerp(Vector3 start, Vector3 end, float percent) //usado por el metodo anterior
    {
        return (start + percent * (end - start));
    }
    IEnumerator UpdateRing()
    {
        yield return new WaitForEndOfFrame();
        currentShield = PlayerPrefs.GetInt("savedRings");
        PickUpManager.UpdateSalvavidas();
    }
}
