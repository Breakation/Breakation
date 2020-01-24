using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class CellController : MonoBehaviour {


    private LightsOutManager GMInstance; // verwaltet den Rätsel
    public List<CellController> adjacentCells;
    public Animator animator;

    private void Start()
    {
        GMInstance = LightsOutManager.Instance;
        animator = GetComponent<Animator>();

    }

    // status der Zelle 
    public enum Status {
        open,
        closed
    }

    public Status cellStatus;

    // x und y coordinate der Zelle in der 2-dimensionalen Array (samt getters und setters)
    public int xCoord { get; set; }
    public int yCoord { get; set; }
    public int cellNum;


    void OnMouseDown()
    {
        Debug.Log("cell number: " + cellNum);
        this.AffectCells();
    }
    public void AffectCells() { // diese werden beim Clicken immer aufgerufen

        Debug.Log("hello ich bin AffectCells");
        SwitchCellState(); // Zustand der Zelle selbst wird geändert
        SwitchAdjacentCellState(); //Zustände der umliegenden Zellen
        GMInstance.numberOfClicks++; // Anzahl clicks wird erhöht
        GMInstance.CheckForWin(); // gecheckt ob alle cells off sind = Gewinn!
    }

    public void SwitchCellState() {

        if (cellStatus == CellController.Status.open) {
            cellStatus = CellController.Status.closed;
            this.closeCap();
        } else {
            cellStatus = CellController.Status.open;
            this.openCap();
        }

       

    }

    public void switchC(int k)
    {
        for (int i = 0; i <= 63; i++)
        {
            for (int j = 0; j <= 63; j++)
            {
                if (GMInstance.ArrayOfCells[i, j].cellNum == k)
                {
                    if (GMInstance.ArrayOfCells[i, j].cellStatus == CellController.Status.open)
                    {
                        GMInstance.ArrayOfCells[i, j].cellStatus = CellController.Status.closed;
                        GMInstance.ArrayOfCells[i, j].closeCap();
                    }
                    else
                    {
                        GMInstance.ArrayOfCells[i, j].cellStatus = CellController.Status.open;
                        GMInstance.ArrayOfCells[i, j].openCap();
                    }
                }
            }
        }
    }

    internal void openCap()
    {

        Debug.Log("cap is open from controller!");
        animator.SetInteger("state", 1);
    }

    internal void closeCap()
    {
        Debug.Log("cap is closed from controller!");
        animator.SetInteger("state", -1);
    }

    public void SwitchAdjacentCellState() {
        //StartCoroutine(ISwitchAdjacentCellState());
        this.ISwitchAdjacentCellState();
    }

	/*IEnumerator */ void ISwitchAdjacentCellState() {
		
		GetAdjacentCells ();

		//yield return new WaitForEndOfFrame ();

		foreach (var item in adjacentCells) {

           /* var selectedCell =  item.GetComponent<CellController> ();

			if (selectedCell.cellStatus == Status.open) {
				selectedCell.cellStatus = Status.closed;
                item.GetComponent<CellController>().closeCap();
            } else {
				selectedCell.cellStatus = CellController.Status.open;
                item.GetComponent<CellController>().openCap();
            }*/

            var selectedCell = item;

            if (item.cellStatus == Status.open)
            {
                item.cellStatus = Status.closed;
                item.closeCap();
            }
            else
            {
                item.cellStatus = CellController.Status.open;
                item.openCap();
            }
        }
	}

	void GetAdjacentCells(){
		adjacentCells = new List<CellController> ();

        CellController northCell = null, westCell = null, eastCell = null, southCell = null;

		if (xCoord - 1 >= 0) {
			northCell = GMInstance.ArrayOfCells [xCoord - 1, yCoord];
			adjacentCells.Add(northCell);
		}

		if (yCoord - 1 >= 0) {
            Debug.Log("cellNumber of this clicked box: "+ GMInstance.ArrayOfCells[xCoord, yCoord - 1].cellNum);
			westCell = GMInstance.ArrayOfCells[xCoord, yCoord - 1];
			adjacentCells.Add(westCell);
		
		}

		if (yCoord + 1 <= GMInstance.GridSize-1) {
			eastCell = GMInstance.ArrayOfCells [xCoord, yCoord + 1];
			adjacentCells.Add(eastCell);
		}
		if (xCoord + 1 <= GMInstance.GridSize - 1) {
			southCell = GMInstance.ArrayOfCells [xCoord + 1, yCoord];
			adjacentCells.Add(southCell);
		
		}
	}

    
}

 

