using GameyMickGameFace.Media;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    public class PowerUp
    {
        public string Name { get; set; }
        public Texture2D Image { get; set; }
        public Body PhysicsBody { get; set; }
        Audio se;

        public PowerUp()
        {
            PhysicsBody = new Body( new Point( 200, 200 ), 95, 86, 0, 100, .85f, this );
            se = new Audio( );
        }

        public void OnPickup( Player effectedPlayer )
        {
            //do something
            Media.Audio.Damage.Play( );
        }

        public virtual void Draw( GameTime time, SpriteBatch batch, GameStates gameState )
        {
            if( gameState == GameStates.Title )
                return;

            batch.Draw( Image, PhysicsBody.Position, Color.White );
        }

        public virtual void Update( GameTime time, GameStates gameState )
        {
            if( gameState == GameStates.Title )
                return;
        }
    }
}
