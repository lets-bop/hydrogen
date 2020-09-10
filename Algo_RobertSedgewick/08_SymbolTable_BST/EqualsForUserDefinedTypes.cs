public class User : IComparable
{
    public bool Equals(object o)
    {
        if (o == null) return false;
        if (o == this) return true;

        if (o.GetType() != this.GetType()) return false;

        // Cast and do field level comparisons
        User otherUser = (User) o;
        return true;
    }
}