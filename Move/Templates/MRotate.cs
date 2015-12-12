public class MRotate : MovTemplate {

    public override void play()
    {
        transform.Rotate(0,0, -speed);
    }
}
