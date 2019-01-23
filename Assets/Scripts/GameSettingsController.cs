using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsController : MonoBehaviour
{
    public bool singlePlayer;
    public bool externalController;
    public GameObject player;
    public GameObject target;
    public GameObject bullit;
    public GameObject background;
    public GameObject enemy;
    public GameObject rocket;
    public GameObject lightning;
    public GameObject lightningBolt;

    private movement movement;
    private Gun gun;
    private TargetController targetController;
    private GameOverController gameOverController;
    private Bullit bullitController;
    private RocketController rocketController;
    private LightningController lightningController;
    private BoltController boltController;

    void Start()
    {
        singlePlayer = GameSettingsStaticController.SinglePlayer;
        externalController = GameSettingsStaticController.ExternalController;
        //movement = player.GetComponent<movement>();
        //gun = player.GetComponent<Gun>();
        //targetController = target.GetComponent<TargetController>();
        //gameOverController = background.GetComponent<GameOverController>();
        //bullitController = bullit.GetComponent<Bullit>();
        //rocketController = rocket.GetComponent<RocketController>();
        //lightningController = lightning.GetComponent<LightningController>();
        //boltController = lightningBolt.GetComponent<BoltController>();


        //movement.externalController = externalController;
        //gun.externalController = externalController;
        //targetController.externalController = externalController;
        //targetController.singlePlayer = singlePlayer;
        //gameOverController.singlePlayer = singlePlayer;
        //bullitController.singlePlayer = singlePlayer;
        //rocketController.singlePlayer = singlePlayer;
        //boltController.singlePlayer = singlePlayer;
        //lightningController.singlePlayer = singlePlayer;
        ////player2.SetActive(!singlePlayer);
        //enemy.SetActive(singlePlayer);
       
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Target");

        if (player)
        {
            movement = player.GetComponent<movement>();
            gun = player.GetComponent<Gun>();
            targetController = target.GetComponent<TargetController>();
            gameOverController = background.GetComponent<GameOverController>();
            bullitController = bullit.GetComponent<Bullit>();
            rocketController = rocket.GetComponent<RocketController>();
            lightningController = lightning.GetComponent<LightningController>();
            boltController = lightningBolt.GetComponent<BoltController>();

            //print(movement);
            if (movement)
            {
                movement.externalController = externalController;
            }
            if (gun)
            {
                gun.externalController = externalController;
            }
            targetController.externalController = externalController;
            targetController.singlePlayer = singlePlayer;
            gameOverController.singlePlayer = singlePlayer;
            bullitController.singlePlayer = singlePlayer;
            rocketController.singlePlayer = singlePlayer;
            boltController.singlePlayer = singlePlayer;
            lightningController.singlePlayer = singlePlayer;
            //player2.SetActive(!singlePlayer);
            if (singlePlayer) 
            { 
                enemy.SetActive(singlePlayer);
            }

        }
    }

}
