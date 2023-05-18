using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CharacterController2D player1;
    public CharacterController2D player2;
    public Launcher player1Launcher;
    public Launcher player2Launcher;
    public GameObject mountPoint1;
    public GameObject mountPoint2;

    // Start is called before the first frame update
    void Start()
    {
        mountPoint1.transform.SetParent(player1.transform);
        //player1Launcher = Instantiate(player1Launcher, mountPoint1.transform.position, mountPoint1.transform.rotation);
        player1Launcher.transform.SetParent(mountPoint1.transform);
        mountPoint2.transform.SetParent(player2.transform);
        //player2Launcher = Instantiate(player2Launcher, mountPoint2.transform.position, mountPoint2.transform.rotation);
        player2Launcher.transform.SetParent(mountPoint2.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}