
namespace MusicStore.Logic.SqLite.DataContext;

/// <summary>
/// Factory class to create instances of IMusicStoreContext.
/// </summary>
public static class Factory
{
        /// <summary>
        /// Creates an instance of IContext.
        /// </summary>
        /// <returns>An instance of IContext.</returns>
        public static IContext CreateContext( )
        {
                var result = new MusicStoreContext( );

                Batteries.Init( );

                result.Database.EnsureCreated( );

                return result;
        }

        public static void MigrateCSVDatabase( Logic.DataContext.MusicStoreContext context , ref IContext contextSQL )
        {
                foreach(var item in context.GenreSet)
                {
                        var genre = new Entities.Genre( );
                        var gr = contextSQL.GenreSet.FirstOrDefault( x => x.Id == item.Id );

                        if(gr == null)
                        {
                                genre.Id = item.Id;
                                genre.Name = item.Name;

                                contextSQL.GenreSet.Add( genre );
                        }
                }
                foreach(var item in context.ArtistSet)
                {
                        var artist = new Entities.Artist( );
                        var ar = contextSQL.ArtistSet.FirstOrDefault( x => x.Id == item.Id );

                        if(ar == null)
                        {
                                artist.Id = item.Id;
                                artist.Name = item.Name;

                                contextSQL.ArtistSet.Add( artist );
                        }
                }

                foreach(var item in context.AlbumSet)
                {
                        var album = new Entities.Album( );
                        var ar = contextSQL.AlbumSet.FirstOrDefault( x => x.Id == item.Id );

                        if(ar == null)
                        {
                                album.Id = item.Id;
                                album.Title = item.Title;
                                album.ArtistId = item.ArtistId;
                                album.Artist = contextSQL.ArtistSet.First( a => a.Id == item.Id );

                                contextSQL.AlbumSet.Add( album );
                        }
                }

                foreach(var item in context.TrackSet)
                {
                        var track = new Entities.Track( );
                        var ar = contextSQL.TrackSet.FirstOrDefault( x => x.Title == item.Title );

                        if(ar == null)
                        {
                                track.Id = item.Id;
                                track.Title = item.Title;

                                track.AlbumId = item.AlbumId;
                                track.Album = contextSQL.AlbumSet.FirstOrDefault( al => al.Id == item.AlbumId );

                                track.GenreId = item.GenreId;
                                track.Genre = contextSQL.GenreSet.FirstOrDefault( g => g.Id == item.GenreId );

                                track.Composer = item.Composer;
                                track.UnitPrice = item.UnitPrice;
                                track.Bytes = item.Bytes;
                                track.Milliseconds = item.Milliseconds;

                                contextSQL.TrackSet.Add( track );
                                contextSQL.SaveChanges( );
                        }
                }

        }
}
