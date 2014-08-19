using UnityEngine;
using System.Collections;

public class GamePageV2 : Page
{

		public PaddleEntity player1;
		public PaddleEntity player2;
		public BallEntity ball;
		
		public FLabel scorePlayer1;
		public FLabel scorePlayer2;
		
		public float maxScore = 5;
		
		public bool paused = false;
		
		public GamePageV2 ()
		{
			
		}

		// Use this for initialization
		public override void Start ()
		{
				player1 = new PaddleEntity (0, 100, "p", "player1");
				player2 = new PaddleEntity (Futile.screen.width, 100, "p", "player2");
				ball = new BallEntity (Futile.screen.halfWidth, Futile.screen.halfHeight, "ball", "ball");
				AddChild (player1);
				AddChild (player2);
				AddChild (ball);
				
				scorePlayer1 = new FLabel ("regular", player1.id + ":" + player1.score);
				scorePlayer1.anchorX = 0;
				scorePlayer1.anchorY = 1;
				scorePlayer1.x = 200;
				scorePlayer1.y = 200;
				
				scorePlayer2 = new FLabel ("regular", player2.id + ":" + player2.score);
				scorePlayer2.anchorX = 0;
				scorePlayer2.anchorY = 1;
				scorePlayer2.x = Futile.screen.width - 400;
				scorePlayer2.y = 200;
				
				AddChild (scorePlayer1);
				AddChild (scorePlayer2);
		
				ball.releaseBall ();
				ListenForUpdate (Update);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (paused == false) {
						player1.inputReciver (Input.GetKey (KeyCode.W), Input.GetKey (KeyCode.S));
						player2.inputReciver (Input.GetKey (KeyCode.UpArrow), Input.GetKey (KeyCode.DownArrow));
						collide ();
						player1.update ();
						player2.update ();
						ball.update ();
						if (ball.x + ball.width / 2 < 0) {
								giveScore (false);
						
						} else if (ball.x - ball.width / 2 > Futile.screen.width) {
								giveScore (true);
						
						}
				}
		}
		
		void giveScore (bool _player1)
		{
				ball.releaseBall ();
				if (_player1) {
						player1.score++;
						updateScore ();
						if (player1.score > maxScore) {
								paused = true;
								scorePlayer1.text = player1.id + " : WIN";
								scorePlayer2.text = player2.id + " : LOSE";
						}
				} else {
						player2.score++;
						updateScore ();
						if (player2.score > maxScore) {
								paused = true;
								scorePlayer1.text = player1.id + " : LOSE";
								scorePlayer2.text = player2.id + " : WIN";
						}
				}
		
				
		
		}
		
		void updateScore ()
		{
				scorePlayer1.text = player1.id + ":" + player1.score;
				scorePlayer2.text = player2.id + ":" + player2.score;
		}
	
		//For ease check ball agains paddles
		//And only on X axis
		public void collide ()
		{
				Rect _A = player1.localRect.CloneAndOffset (player1.x + (player1.velocity.x * Time.deltaTime), player1.y + (player1.velocity.y * Time.deltaTime));
				Rect _B = player2.localRect.CloneAndOffset (player2.x + (player2.velocity.x * Time.deltaTime), player2.y + (player2.velocity.y * Time.deltaTime));
				Rect _C = ball.localRect.CloneAndOffset (ball.x + (ball.velocity.x * Time.deltaTime), ball.y + (ball.velocity.y * Time.deltaTime));
		
				if (_C.Overlaps (_B)) {
						if (_C.xMax > _B.xMin) {
								ball.x -= _C.xMax - _B.xMin;
								ball.OnCollision (ball, player2);
						}
				}
				
				if (_C.Overlaps (_A)) {
						if (_C.xMin < _A.xMax) {
								ball.x += _A.xMax - _C.xMin;
								ball.OnCollision (ball, player1);
						}
				}
		}
	
}


