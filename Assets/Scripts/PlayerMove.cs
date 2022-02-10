using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{


	// Use this for initialization
	void Start ()
	{
        Init();
	}

	// Update is called once per frame
	void Update ()
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }
				if (turn)
				{
					WaitForSelection();
				}
        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
     }

		 void WaitForSelection()
     {
         if (Input.GetMouseButtonUp(0))
         {
             Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

             RaycastHit hit2;
             if (Physics.Raycast(ray2, out hit2))
             {
                 if (hit2.collider.tag == "Player")
                 {
                     TacticsMove p = hit2.collider.GetComponent<PlayerMove>();
							p.turn = true;
                 }
             }
         }
      }
}
