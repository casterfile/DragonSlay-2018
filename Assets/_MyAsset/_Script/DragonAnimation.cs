using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour {

	// private Animator animController;
	// public string ObjectName;
	// public static bool isRDragonEnable = false, isLDragonEnable = false;
	// // Use this for initialization
	// void Start () {
	// 	animController = GetComponent<Animator>();
	// 	// InvokeRepeating("AttackAnimationExec", 1.0f, 5.0f);
	// 	Invoke("AttackAnimationExec", 1);
	// }

	// void AttackAnimationExec(){
	// 	Invoke("ExecuteAfterTime1", 5);
	// }

	//  void ExecuteAfterTime1()
	//  {  
	//  	Invoke("AttackNow", 1);
	//  }

	//  void AttackNow(){
	//  	if(GameController.isRDragonOff == false && isRDragonEnable == false && gameObject.name == ObjectName){
	//  		isRDragonEnable = true;
	//  		animController.SetInteger("Dragon_Right_FIRE", 2);
	// 		animController.SetInteger("Dragon_Right_idle", 2);
			
	// 		Invoke("EnaAttackRightDragon",1 );
	//  	}else{
	//  		print("isRDragonOff");
	//  		Invoke("AttackAnimationExec", 1);
	//  	}

	//  	if(GameController.isLDragonOff == false && isLDragonEnable == false && gameObject.name == ObjectName){
	//  		isLDragonEnable = true;
	//  		animController.SetInteger("Dragon_Right_FIRE", 2);
	// 		animController.SetInteger("Dragon_Right_idle", 2);
			
	// 		Invoke("EnaAttackLeftDragon",1 );
	//  	}else{
	//  		print("isLDragonOff");
	//  		Invoke("AttackAnimationExec", 1);
	//  	}
	//  }

	//  void EnaAttackLeftDragon()
	//  {
	//  	// print("Hello world: "+ GameController.LifeCounter);
	//  	isRDragonEnable = false;
	//  	LostLife();
	//  }

	//  void EnaAttackRightDragon()
	//  {
	//  	// print("Hello world: "+ GameController.LifeCounter);
	//  	isLDragonEnable = false;
	//  	LostLife();
	//  }

	//  void LostLife(){
	//  	GameController.LifeCounter = GameController.LifeCounter - 1;
	// 	animController.SetInteger("Dragon_Right_FIRE", 1);
	// 	Invoke("AttackAnimationExec", 1);
	//  }
}
