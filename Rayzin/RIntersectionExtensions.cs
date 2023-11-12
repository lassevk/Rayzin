namespace Rayzin;

public static class RIntersectionExtensions
{
    public static RIntersection? Hit(this IList<RIntersection> intersections)
    {
        return intersections.Where(i => i.T >= 0).OrderBy(i => i.T).Select(i => new RIntersection?(i)).FirstOrDefault();
    }
}