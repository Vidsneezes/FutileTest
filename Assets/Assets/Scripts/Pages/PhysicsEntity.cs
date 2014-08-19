using UnityEngine;
using System.Collections;

public class PhysicsEntity : CollidableEntity
{

		public Vector2 velocity;
	
		public PhysicsEntity (string graphic, string name) : base(graphic, name)
		{
				velocity = new Vector2 (0, 0);
		}
	
		public override void update ()
		{
				x += velocity.x * Time.deltaTime;
				y += velocity.y * Time.deltaTime;
				base.update ();
		}
		
		public void zeroVeloictyX ()
		{
				velocity.Set (0, velocity.y);
		}
}
