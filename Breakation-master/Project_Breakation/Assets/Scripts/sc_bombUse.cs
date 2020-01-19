using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class sc_bombUse : MonoBehaviourPun, IPunObservable
{
    public GameObject mixerObj;
    public GameObject steinObj;
    public bool bomb = false;

    [SerializeField] public AudioSource ExplosionSoundff;

    private void OnMouseDown()
    {
        if (DispOpener.PlayerInRange)
        {
            ExplosionSoundff.Play();
            bomb = true;
            bombStone();
        }
    }

    void Update()
    {
        if (bomb)
        {
            bombStone();
        }
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
