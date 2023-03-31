using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;




public enum E_BattlePhases { StartPhasePlayer, StartPhaseEnemy
}
public class TurnEnum : MonoBehaviour
{
//  public E_BattlePhases StateOfBattle;
    public  E_BattlePhases StateOfBattle;
    public GameObject GOPlayer;
    public GameObject GOEnemy;
    
    public Text TurnText;
    public int CurrentTurn;
    public static bool StartTurn;

    public Transform  PlayerBattleStation;
    public Transform EnemyBattleStation;

    PlayerScript PlayerReference;
    EnemyScript EnemyReference;

    public Text HealthTextPlayer;
    public Text HealthTextEnemy;
    public Text PhaseText;

    public bool IsPlayerTurn;

    public GameObject  btnPlayer;
    public GameObject  btnEnemy;
    // Start is called before the first frame update

    private void Awake()
    {
        CurrentTurn = 1;
        IsPlayerTurn = true;
        TurnText.text = CurrentTurn.ToString();
        StartTurn = false;
        StartCoroutine(StartBattle());
    }
    void Start()
    {
        //StateOfBattle = E_BattlePhases.StartPhase0 ;
      
    }

  

    // Update is called once per frame
    void Update()
    {
        PhaseText.text = StateOfBattle.ToString();
        if (IsPlayerTurn ==true /*&& StateOfBattle ==E_BattlePhases.EndPhasePlayer*/ )
        {
            btnPlayer.SetActive(true);
           
            btnEnemy.SetActive(false);


            TurnText.text = CurrentTurn.ToString();
            StateOfBattle = E_BattlePhases.StartPhasePlayer ;
            PhaseText.text = StateOfBattle.ToString ();
        }
        else
        {
            btnEnemy.SetActive(true);
            btnPlayer.SetActive(false);

            TurnText.text = CurrentTurn.ToString();
            StateOfBattle = E_BattlePhases.StartPhasePlayer;
            PhaseText.text = StateOfBattle.ToString();
        }
    }

    IEnumerator  StartBattle()
    {
       GameObject PlayerGO = Instantiate(GOPlayer, PlayerBattleStation);
     PlayerReference  =  PlayerGO.GetComponent<PlayerScript>();
        HealthTextPlayer.text = PlayerReference.CurrentHP.ToString();// iniciazace krev hrace

       GameObject EnemyGO = Instantiate(GOEnemy, EnemyBattleStation);
        EnemyReference = EnemyGO.GetComponent<EnemyScript>();
        HealthTextEnemy.text = EnemyReference.CurrentHP.ToString();

       // PhaseText.text = StateOfBattle.ToString ();
        IsPlayerTurn = true;
        CurrentTurn = 1;
        yield return new WaitForSeconds(3f);
        StateOfBattle = E_BattlePhases.StartPhasePlayer;
        StartPhase();
    }

    private void StartPhase()
    {
        PhaseText.text = StateOfBattle.ToString();
        //draw function
        //summon function
        //effect function
        // a trigger that can go to end phase
    }

    public void EndPlayerTurn() {
        IsPlayerTurn = false;
        CurrentTurn += 1;

    }

    public void EndEnemyTurn()
    {
        IsPlayerTurn = true;
        CurrentTurn += 1;
        StartTurn = true;
    }
}
