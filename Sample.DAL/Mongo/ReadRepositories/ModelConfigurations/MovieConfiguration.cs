using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Sample.Core.MovieApplication.Models;
using System;

namespace Sample.DAL.Mongo.ReadRepositories.ModelConfigurations
{
    internal class MovieConfiguration : IMongoModelConfiguration
    {
        public MovieConfiguration()
        {
            BsonClassMap.RegisterClassMap<MovieReadModel>(cm =>
            {
                cm.AutoMap();

                cm.MapIdField(c => c.Id).SetIgnoreIfDefault(true);
                cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapMember(c => c.Name).SetElementName("name");
                cm.MapMember(c => c.Director).SetElementName("director");
                cm.MapMember(c => c.BoxOffice).SetElementName("boxOffice");
                cm.MapMember(c => c.ImdbRate).SetElementName("imdbRate");
                cm.MapMember(c => c.MovieId).SetElementName("movieId");
                cm.MapMember(c => c.PublishDate).SetElementName("publishDate").SetSerializer(new DateTimeSerializer(DateTimeKind.Local));
            });
        }
    }
}