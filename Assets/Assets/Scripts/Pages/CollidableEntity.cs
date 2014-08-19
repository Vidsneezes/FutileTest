using UnityEngine;
using System.Collections;

public class CollidableEntity : FSprite
{
		public string id;
	
		public CollidableEntity (string graphic, string name) : base(graphic)
		{
				this.id = name;
		}
	
		public virtual void update ()
		{
		}
	
		public virtual void OnCollision (PhysicsEntity A, PhysicsEntity B)
		{
			
		}
}
