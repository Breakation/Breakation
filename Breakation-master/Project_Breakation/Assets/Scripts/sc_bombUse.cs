using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class sc_bombUse : MonoBehaviourPun, IPunObservable
{
    public GameObject mixerObj;
    public GameObject steinObj;

    private void OnMouseDown()
    {
        bombStone();
    }

    public void bombStone()
    {
        steinObj.SetActive(false);
        Destroy(this.gameObject);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
