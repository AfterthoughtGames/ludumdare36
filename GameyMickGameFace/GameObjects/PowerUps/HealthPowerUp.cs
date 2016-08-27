using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameyMickGameFace.GameObjects.PowerUps
{
    public class HealthPowerUp : PowerUp
    {
        public int healthAmount { get; set; }
        private readonly Animation _animation;

        public HealthPowerUp( Texture2D healthTexture, Animation animation )
            : base( healthTexture )
        {
            healthAmount = 3;
            Name = "Health";
            _animation = animation;
            scale = .75f;
        }

        public override void OnPickup( Player effectedPlayer )
        {
            base.OnPickup( effectedPlayer );
            effectedPlayer.Health += healthAmount;
        }

        public override void Draw( GameTime time, SpriteBatch batch, GameStates gameState )
        {
            base.Draw( time, batch, gameState );

            if( gameState == GameStates.Title )
                return;

            if( _animation == null )
                return;

            var animationScale = new Vector2(.20f);
            var pos = new Vector2( position.X + 7, position.Y - 28 );
            batch.Draw( _animation.Frame, pos, null, null, null, default(float), animationScale );
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
