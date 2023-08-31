namespace Assessment
{
    public class AuthorizationContext
    {
        internal readonly object HttpContext;

        internal void Allow()
        {
            throw new NotImplementedException();
        }

        internal void Deny()
        {
            throw new NotImplementedException();
        }
    }
}