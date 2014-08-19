using UnityEngine;
using System.Collections;

public class BallEntity : PhysicsEntity
{
		float[] angles;
		
		public BallEntity (float X, float Y, string graphic, string name) : base(graphic, name)
		{
				x = X;
				y = Y;
				angles = new float[]{45, 135, 225, 315};
		}
		
		public override void update ()
		{
				if ((y + height / 2) + velocity.y * Time.deltaTime > Futile.screen.height) {
						velocity.y *= -1;
				} else if ((y - height / 2) + velocity.y * Time.deltaTime < 0) {
						velocity.y *= -1;
				}
				base.update ();
				
		}
		
		public void releaseBall ()
		{
				x = Futile.screen.halfWidth;
				y = Futile.screen.halfHeight;
				float velX = 0;
				float velY = 0;
				float angle = RXRandom.AnyItem<float> (angles);
				velX = 200 * Mathf.Cos (angle * Mathf.Deg2Rad);
				velY = 200 * Mathf.Sin (angle * Mathf.Deg2Rad);
				velocity.Set (velX, velY);
		}
		
		public override void OnCollision (PhysicsEntity A, PhysicsEntity B)
		{
				float localHitLoc = A.y - B.y;
				float angleMultiplier = Mathf.Abs (localHitLoc / (B.height / 2));
		
				float xVelocity = Mathf.Cos (65.0f * angleMultiplier * Mathf.Deg2Rad) * 600;
				float yVelocity = Mathf.Sin (65.0f * angleMultiplier * Mathf.Deg2Rad) * 400;
		
				if (localHitLoc < 0) {
						yVelocity = -yVelocity;
				}
				
				if (velocity.x > 0) {
						xVelocity = -xVelocity;
				}
				
				velocity.Set (xVelocity, yVelocity);
		}
}
