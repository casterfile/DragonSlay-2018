#pragma strict

var minSwipeDistY : float;

var minSwipeDistX : float;

//var Swipe: GUIText;
var swipeValue : float;

var ChangeSceneNext: String;
var ChangeScenePrev: String;

private var startPos :Vector2; 

	function Update () 
	{

		if (Input.touchCount > 0) 
		{

		var touch : Touch = Input.touches[0];

		switch (touch.phase) 

			{

			case TouchPhase.Began:

			startPos = touch.position;

			break;


			case TouchPhase.Ended:
			var swipeDistVertical : float;
			swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

			var swipeDistHorizontal : float;

			swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
//				if (swipeDistVertical > minSwipeDistY) 
//				{
//					
//					swipeValue = Mathf.Sign(touch.position.y - startPos.y);
//
//					if (swipeValue > 0)//up
//					{	
//						//Jump ();
//						
//						
//						//Swipe.text = "Up Swipe ";
//						Debug.Log("Up Swipe");
//						//Swipe.pixelOffset.x = Swipe.pixelOffset.x + minSwipeDistX;
//						
//					}
//					else if (swipeValue < 0)//down
//					{	
//						//Shrink ();
//						//Swipe.text = "Down Swipe ";
//						Debug.Log("Down Swipe");
//						//Swipe.pixelOffset.x = Swipe.pixelOffset.x - minSwipeDistX;
//					}
//				}
				if (swipeDistHorizontal > minSwipeDistX) 
				{
					swipeValue = Mathf.Sign(touch.position.x - startPos.x);

					if (swipeValue > 0)//right
					{
						//MoveRight ();
						Debug.Log("MoveRight");
						if(ChangeScenePrev != null)
						{
							Application.LoadLevel (ChangeScenePrev);
						}
					}
					else if (swipeValue < 0)//left
					{	
						//MoveLeft ();
						Debug.Log("MoveLeft");
						if(!ChangeSceneNext  != null)
						{
							Application.LoadLevel (ChangeSceneNext);
						}
					}
				}
				break;
			}
		}	

	}