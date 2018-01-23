using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeControl : MonoBehaviour
{
    // Display text for Checking Changes  
    public Text DisplayText;

    //First/Last finger position  
    Vector3 fp, lp;

    //Distance needed for a swipe to take some Action  
    public float DragDistance;

    void Update()
    {
        //Check the touch inputs  
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                //First check if it’s actually a drag  
                if (Mathf.Abs(lp.x - fp.x) > DragDistance || Mathf.Abs(lp.y - fp.y) > DragDistance)
                { //It’s a drag  
                  //Now check what direction the drag was  
                  //First check which axis  
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        //If the horizontal movement is greater than the vertical movement…  
                        if (lp.x > fp.x)
                        { //Right move  
                            DisplayText.text = "Right move";
                            transform.Translate(1, 0, 0);
                        }
                        else
                        { //Left move  
                            DisplayText.text = "Left move";
                            transform.Translate(-1, 0, 0);
                        }
                    }
                    else
                    {
                        //the vertical movement is greater than the horizontal movement  
                        if (lp.y > fp.y)
                        {
                            //Up move  
                            DisplayText.text = "Move Up";
                            transform.Translate(0, 1, 0);
                        }
                        else
                        {
                            //Down move  
                            DisplayText.text = "Move Down";
                            transform.Translate(0, -1, 0);
                        }
                    }
                }
                else
                {
                    //It’s a tap  
                    DisplayText.text = "Tapping";
                }
            }
        }
    }
}