using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    public class HealthPowerUp : PowerUp
    {
        private readonly Animation _animation;

        public HealthPowerUp( Animation animation )
        {
            _animation = animation;
        }

        public override void Draw( GameTime time, SpriteBatch batch, GameStates gameState )
        {
            base.Draw( time, batch, gameState );

            if( gameState == GameStates.Title )
                return;

            if( _animation == null )
                return;

            var position = PhysicsBody.Position;
            var newPosition = new Vector2( position.X - 80, position.Y - 100 );

            batch.Draw( _animation.Frame, newPosition, Color.White );
        }

        public override void Update( GameTime time, GameStates gameState )
        {
            base.Update( time, gameState );

            if( gameState == GameStates.Title )
                return;

            if( _animation == null )
                return;

            _animation.NextFrame( time );
        }
    }
}
