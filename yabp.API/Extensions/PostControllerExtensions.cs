using yabp.Business.Services.PostService.Dtos;

namespace yabp.API.Extensions;

public static class PostControllerExtensions
{
    public static IList<GetPostResponse> SearchPosts(this IEnumerable<GetPostResponse> request, string search)
    {
        return request
            .Where(post => post.Title.Contains(search) || post.Content.Contains(search))
            .ToList();
    }

    public static IList<GetPostResponse> OrderPostBy(this IEnumerable<GetPostResponse> request, string orderBy)
    {
        return orderBy.ToLower() switch
        {
            "ascending" => request.OrderBy(response => response.Created).ToList(),
            "descending" => request.OrderByDescending(response => response.Created).ToList(),
            _ => request.ToList()
        };
    }
    
    public static IList<GetPostResponse> DateBetween(this IEnumerable<GetPostResponse> request, string? dateStart, string? dateEnd)
    {
        if (dateStart != null)
        {
            request = request
                .Where(res => res.Created >= dateStart.StringToDateTime())
                .ToList();
        }

        if (dateEnd != null)
        {
            request = request
                .Where(res => res.Created <= dateEnd.StringToDateTime())
                .ToList();
        }

        return request.ToList();
    }

    private static DateTime? StringToDateTime(this string dateString)
    {
        try
        {
            switch (dateString.Length)
            {
                case 10:
                {
                    var year = int.Parse(dateString[..4]);
                    var month = int.Parse(dateString[5..7]);
                    var day = int.Parse(dateString[8..]);
                    return new DateTime(year, month, day);
                }
                case 7:
                {
                    var year = int.Parse(dateString[..4]);
                    var month = int.Parse(dateString[5..]);
                    return new DateTime(year, month, 1);
                }
                case 4:
                {
                    var year = int.Parse(dateString);
                    return new DateTime(year, 1, 1);
                }
                default:
                    return null;
            }
        }
        catch
        {
            return null;
        }
    }
}