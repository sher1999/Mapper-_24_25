namespace Domain.Dtos;

public class GetAlbumDto
{
    public int AlbumId { get; set; }
    public int ProductId { get; set; }
    public string AlbumName { get; set; }
    public string ArtistName { get; set; }
    public string Genre { get; set; }
    public int NumberOfSongs { get; set; }
    public  DateTime ReleaseDate { get; set; }

    public GetAlbumDto()
    {
        
    }

    public GetAlbumDto(int albumId,int productId,string albumName,string artistName,string genre,int numberOfSongs)
    {
        AlbumId = albumId;
        ProductId = productId;
        AlbumName = albumName;
        ArtistName = artistName;
        Genre = genre;
        NumberOfSongs = numberOfSongs;
        ReleaseDate=DateTime.UtcNow;
        
    }
}