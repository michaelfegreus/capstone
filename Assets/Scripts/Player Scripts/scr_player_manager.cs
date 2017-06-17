using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_MANAGER : MonoBehaviour {

	// Get the other player components.
	scr_player_movement_rigidbody movementScript;
	scr_player_interaction interactionScript;
	scr_player_inventory inventoryScript;

	/*public bool inItemMenu;
	public bool onGround;
	public bool inDialogue;
	public bool inAnimation;*/
	public bool changeState;

	public State currentState;

	void Start(){
		movementScript = GetComponent<scr_player_movement_rigidbody> ();
		interactionScript = GetComponent<scr_player_interaction> ();
		inventoryScript = GetComponent<scr_player_inventory> ();

		changeState = true;
		//currentPlayerState = State.free;

		currentState = State.free;
	}

	void Update(){
		/*
		if (inventoryScript.inItemMenu == true) {
			if (currentState != State.inMenu) {
				StateChange (State.inMenu);
			}
		} else if (inventoryScript == false && ) {

		}
*/
		/*

		}*/
		
		// If it detects a change in state...
		if (inventoryScript.inItemMenu == true && currentState != State.inMenu) {
			StateChange (State.inMenu);
		}
		if(movementScript.onGround != true && currentState != State.inAir){
			//changeState = false;
		StateChange (State.inAir);
		}
		if (interactionScript.inDialogue == true && currentState != State.inDialogue) {
			//changeState = false;
			currentState = State.inDialogue;
			StateChange (State.inDialogue);
		}
		if (interactionScript.inDialogue == false && inventoryScript.inItemMenu == false && movementScript.onGround == true && currentState != State.free) {
			StateChange (State.free);
		}
		/*
		// State change settings.
		if (!free) {
			if (!onGround) {
				interactionScript.DeactivateExclamationUI();
				interactionScript.enabled = false;
				inventoryScript.enabled = false;
				//currentPlayerState = State.inAir;
			} else if (inItemMenu) {
				movementScript.ResetMovementValues ();
				movementScript.enabled = false;
				interactionScript.enabled = false;
				//currentPlayerState = State.inMenu;
			} else if (inDialogue) {
				movementScript.ResetMovementValues ();
				movementScript.enabled = false;
				interactionScript.enabled = false;
				inventoryScript.enabled = false;
				//currentPlayerState = State.inDialogue;
			} else {
				free = true;
				movementScript.enabled = true;
				interactionScript.enabled = true;
				inventoryScript.enabled = true;
				//currentPlayerState = State.free;
			}
		}*/
	}

	public void StateChange(State newState){

		currentState = newState;

		switch (currentState) {

		case State.free:
			Debug.Log ("Current player state: Free");
			movementScript.enabled = true;
			interactionScript.enabled = true;
			inventoryScript.enabled = true;
			break;

		case State.inAir:
			Debug.Log ("Current player state: Free");
			interactionScript.DeactivateExclamationUI();
			interactionScript.enabled = false;
			inventoryScript.enabled = false;
			break;

		case State.inMenu:
			Debug.Log ("Current player state: In Menu");
			movementScript.ResetMovementValues ();
			movementScript.enabled = false;
			interactionScript.enabled = false;
			break;

		case State.inDialogue:
			Debug.Log ("Current player state: In Dialogue");
			movementScript.ResetMovementValues ();
			movementScript.enabled = false;
			interactionScript.enabled = false;
			inventoryScript.enabled = false;
			break;

		}
	}

	public enum State{

		free, inAnimation, inMenu, inDialogue, inAir

	}
}

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    [Header("Health")]
    private float hitpoints;
    public float maxHitPoints;

    private bool attacking;
    private Hand currentHand;

    private int anticipation;
    private int anticipationCounter;

    [Header("Attack - Punch")]
    public float punchSpeed;
    public int punchAnticipation;
    public float punchRetractSpeed;

    [Header("Attack - Sweep")]
    public float sweepRotationSpeed;
    public float sweepExtendSpeed;
    public int sweepAnticipation;

    [Header("Death")]
    public bool dead = false;
    public float deathFallRate;
    public float deathShakeIntensity;

    [Header("Movement")]
    public float rotationSpeed;
    private bool facingPlayer = false;
    private Vector3 playerPosition;
    private Vector3 lostPosition = new Vector3(999,999,999);
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private bool searching = false;

    [Header("Instances")]
    public Hand rightHand;
    public Hand leftHand;
    public Healthbar healthbar;
    public Player player;

    private State currentState;

    private delegate void StateMachine();
    private StateMachine stateMachine;

    public TextMesh monsterState;

    // Use this for initialization
    void Start () {

        hitpoints = maxHitPoints;
        playerPosition = lostPosition;

        currentState = State.search;
    }
    
    // Update is called once per frame
    void Update () {

        //if(playerPosition != lostPosition){ currentState = State.turnToPlayer; }

        switch(currentState){

            case State.search: stateMachine = Search; monsterState.text = "Searching"; break;
            case State.turnAndPunch: break;
            //case State.punching: stateMachine = Punch; monsterState.text = "Punching!"; break;
            case State.death: stateMachine = Death; monsterState.text = "Dying"; break;
        }

        if(stateMachine != null){ stateMachine(); }

        //if(attacking == false){ stateMachine = Search; }

        if(hitpoints <= 0){ currentState = State.death; dead = true; } 
        //Debug.Log("Monster HP: " + hitpoints);

        if(Input.GetKeyDown(KeyCode.V)){ Damage(maxHitPoints/2); }
    }

    public void Damage(float amount){ 

        playerPosition = player.gameObject.transform.position;

        /*
        if(!attacking){

            attacking = true;

            targetPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z) - transform.position;
            if(Quaternion.Angle(transform.rotation,targetRotation) < 3f){ facingPlayer = true; }

            if(hitpoints > maxHitPoints/2 || facingPlayer == true){ stateMachine = Punch; }
            else{ stateMachine = Sweep; anticipation = sweepAnticipation; }
        }


healthbar.Shorten(amount,hitpoints);
hitpoints -= amount;

if(hitpoints > maxHitPoints/2){ currentState = State.turnAndPunch; stateMachine = TurnAndPunch; }
else{ currentState = State.sweep; } 
}

private void Sweep(){

	if(anticipationCounter > anticipation){

		rightHand.StartSweep();
		currentHand = rightHand;
		stateMachine = SweepToPlayer;
		anticipationCounter = 0;
	}
	else{ anticipationCounter++; }
}

private void Punch(){

	monsterState.text = "Punching!";

	float hand = Random.Range(0,1f);

	if(hand < 0.5f){ rightHand.StartPunch(playerPosition); }
	else{ leftHand.StartPunch(playerPosition); }

	playerPosition = lostPosition;
	facingPlayer = false;

	stateMachine = Wait;
}

private void Wait(){

	monsterState.text = "Waiting";

	if(rightHand.ready && leftHand.ready){ currentState = State.search; }
}

private void Search(){

	if(!searching){

		targetRotation = Quaternion.Euler(new Vector3(0,Random.Range(0,355),0));

		searching = true;
	}

	if(Quaternion.Angle(transform.rotation,targetRotation) > 5){

		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}
	else{ searching = false; }
}

private void SweepToPlayer(){

	if(playerPosition != lostPosition){

		targetPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z) - transform.position;
		targetRotation = Quaternion.LookRotation(-targetPosition,Vector3.up);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, sweepRotationSpeed * Time.deltaTime);

		if(Quaternion.Angle(transform.rotation,targetRotation) < 3f){ facingPlayer = true; currentHand.StopSweep(); stateMachine = Wait; }
	}
}

private void TurnAndPunch(){

	monsterState.text = "Turning to Punch";

	if(playerPosition != lostPosition){

		targetPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z) - transform.position;
		targetRotation = Quaternion.LookRotation(-targetPosition,Vector3.up);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

		if(Quaternion.Angle(transform.rotation,targetRotation) < 3f){ facingPlayer = true; stateMachine = Punch; }
	}
}

private void Death(){

	if(transform.position.y > -100){

		Vector3 shakePosition = new Vector3(transform.position.x + Random.Range(-deathShakeIntensity,deathShakeIntensity),
			transform.position.y + Random.Range(-deathShakeIntensity, deathShakeIntensity) + -deathFallRate,
			transform.position.z);

		transform.position = shakePosition;
	}
}

private enum State{

	search, wait, punching, death, turn, turnAndPunch, sweep
}
*/