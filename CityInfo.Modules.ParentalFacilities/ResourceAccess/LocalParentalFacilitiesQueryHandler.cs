using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CityInfo.Modules.ParentalFacilities.Domain.Models;
using Microsoft.Data.Sqlite;

namespace CityInfo.Modules.ParentalFacilities.ResourceAccess
{
    public class LocalParentalFacilitiesQueryHandler : IParentalFacilitiesQueryHandler
    {
        private const string TableName = "ParentalFacilities";
        private readonly SqliteConnection _connection;

        public LocalParentalFacilitiesQueryHandler()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Shared,
                DataSource = Path.GetTempFileName()
            };
            var connStr = builder.ConnectionString;
            _connection = new SqliteConnection(connStr);
            _connection.Open();
            var creation = $"CREATE TABLE {TableName} (" +
                $"{nameof(ParentalFacility.Id)} TEXT NOT NULL UNIQUE, " +
                $"{nameof(ParentalFacility.Name)} TEXT NOT NULL, " +
                $"{nameof(ParentalFacility.Description)} TEXT NOT NULL, " +
                $"{nameof(ParentalFacility.Rating)} INTEGER, " +
                $"{nameof(ParentalFacility.Latitude)} REAL NOT NULL, " +
                $"{nameof(ParentalFacility.Longitude)} REAL NOT NULL, " +
                $"{nameof(ParentalFacility.LastCleanedAt)} TEXT NOT NULL, " +
                $"{nameof(ParentalFacility.Microwave)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.ChangeTable)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.RubbishBin)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.Toilet)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.Shower)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.MusicPlayer)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.HighChair)} INTEGER NOT NULL, " +
                $"{nameof(ParentalFacility.SittingChair)} INTEGER NOT NULL, " +
                $"PRIMARY KEY(\"{nameof(ParentalFacility.Id)}\"))";
            new SqliteCommand(creation, _connection).ExecuteNonQuery();

            Create(new ParentalFacility
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Central Station",
                Description = "Sample Descriptive Text Content",
                Rating = 4,
                Latitude = -27.465970,
                Longitude = 153.026125,
                LastCleanedAt = DateTimeOffset.Now.Subtract(new TimeSpan(6, 0, 0)),
                Microwave = true,
                Toilet = true,
                Shower = true
            });

            Create(new ParentalFacility
            {
                Id = Guid.NewGuid().ToString(),
                Name = "King George Square",
                Description = "Sample Descriptive Text Content",
                Rating = 3,
                Latitude = -27.468678,
                Longitude = 153.024359,
                LastCleanedAt = DateTimeOffset.Now.Subtract(new TimeSpan(24, 0, 0)),
                RubbishBin = true,
                HighChair = true,
                ChangeTable = true
            });

            Create(new ParentalFacility
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Roma Street Station",
                Description = "Sample Descriptive Text Content",
                Rating = 2,
                Latitude = -27.466373,
                Longitude = 153.018818,
                LastCleanedAt = DateTimeOffset.Now.Subtract(new TimeSpan(7, 0, 0, 0)),
                Shower = true,
                MusicPlayer = true,
                SittingChair = true
            });
        }


        public IEnumerable<ParentalFacility> Query(ListParentalFacilitiesQuery query)
        {
            var cmd = new SqliteCommand();

            var selectQuery = $"SELECT * FROM {TableName}";
            var whereClauses = new List<string>();
            if (query.KeyWord != null)
            {
                whereClauses.Add($"{nameof(ParentalFacility.Name)} LIKE '%{query.KeyWord}%'");
            }

            cmd.CommandText = whereClauses.Any()
                ? $"{selectQuery} WHERE {string.Join(" AND ", whereClauses)}"
                : selectQuery;
            cmd.Connection = _connection;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new ParentalFacility
                {
                    Id = reader[nameof(ParentalFacility.Id)].ToString(),
                    Name = reader[nameof(ParentalFacility.Name)].ToString(),
                    Description = reader[nameof(ParentalFacility.Description)].ToString(),
                    Rating = int.Parse(reader[nameof(ParentalFacility.Rating)].ToString()),
                    Latitude = double.Parse(reader[nameof(ParentalFacility.Latitude)].ToString()),
                    Longitude = double.Parse(reader[nameof(ParentalFacility.Longitude)].ToString()),
                    LastCleanedAt = DateTimeOffset.Parse(reader[nameof(ParentalFacility.LastCleanedAt)].ToString()),

                    Microwave = int.Parse(reader[nameof(ParentalFacility.Microwave)].ToString()) == 1,
                    ChangeTable = int.Parse(reader[nameof(ParentalFacility.ChangeTable)].ToString()) == 1,
                    RubbishBin = int.Parse(reader[nameof(ParentalFacility.RubbishBin)].ToString()) == 1,
                    Toilet = int.Parse(reader[nameof(ParentalFacility.Toilet)].ToString()) == 1,
                    Shower = int.Parse(reader[nameof(ParentalFacility.Shower)].ToString()) == 1,
                    MusicPlayer = int.Parse(reader[nameof(ParentalFacility.MusicPlayer)].ToString()) == 1,
                    HighChair = int.Parse(reader[nameof(ParentalFacility.HighChair)].ToString()) == 1,
                    SittingChair = int.Parse(reader[nameof(ParentalFacility.SittingChair)].ToString()) == 1
                };
            }
        }

        private void Create(ParentalFacility entity)
        {
            var insert = $"INSERT INTO {TableName} " +
               $"({nameof(ParentalFacility.Id)}, {nameof(ParentalFacility.Name)}, {nameof(ParentalFacility.Description)}, {nameof(ParentalFacility.Rating)}, {nameof(ParentalFacility.Latitude)}, {nameof(ParentalFacility.Longitude)}, {nameof(ParentalFacility.LastCleanedAt)}, " +
               $"{nameof(ParentalFacility.Microwave)}, {nameof(ParentalFacility.ChangeTable)}, {nameof(ParentalFacility.RubbishBin)}, {nameof(ParentalFacility.Toilet)}, {nameof(ParentalFacility.Shower)}, {nameof(ParentalFacility.MusicPlayer)}, {nameof(ParentalFacility.HighChair)}, {nameof(ParentalFacility.SittingChair)}) " +
               $"VALUES (${nameof(ParentalFacility.Id)}, ${nameof(ParentalFacility.Name)}, ${nameof(ParentalFacility.Description)}, ${nameof(ParentalFacility.Rating)}, ${nameof(ParentalFacility.Latitude)} , ${nameof(ParentalFacility.Longitude)}, ${nameof(ParentalFacility.LastCleanedAt)}, " +
               $"${nameof(ParentalFacility.Microwave)}, ${nameof(ParentalFacility.ChangeTable)}, ${nameof(ParentalFacility.RubbishBin)}, ${nameof(ParentalFacility.Toilet)}, ${nameof(ParentalFacility.Shower)}, ${nameof(ParentalFacility.MusicPlayer)}, ${nameof(ParentalFacility.HighChair)}, ${nameof(ParentalFacility.SittingChair)})";
            var cmd = new SqliteCommand(insert, _connection);

            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Id)}", entity.Id);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Name)}", entity.Name);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Description)}", entity.Description);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Rating)}", entity.Rating);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Latitude)}", entity.Latitude);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Longitude)}", entity.Longitude);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.LastCleanedAt)}", entity.LastCleanedAt.ToString());
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Microwave)}", entity.Microwave);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.ChangeTable)}", entity.ChangeTable);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.RubbishBin)}", entity.RubbishBin);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Toilet)}", entity.Toilet);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.Shower)}", entity.Shower);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.MusicPlayer)}", entity.MusicPlayer);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.HighChair)}", entity.HighChair);
            cmd.Parameters.AddWithValue($"${nameof(ParentalFacility.SittingChair)}", entity.SittingChair);

            cmd.ExecuteScalar();
        }
    }
}
