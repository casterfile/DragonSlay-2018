using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int isRight = -1;
	public GameObject DragonLeft, DragonRight;
	public Animator  DragonLeftAnim,DragonRightAnim;
	public Text TimerText;
	public GameObject Life1,Life2,Life3;
	public AudioSource ASLDragon, ASRDragon;
	public AudioClip DragonCry,DragonRoar,SwordSwing;
	private bool isLDragonOff = false,isRDragonOff = false;
	public GameObject POPUPList, POPUP1,POPUP2,POPUP3,POPUP4,POPUP5;
	

	private Animator animController;
	private bool isRDragonEnable = false, isLDragonEnable = false;
	private bool isReset = false;
	private float timeLeft = 30.0f;
	private int dragonAttackOn = 0;
	private bool isNotAttack = false;
	private int LifeCounter = 3;
	private int countKills = 0;
	public static bool GamePuase = false;
	private bool isDragonRVisible, isDragonLVisible;
	// Use this for initialization
	void Start () {

		isReset= false;
		isDragonRVisible = false;
		isDragonLVisible = false;
		GamePuase = false;
		POPUPList.SetActive(false);
		POPUP1.SetActive(false);
		POPUP2.SetActive(false);
		POPUP3.SetActive(false);
		POPUP4.SetActive(false);
		POPUP5.SetActive(false);

		
		timeLeft = 30.0f;
		isNotAttack = false;
		LifeCounter = 3;
		countKills = 0;

		
		

		dragonAttackOn = Mathf.RoundToInt(timeLeft) - 2;

		Life1.SetActive(true);
		Life2.SetActive(true);
		Life3.SetActive(true);
	}

	private void ResetAllAfterKill(){
		CancelInvoke();

		isRight = -1;
		isLDragonOff = false;
		isRDragonOff = false;
		isRDragonEnable = false;
		isLDragonEnable = false;

		DragonRight.SetActive(false);
		DragonLeft.SetActive(false);
		int ramdom1 = Random.Range(1, 10);
		int ramdom2 = Random.Range(1, 10);
		if(ramdom1 >= ramdom2){
			Invoke("RStartAttack", 0);
			Invoke("LStartAttack", 5);
		}else{
			Invoke("RStartAttack", 5);
			Invoke("LStartAttack", 0);
		}
	}

	private void FuncDragonCry(AudioSource ASDragonLocal){
		ASDragonLocal.PlayOneShot(DragonCry, 0.7F);
	}

	private void FuncDragonRoar(AudioSource ASDragonLocal){
		ASDragonLocal.PlayOneShot(DragonRoar, 0.7F);
	}

	private void FuncDragonSwordSwing(AudioSource ASDragonLocal){
		ASDragonLocal.PlayOneShot(SwordSwing, 0.7F);
	}


	// Update is called once per frame
	void Update () {
		if(GamePuase == false){
			if(countKills >= 5){
				DragonRight.SetActive(false);
				DragonLeft.SetActive(false);
				ChangeScene();
			}else{
				if(isReset == false){
					isReset = true;
					ResetAllAfterKill();
				}

				POPUPList.SetActive(false);
				if(countKills >= 5){
					ChangeScene();
				}
			}
			

			FuncLifeController();
			timeLeft -= Time.deltaTime;
			int castTimeLeft = Mathf.RoundToInt(timeLeft);
			if(isRight == 1){
				if(isRDragonEnable == false && isRDragonOff == false && GamePuase == false){
					DragonRightAnim.SetInteger("Dragon_Right_HIT", 2);
					isRDragonOff = true;
					FuncDragonCry(ASRDragon);
					FuncDragonSwordSwing(ASRDragon);
					Invoke("DragonRightHide",1);
					isRight = -1;
				}
			}
			else if(isRight == 0){
				if(isLDragonEnable == false && isLDragonOff == false && GamePuase == false){
					DragonLeftAnim.SetInteger("Dragon_Right_HIT", 2);
					isLDragonOff = true;
					FuncDragonCry(ASLDragon);
					FuncDragonSwordSwing(ASLDragon);
					Invoke("DragonLeftHide",1 );
					isRight = -1;
				}
			}

	         if(timeLeft < 0)
	         {
	             Application.LoadLevel("Scene_Game_01");
	         }else{
	         	if(castTimeLeft < 10){
	         		TimerText.text = "00:0"+castTimeLeft;
	         	}else{
	         		TimerText.text = "00:"+castTimeLeft;
	         	}
	         }
		}else{
			isReset = false;
			isRight = -1;
			CancelInvoke();
			DragonRight.SetActive(false);
			DragonLeft.SetActive(false);
			FuncShowPOPUP();
		}
		
	}


	void DragonRightShow(){
		if(GamePuase == false){
			DragonRight.SetActive(true);
			isRDragonOff = false;
			isDragonRVisible = true;
		}else{
			Invoke("DragonRightShow", 1);
			DragonRight.SetActive(false);
			DragonLeft.SetActive(false);
		}
	}
	void DragonLeftShow(){
		if(GamePuase == false){
			DragonLeft.SetActive(true);
			isLDragonOff = false;
			isDragonRVisible = true;
		}else{
			Invoke("DragonLeftShow", 1);
			DragonRight.SetActive(false);
			DragonLeft.SetActive(false);
		}
	}

	void DragonLeftHide(){
		DragonLeft.SetActive(false);
		EndIfKillEnemy();
		Invoke("DragonLeftShow", 8);
		isDragonLVisible = false;
	}
	void DragonRightHide(){
		DragonRight.SetActive(false);
		EndIfKillEnemy();
		Invoke("DragonRightShow", 8);
		isDragonRVisible = false;
	}

	public void FuncShowPOPUP(){
		if(countKills == 1){
			POPUPList.SetActive(true);
			POPUP1.SetActive(true);
			POPUP2.SetActive(false);
			POPUP3.SetActive(false);
			POPUP4.SetActive(false);
			POPUP5.SetActive(false);
		}
		else if(countKills == 2){
			POPUPList.SetActive(true);
			POPUP1.SetActive(false);
			POPUP2.SetActive(true);
			POPUP3.SetActive(false);
			POPUP4.SetActive(false);
			POPUP5.SetActive(false);
		}
		else if(countKills == 3){
			POPUPList.SetActive(true);
			POPUP1.SetActive(false);
			POPUP2.SetActive(false);
			POPUP3.SetActive(true);
			POPUP4.SetActive(false);
			POPUP5.SetActive(false);
		}
		else if(countKills == 4){
			POPUPList.SetActive(true);
			POPUP1.SetActive(false);
			POPUP2.SetActive(false);
			POPUP3.SetActive(false);
			POPUP4.SetActive(true);
			POPUP5.SetActive(false);
		}
		else if(countKills == 5){
			POPUPList.SetActive(true);
			POPUP1.SetActive(false);
			POPUP2.SetActive(false);
			POPUP3.SetActive(false);
			POPUP4.SetActive(false);
			POPUP5.SetActive(true);
		}

		
	}

	public void EndIfKillEnemy(){
		if(countKills >= 5){
			DragonRight.SetActive(false);
			DragonLeft.SetActive(false);
			ChangeScene();
		}else{
	 		//StartCoroutine(FuncGamePuase(5.0f));
	 		GamePuase = true;
			countKills = countKills + 1;
		}
	}

	public void ChangeScene(){
		Application.LoadLevel("Scene_Game_04");
	}

	public void FuncLifeController(){
		// print("Hello FuncLifeController");
		if(LifeCounter <= 0){
			Application.LoadLevel("Scene_Game_01_01");
		}
		else if(LifeCounter == 2){
			Life1.SetActive(false);
			Life2.SetActive(true);
			Life3.SetActive(true);

		}
		else if(LifeCounter == 1){
			Life1.SetActive(false);
			Life2.SetActive(false);
			Life3.SetActive(true);

		}
	}

	void RStartAttack(){
	 	if(GamePuase == false){
			DragonRight.SetActive(true);
			int ramdom1 = Random.Range(3, 6);
		 	Invoke("RAttackNow", ramdom1);
		 	isDragonRVisible = true;
	 	}else{
		 	Invoke("RStartAttack", 1);
			DragonRight.SetActive(false);
			DragonLeft.SetActive(false);
	 	}
	}

	void LStartAttack(){
		if(GamePuase == false){
			DragonLeft.SetActive(true);
			int ramdom2 = Random.Range(3, 6);
		 	Invoke("LAttackNow", ramdom2);
		 	isDragonLVisible = true;
		}else{
			Invoke("LStartAttack", 1);
			DragonLeft.SetActive(false);
			DragonRight.SetActive(false);
		}
		
	} 

	 void RAttackNow(){
	 	if(isRDragonOff == false && isRDragonEnable == false && GamePuase == false){
	 		isRDragonEnable = true;
	 		DragonRightAnim.SetInteger("Dragon_Right_FIRE", 2);
			DragonRightAnim.SetInteger("Dragon_Right_idle", 2);
			FuncDragonRoar(ASRDragon);
			Invoke("EnaAttackRightDragon",1 );
	 	}else{
	 		isRDragonEnable = false;
	 		print("isRDragonOff");
	 		DragonRightAnim.SetInteger("Dragon_Right_FIRE", 1);
			DragonRightAnim.SetInteger("Dragon_Right_idle", 2);
	 		Invoke("RAttackNow", 5);
	 	}
	 }

	 void LAttackNow(){
	 	if(isLDragonOff == false && isLDragonEnable == false && GamePuase == false){
	 		isLDragonEnable = true;
	 		DragonLeftAnim.SetInteger("Dragon_Right_FIRE", 2);
			DragonLeftAnim.SetInteger("Dragon_Right_idle", 2);
			FuncDragonRoar(ASLDragon);
			Invoke("EnaAttackLeftDragon",1 );
	 	}else{
	 		isLDragonEnable = false;
	 		print("isLDragonOff");
	 		DragonLeftAnim.SetInteger("Dragon_Right_FIRE", 1);
			DragonLeftAnim.SetInteger("Dragon_Right_idle", 2);
	 		Invoke("LAttackNow", 5);
	 	}
	 }

	 void EnaAttackLeftDragon()
	 {
	 	// print("Hello world: "+ GameController.LifeCounter);
	 	isRDragonEnable = false;
		DragonLeftAnim.SetInteger("Dragon_Right_idle", 2);
		DragonLeftAnim.SetInteger("Dragon_Right_FIRE", 1);
	 	LostLife();
	 	Invoke("LAttackNow", 10);
	 }

	 void EnaAttackRightDragon()
	 {
	 	// print("Hello world: "+ GameController.LifeCounter);
	 	isLDragonEnable = false;
		DragonRightAnim.SetInteger("Dragon_Right_idle", 2);
		DragonRightAnim.SetInteger("Dragon_Right_FIRE", 1);
	 	LostLife();
	 	Invoke("RAttackNow", 10);
	 }

	 void LostLife(){
	 	LifeCounter = LifeCounter - 1;
	 }
	 
	 IEnumerator FuncGamePuase(float Delay)
    {
        GamePuase = true;
        yield return new WaitForSeconds(Delay);
        GamePuase = false;
    }

    public void UnPuase(){
    	// GamePuase = false;
    	StartCoroutine(FuncGamePuase(0.5f));
    }

}
