using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


/*
 */
public class sc_item : ScriptableObject //ScriptableObjects exist outside of the game world. MonoBehaviours must be attached to GameObjects
{

    public string itemName;
    public Sprite icon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Kommentarbereich: warum das Schlüsselwort virtual?
    /*
     * Jedes Item wird die Funktion anders verwenden, Beispielsweise, wird ein "Trank" den Spieler "heilen", aber eine Waffe muss zu einem Spieler zugewiesen werden. 
     * Also benutzt der Spieler jedes item anders, deswegen muss jedes Item diese Methode überschreiben können.  
     * Ein Item Object wird die Methode Use() haben, und genau definieren müssen was die Methode (auf ihn bezogen) macht.
     */
    #endregion
    public virtual void Use() //the keyword virtual this allows each Item type to overwrite this function.
    {

    }

}
