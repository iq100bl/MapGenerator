namespace Common
{
    public interface ICell
    {
        Chance Chance { get; set; }
        Territory Territory { get; set; }
    }
}