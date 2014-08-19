using UnityEngine;
using System.Collections;

public class PaddleEntity : PhysicsEntity
{	
		public int score;

		public PaddleEntity (float X, float Y, string graphic, string name) : base(graphic, name)
		{
				x = X;
				y = Y;
				score = 0;
		}
	
		public override void update ()
		{
				if ((y + height / 2) + velocity.y * Time.deltaTime > Futile.screen.height) {
						velocity.y = 0;
				} else if ((y - height / 2) + velocity.y * Time.deltaTime < 0) {
						velocity.y = 0;
				}
				base.update ();
				velocity.Set (0, 0);
		}
		
		public void inputReciver (bool up, bool down)
		{
				if (up) {
						velocity.y = 300;
				}
				if (down) {
						velocity.y = -300;
				}
		}
}
