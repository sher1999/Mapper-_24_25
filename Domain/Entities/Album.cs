using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Album
{[Key]
   public int AlbumId { get; set; }
   public int ProductId { get; set; }
   public Product Product { get; set; }
   [Required,MaxLength(50)]
    public string AlbumName { get; set; }
    [Required,MaxLength(50)]
    public string ArtistName { get; set; }
    [Required,MaxLength(50)]
    public string Genre { get; set; }
    public int NumberOfSongs { get; set; }
    public  DateTime ReleaseDate { get; set; }

    public Album()
    {
        
    }

    public Album(int albumId,int productId,string albumName,string artistName,string genre,int numberOfSongs)
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

 