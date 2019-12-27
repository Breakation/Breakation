using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CellController : MonoBehaviour {


	public GameObject cell; // soll durch "public Cell cell;" ersetzt werden nach dem die echten Zellen fertig implementiert wurden (mit Tür öffnen und modell)
    private LightsOutManager GMInstance = LightsOutManager.Instance; // verwaltet den Rätsel

    // status der Zelle 
    public enum Status {
		Lit,
		Out
	}
	public Status cellStatus;

    // x und y coordinate der Zelle in der 2-dimensionalen Array (samt getters und setters)
	public int xCoord {	get; set; }
	public int yCoord {	get; set; }

	public List<GameObject> adjacentCells;

	public void OnClick() { // diese werden beim Clicken immer aufgerufen
		SwitchCellColor (); // Zustand der Zelle selbst wird geändert
		SwitchAdjacentCellColor (); //Zustände der umliegenden Zellen
        GMInstance.numberOfClicks++; // Anzahl clicks wird erhöht
        GMInstance.CheckForWin(); // gecheckt ob alle cells off sind = Gewinn!
	}

	public void SwitchCellColor () {
		if (cellStatus == CellController.Status.Lit) {
			cellStatus = CellController.Status.Out;
			this.gameObject.GetComponent<CanvasRenderer>().SetColor(GMInstance.offColour);
		} else {
			cellStatus = CellController.Status.Lit;
			this.gameObject.GetComponent<CanvasRenderer>().SetColor(GMInstance.onColour);
		}
	}

	public void SwitchAdjacentCellColor() {
		StartCoroutine("ISwitchAdjacentCellColor");
	}

	IEnumerator ISwitchAdjacentCellColor() {
		
		GetAdjacentCells ();

		yield return new WaitForEndOfFrame ();
		foreach (var item in adjacentCells) {
			var selectedCell = item.GetComponent<CellController> ();

			if (selectedCell.cellStatus == Status.Lit) {
				selectedCell.cellStatus = Status.Out;
				item.gameObject.GetComponent<CanvasRenderer> ().SetColor (GMInstance.offColour);
			} else {
				selectedCell.cellStatus = CellController.Status.Lit;
				item.gameObject.GetComponent<CanvasRenderer> ().SetColor (GMInstance.onColour);
			}
		}
	}

	void GetAdjacentCells(){
		adjacentCells = new List<GameObject> ();

		GameObject northCell = null, westCell = null, eastCell = null, southCell = null;

		if (xCoord - 1 >= 0) {
			northCell = GMInstance.ArrayOfCells [xCoord - 1, yCoord];
			adjacentCells.Add(northCell);
		}

		if (yCoord - 1 >= 0) {
			westCell = GMInstance.ArrayOfCells[xCoord, yCoord - 1];
			adjacentCells.Add(westCell);
		
		}

		if (yCoord + 1 <= GMInstance.grid.m_Column-1) {
			eastCell = GMInstance.ArrayOfCells [xCoord, yCoord + 1];
			adjacentCells.Add(eastCell);
		}
		if (xCoord + 1 <= GMInstance.grid.m_Column-1) {
			southCell = GMInstance.ArrayOfCells [xCoord + 1, yCoord];
			adjacentCells.Add(southCell);
		
		}
	}
}