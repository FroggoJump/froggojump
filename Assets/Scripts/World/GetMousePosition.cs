using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
     public Vector2 mouse;
    public enum State
    {
        right, left,middle
    }

    public State state; 
        void Start()
    {
        mouse = new Vector2(Input.mousePosition.x,Input.mousePosition.y);


    }

    // Update is called once per frame
    void Update()
    {
        mouse = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        //Debug.Log("MouseX: " + mouse.x + " ScrenWidth: " + Screen.width + " ScrenWidth/2: " + Screen.width / 2 + " Screen.width * 0.1f: " + Screen.width * 0.1f);

      
            if (mouse.x < ((Screen.width / 2) - ((Screen.width / 2) * 0.1)))
            {
                state = State.left;

            }
            else if (mouse.x > ((Screen.width / 2) + ((Screen.width / 2) * 0.1)))
            {
                state = State.right;
            }
            else
            {
                state = State.middle;
            }
        
       
    }
    public float ScreenSize()
    {
        if(state == State.right)
        {

            return (float)((Screen.width / 2) - (Screen.width/2 * 0.1));
        }
        if (state == State.left)
        {

            return (float)((Screen.width / 2) - (Screen.width / 2 * 0.1));

        }
        else {
            return (float)(Screen.height/3);
        }
    }
}
