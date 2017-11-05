namespace MusicDataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deployment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Release = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AlbumTracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        TrackNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.AlbumId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Length = c.Time(nullable: false, precision: 7),
                        Release = c.DateTime(nullable: false, storeType: "date"),
                        NumberOfPlay = c.Long(nullable: false),
                        TrackLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RealName = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthCountry = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayListTracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                        TrackNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.PlaylistId })
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistTracks",
                c => new
                    {
                        Artist_Id = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_Id, t.Track_Id })
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.GenreTracks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Track_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Track_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayListTracks", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.PlayListTracks", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.GenreTracks", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.GenreTracks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.ArtistTracks", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.ArtistTracks", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.AlbumTracks", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.AlbumTracks", "AlbumId", "dbo.Albums");
            DropIndex("dbo.GenreTracks", new[] { "Track_Id" });
            DropIndex("dbo.GenreTracks", new[] { "Genre_Id" });
            DropIndex("dbo.ArtistTracks", new[] { "Track_Id" });
            DropIndex("dbo.ArtistTracks", new[] { "Artist_Id" });
            DropIndex("dbo.PlayListTracks", new[] { "PlaylistId" });
            DropIndex("dbo.PlayListTracks", new[] { "TrackId" });
            DropIndex("dbo.AlbumTracks", new[] { "AlbumId" });
            DropIndex("dbo.AlbumTracks", new[] { "TrackId" });
            DropTable("dbo.GenreTracks");
            DropTable("dbo.ArtistTracks");
            DropTable("dbo.Playlists");
            DropTable("dbo.PlayListTracks");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Tracks");
            DropTable("dbo.AlbumTracks");
            DropTable("dbo.Albums");
        }
    }
}
